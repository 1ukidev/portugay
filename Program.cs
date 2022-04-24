// Copyright (c) 1ukidev <leo.monteiro06@live.com>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.IO;
using System.Diagnostics;

namespace Portugay
{
    class Program
    {
        static void Main(string[] file)
        {
            // Verificar se o argumento foi passado
            if(file == null || file.Length == 0)
            {
                Console.WriteLine("Nenhum arquivo foi passado.");
                Environment.Exit(1);
            }

            // Guardar o caminho do arquivo
            string path = Path.GetFullPath(file[0]);
 
            // Verificar se o arquivo existe
            if(File.Exists(file[0]))
            {
                // Ler o código
                string text = File.ReadAllText(path);

                // Guadar nome do arquivo
                string filename = Path.GetFileNameWithoutExtension(path);

                // Criar arquivo que receberá o código C++
                if(System.OperatingSystem.IsLinux())
                {
                    // Linux
                    path = Path.GetDirectoryName(path) + "/" + filename + ".cpp";
                }
                else
                {
                    // Windows
                    path = Path.GetDirectoryName(path) + @"\\" + filename + ".cpp";
                }

                // Inserir cabeçalhos e definir namespace
                text = text.Insert(0, "#include <iostream>\n#include <stdlib.h>\n\nusing namespace std;\n\n");

                // Substituir o código pelo equivalente em C++
                
                // Função principal
                text = text.Replace("iniciar", "int main(void) {");
                text = text.Replace("terminar", "}");
                // Variáveis
                text = text.Replace("inteiro", "int");
                text = text.Replace("real", "float");
                text = text.Replace("vazio", "void");
                text = text.Replace("caractere", "char");
                // Entrada / Saída
                text = text.Replace("escreva", "cout <<");
                text = text.Replace("leia", "cin >>");
                text = text.Replace("retornar", "return");
                // Estruturas de repetição
                text = text.Replace("para", "for");
                text = text.Replace("enquanto", "while");
                text = text.Replace("faca", "do");
                // Estruturas de decisão
                text = text.Replace("se", "if");
                text = text.Replace("senao", "else");
                // Funções
                text = text.Replace("sistema", "system");

                // Escrever no novo arquivo
                File.WriteAllText(path, text);
                
                // Compilar usando GCC
                if(System.OperatingSystem.IsLinux())
                {
                    // Linux
                    ProcessStartInfo startInfo = new ProcessStartInfo() { FileName = "g++", Arguments = "-O3 -pipe " + path + " -o " + filename }; 
                    Process proc = new Process() { StartInfo = startInfo };
                    proc.Start();
                    proc.WaitForExit();
                }
                else
                {
                    // Windows
                    ProcessStartInfo startInfo = new ProcessStartInfo() { FileName = "cmd.exe", Arguments = "/C g++ -O3 -pipe " + path + " -o " + filename + ".exe" };
                    Process proc = new Process() { StartInfo = startInfo };
                    proc.Start();
                    proc.WaitForExit();
                }
            }
            else
            {
                Console.WriteLine("Arquivo não encontrado.");
                Environment.Exit(1);
            }
        }
    }
}
