// Copyright (c) 1ukidev <leo.monteiro06@live.com>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.IO;

namespace Portuguei
{
    class Program
    {
        static void Main(string[] file)
        {
            // Guardar o caminho do arquivo que foi passado como argumento
            string path = Path.GetFullPath(file[0]);
 
            // Verificar se o arquivo é valido
            if(File.Exists(file[0]))
            {
                // Ler o código
                string text = File.ReadAllText(path);

                // Guadar nome do arquivo
                string filename = Path.GetFileNameWithoutExtension(path);

                // Criar arquivo que receberá o código C++
                path = Path.GetDirectoryName(path) + @"\\" + filename + ".cpp";

                // Inserir código C++ necessário
                text = text.Insert(0, "#include <iostream>\n#include <stdlib.h>\n\nusing namespace std;\n\n");

                // Substituir o código pelo equivalente em C++
                text = text.Replace("iniciar", "int main(void) {");
                text = text.Replace("inteiro", "int");
                text = text.Replace("real", "float");
                text = text.Replace("vazio", "void");
                text = text.Replace("escreva", "cout <<");
                text = text.Replace("leia", "cin >>");
                text = text.Replace("terminar", "}");
                text = text.Replace("retornar", "return");
                text = text.Replace("sistema", "system");

                // Escrever no novo arquivo
                File.WriteAllText(path, text);
                
                // Abrir o CMD e compilar usando GCC
                string compile = "/C g++ -Ofast -pipe " + path + " -o " + filename + ".exe";
                System.Diagnostics.Process.Start("cmd.exe", compile);
            }
            else
            {
                Console.WriteLine("Arquivo não encontrado.\n");
            }
        }
    }
}
