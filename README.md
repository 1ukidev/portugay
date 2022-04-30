# Portugay
Um programa inspirado no Portugol para fins educacionais.<br>
Desenvolvido em C# usando .NET Core.<br>
Atualmente funciona no Linux e Windows.

**O código está em desenvolvimento! Várias mudanças podem ocorrer. Não leve o projeto a sério.**

---

### Funcionamento:
O programa recebe o texto, traduz para C++ em um novo arquivo e por fim compila usando o Clang.

---

Exemplo de código:
```
iniciar
    escrever "Hello, World!\n";
terminar
```

Usar o programa para traduzir e compilar (necessário ter o Clang instalado):
```
.\Portugay.exe <arquivo>
```

Agora basta executar o binário gerado:
```
.\<nome do arquivo>.exe
```

Saída:
```
Hello, World!
```

---

No Linux:
```
./Portugay <arquivo>
./<nome do arquivo>
```

---

O arquivo com código traduzido ficará salvo em ``<nome do arquivo>.cpp``

---

| Palavras-chave disponíveis | Equivalente em C++            |
| -------------------------- | ----------------------------- |
| ``iniciar``                | ``int main(void) {``          |
| ``terminar``               | ``}``                         |
| ``inteiro``                | ``int``                       |
| ``real``                   | ``float``                     |
| ``vazio``                  | ``void``                      |
| ``caractere``              | ``char``                      |
| ``escrever``               | ``cout <<`` ``(iostream)``    |
| ``leia``                   | ``cin >>`` ``(iostream)``     |
| ``para``                   | ``for``                       |
| ``enquanto``               | ``while``                     |
| ``faca``                   | ``do``                        |
| ``se``                     | ``if``                        |
| ``senao``                  | ``else``                      |
| ``escolha``                | ``switch``                    |
| ``caso``                   | ``case``                      |
| ``outrocaso``              | ``default``                   |
| ``retornar``               | ``return``                    |
| ``pausar``                 | ``break``                     |
| ``continuar``              | ``continue``                  |
| ``sistema``                | ``system`` ``(stdlib.h)``     |

**Em breve mais palavras-chave...**

---

### Como compilar o projeto:
- Certifique-se de ter instalado o .NET SDK

Abra um terminal e clone este repositório (necessário ter o git instalado):
```
git clone https://github.com/1ukidev/portugay
```

Entre dentro do diretório ``Portugay`` e execute:
```
dotnet build
```

Se quiser atualizar o código-fonte para o commit mais recente, execute:
```
git pull
```
