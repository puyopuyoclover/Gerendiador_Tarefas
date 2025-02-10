using System;
using System.Collections.Generic;

namespace layout
{
    public static class Formatacao
    {
        public static void Cor(string mensagem, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;
            Console.WriteLine(mensagem);
            Console.ResetColor();
        }

        public static void ImprimirCabecalho()
        {
            Cor("==================================", ConsoleColor.Cyan);
            Cor("       Gerenciador de Tarefas   ", ConsoleColor.Green);
            Cor("==================================", ConsoleColor.Cyan);
        }
    }
}

namespace Tarefas
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public bool Concluida { get; set; }

        public Tarefa(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
            Concluida = false;
        }

        public void ExibirTarefa()
        {
            Console.WriteLine($"[{Id}] - {Descricao} - {(Concluida ? "Concluída" : "Pendente")}");
        }
    }
}

namespace GerenciarTarefa
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Tarefas;

    public class Gerenciador
    {
        private List<Tarefa> listaTarefas = new List<Tarefa>();
        private int proximoId = 1;
        private string arquivoTarefas = "tarefas.txt";

        public void AdicionarTarefa(string descricao)
        {
            var tarefa = new Tarefa(proximoId++, descricao);
            listaTarefas.Add(tarefa);
            Console.WriteLine("Tarefa adicionada com sucesso!");
            SalvarTarefas();
        }

        public void ConcluirTarefa(int id)
        {
            var tarefa = listaTarefas.Find(t => t.Id == id);
            if (tarefa != null)
            {
                tarefa.Concluida = true;
                Console.WriteLine("Tarefa concluída com sucesso!");
                SalvarTarefas();
            }
            else
            {
                Console.WriteLine("Tarefa não encontrada.");
            }
        }

        public void ListarTarefa()
        {
            if (listaTarefas.Count == 0)
            {
                Console.WriteLine("Nenhuma tarefa encontrada.");
                return;
            }

            foreach (var tarefa in listaTarefas)
            {
                tarefa.ExibirTarefa();
            }
        }

        public void RemoverTarefa(int id)
        {
            var tarefa = listaTarefas.Find(t => t.Id == id);
            if (tarefa != null)
            {
                listaTarefas.Remove(tarefa);
                Console.WriteLine("Tarefa removida com sucesso!");
                SalvarTarefas();
            }
            else
            {
                Console.WriteLine("Tarefa não encontrada.");
            }
        }

        public void SalvarTarefas()
        {
            using (StreamWriter writer = new StreamWriter(arquivoTarefas))
            {
                foreach (var tarefa in listaTarefas)
                {
                    writer.WriteLine($"{tarefa.Id}|{tarefa.Descricao}|{tarefa.Concluida}");
                }
            }
        }

        public void CarregarTarefas()
        {
            if (!File.Exists(arquivoTarefas))
                return;

            using (StreamReader reader = new StreamReader(arquivoTarefas))
            {
                string linha;
                while ((linha = reader.ReadLine()) != null)
                {
                    string[] dados = linha.Split('|');
                    int id = int.Parse(dados[0]);
                    string descricao = dados[1];
                    bool concluida = bool.Parse(dados[2]);

                    var tarefa = new Tarefa(id, descricao) { Concluida = concluida };
                    listaTarefas.Add(tarefa);
                    if (id >= proximoId)
                    {
                        proximoId = id + 1;
                    }
                }
            }
        }
    }
}

