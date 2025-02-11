using System;
using System.Collections.Generic;
using System.IO;
using layout;
using GerenciarTarefa;

class Program
{
    static void Main(string[] args)
    {
        Gerenciador gerenciador = new Gerenciador();
        gerenciador.CarregarTarefas();  
        
        bool executando = true;
        while (executando)
        {
            Formatacao.ImprimirCabecalho();
            Formatacao.Cor("Escolha uma opção:", ConsoleColor.White);
            Console.WriteLine("1 - Adicionar Tarefa");
            Console.WriteLine("2 - Listar Tarefa");
            Console.WriteLine("3 - Concluir Tarefa");
            Console.WriteLine("4 - Remover Tarefa");
            Console.WriteLine("5 - Sair");
            Console.Write("Opção: ");
            
            string opcao = Console.ReadLine();
            Console.Clear();

            switch (opcao)
            {
                case "1":
                    Console.Write("Digite a descrição da tarefa: ");
                    string descricao = Console.ReadLine();
                    gerenciador.AdicionarTarefa(descricao);
                    break;

                case "2":
                    Formatacao.ImprimirCabecalho();
                    Formatacao.Cor("Lista de Tarefas:", ConsoleColor.Yellow);
                    gerenciador.ListarTarefa();
                    break;

                case "3":
                    Console.Write("Digite o ID da tarefa a ser concluída: ");
                    if (int.TryParse(Console.ReadLine(), out int idConcluir))
                    {
                        gerenciador.ConcluirTarefa(idConcluir);
                    }
                    else
                    {
                        Console.WriteLine("ID inválido.");
                    }
                    break;

                case "4":
                    Console.Write("Digite o ID da tarefa a ser removida: ");
                    if (int.TryParse(Console.ReadLine(), out int idRemover))
                    {
                        gerenciador.RemoverTarefa(idRemover);
                    }
                    else
                    {
                        Console.WriteLine("ID inválido.");
                    }
                    break;

                case "5":
                    executando = false;
                    Formatacao.Cor("Saindo... ", ConsoleColor.DarkBlue);
                    break;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
