﻿// Copyright (c) 1ukidev <leo.monteiro06@live.com>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Portugay
{
    class Program
    {
        static void Main(string[] file)
        {
            // Verificar se algum argumento foi passado
            if (file == null || file.Length == 0)
            {
                Console.WriteLine("Nenhum arquivo foi passado.\nTente 'Portugay --help' para mais informações.");
                Environment.Exit(1);
            }

            // Exibir ajuda ao passar o argumento --help, -h ou -?
            if (file[0] == "--help" || file[0] == "-h" || file[0] == "-?") {
                Console.WriteLine("Um programa inspirado no Portugol para fins educacionais.\n");
                Console.WriteLine("Funcionamento: O programa recebe o texto, traduz para C++ em um novo arquivo e por fim compila usando o Clang.\n");
                Console.WriteLine("Uso: ");
                Console.WriteLine("  Portugay <arquivo>");
                Console.WriteLine("Exemplo: ");
                Console.WriteLine("  Portugay teste.p\n");
                Console.WriteLine("O arquivo com código traduzido ficará salvo em <nome do arquivo>.cpp\n");
                Console.WriteLine("Acesse https://github.com/1ukidev/portugay para mais informações.");
                Environment.Exit(0);
            }

            // Guardar o caminho do arquivo
            string path = Path.GetFullPath(file[0]);
 
            // Verificar se o arquivo existe
            if (File.Exists(file[0]))
            {
                // Ler o código
                string text = File.ReadAllText(path);
                
                // Verificar se o arquivo está vazio
                if (text == null || text.Length == 0)
                {
                    Console.WriteLine("O arquivo está vazio.");
                    Environment.Exit(1);
                }

                // Remover comentários
                const string regex = @"(@(?:""[^""]*"")+|""(?:[^""\n\\]+|\\.)*""|'(?:[^'\n\\]+|\\.)*')|//.*|/\*(?s:.*?)\*/";
                text = Regex.Replace(text, regex, "$1");

                // Verificar se o arquivo possui a função principal
                if (!text.Contains("iniciar") || !text.Contains("terminar"))
                {
                    Console.WriteLine("O arquivo não contém a função principal.\nAdicione 'iniciar' e 'terminar' ao código-fonte.");
                    Environment.Exit(1);
                }

                // Guadar nome do arquivo
                string filename = Path.GetFileNameWithoutExtension(path);

                // Criar arquivo que receberá o código C++
                if (System.OperatingSystem.IsLinux())
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
                text = text.Replace("iniciar",   "int main(void) {");
                text = text.Replace("terminar",  "}");
                text = text.Replace("inteiro",   "int");
                text = text.Replace("real",      "float");
                text = text.Replace("vazio",     "void");
                text = text.Replace("caractere", "char");
                text = text.Replace("escrever",  "cout <<");
                text = text.Replace("leia",      "cin >>");
                text = text.Replace("para",      "for");
                text = text.Replace("enquanto",  "while");
                text = text.Replace("faca",      "do");
                text = text.Replace("se",        "if");
                text = text.Replace("senao",     "else");
                text = text.Replace("escolha",   "switch");
                text = text.Replace("caso",      "case");
                text = text.Replace("outrocaso", "default");
                text = text.Replace("retornar",  "return");
                text = text.Replace("pausar",    "break");
                text = text.Replace("continuar", "continue");
                text = text.Replace("sistema",   "system");

                // Escrever no novo arquivo
                File.WriteAllText(path, text);
                
                // Compilar usando o Clang
                if (System.OperatingSystem.IsLinux())
                {
                    // Linux
                    ProcessStartInfo startInfo = new ProcessStartInfo() { FileName = "clang++", Arguments = "-O2 -pipe -Wall -Wextra " + path + " -o " + filename };
                    Process proc = new Process() { StartInfo = startInfo };
                    proc.Start();
                    proc.WaitForExit();
                    Environment.Exit(proc.ExitCode);
                }
                else
                {
                    // Windows
                    ProcessStartInfo startInfo = new ProcessStartInfo() { FileName = "cmd.exe", Arguments = "/C clang++ -O2 -pipe -Wall -Wextra " + path + " -o " + filename + ".exe" };
                    Process proc = new Process() { StartInfo = startInfo };
                    proc.Start();
                    proc.WaitForExit();
                    Environment.Exit(proc.ExitCode);
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
