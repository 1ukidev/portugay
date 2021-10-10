// Copyright (c) 1ukidev <leo.monteiro06@live.com>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.IO;

namespace PseudoCode
{
    class Program
    {
        static void Main(string[] file)
        {
            // Pegar o caminho do arquivo
            string path = Path.GetFullPath(file[0]);
 
            if(path == null)
            {
                // Ler o código
                string text = File.ReadAllText(path);
                // Inserir código necessário no arquivo
                text = text.Insert(0, "#include <iostream>\n#include <stdlib.h>\n\nusing namespace std;\n\n");

                // Substituir o código pelo equivalente em C++
                text = text.Replace("iniciar", "int main(void) {");
                text = text.Replace("inteiro", "int");
                text = text.Replace("real", "float");
                text = text.Replace("vazio", "void");
                text = text.Replace("escreva", "cout");
                text = text.Replace("leia", "cin");
                text = text.Replace("terminar", "}");
                text = text.Replace("retornar", "return");
                text = text.Replace("sistema", "system");

                // Escrever no arquivo
                File.WriteAllText(path, text);

                // Abrir o CMD e compilar usando GCC
                string compile = "/C g++ -x c++ -Ofast " + path + " -o resultado.exe";
                System.Diagnostics.Process.Start("CMD.exe", compile);
            }
            else
            {
                Console.WriteLine("Tem algo errado.\n");
            }
        }
    }
}
