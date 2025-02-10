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
    using Tarefas;
    public class Gerenciador
    {
        private List<Tarefa> listaTarefas = new List<Tarefa>();
        private int proximoId = 1;

        public void AdicionarTarefa(string descricao)
        {
            var tarefa = new Tarefa(proximoId++, descricao);
            listaTarefas.Add(tarefa);
            Console.WriteLine("Tarefa adicionada com sucesso!");
        }

        public void ConcluirTarefa(int id)
        {
            var tarefa = listaTarefas.Find(t => t.Id == id);
            if (tarefa != null)
            {
                tarefa.Concluida = true;
                Console.WriteLine("Tarefa concluída com sucesso!");
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
            }
            else
            {
                Console.WriteLine("Tarefa não encontrada.");
            }
        }
    }
}

