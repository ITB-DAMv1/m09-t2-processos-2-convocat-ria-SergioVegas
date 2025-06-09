    using System;
    using System.Diagnostics;
    using System.IO;

    namespace Exercici4
    {
        class Program
        {
            static void Main()
            {
                var processes = Process.GetProcesses();
                int totalProcs = processes.Length, totalThreads = 0;
                const string output = @"..\..\..\processos.txt";

                using var writer = new StreamWriter(output);
                foreach (var proc in processes)
                {
                    writer.WriteLine($"Procés: {proc.ProcessName} (PID: {proc.Id})");
                    foreach (ProcessThread th in proc.Threads)
                    {
                        writer.WriteLine($"\tFil ID: {th.Id}");
                        totalThreads++;
                    }
                }
                writer.WriteLine($"Total processos: {totalProcs}");
                writer.WriteLine($"Total fils: {totalThreads}");

                Console.WriteLine("Resultats desats a processos.txt");
            }
        }
    }

