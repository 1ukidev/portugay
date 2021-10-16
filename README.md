# Portuguei
Um programa inspirado no Portugol para fins educacionais.<br>
Desenvolvido em C# usando .NET Core.<br>
Funciona no Linux e Windows.

O código ainda é simples, não leve o projeto a sério.

### Funcionamento:
O programa recebe o texto, traduz para C++ em um novo arquivo e por fim compila usando GCC.

---

Exemplo de código:
```
iniciar
    escreva "Hello, World!\n";
terminar
```

Usar o programa para traduzir e compilar:
```
.\Portuguei.exe <arquivo>
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
./Portuguei <arquivo>
./<nome do arquivo>
```

---

O arquivo com código traduzido ficará salvo em ``<nome do arquivo>.cpp``

---

| Comandos disponíveis | Equivalente em C++            |
| -------------------  | ----------------------------- |
| `iniciar`            | `int main(void) {`            |
| `inteiro`            | `int`                         |
| `real`               | `float`                       |
| `vazio`              | `void`                        |
| `escreva`            | `cout <<`                     |
| `leia`               | `cin >>`                      |
| `terminar`           | `}`                           |
| `retornar`           | `return`                      |
| `sistema()`          | `system()`                    |

---

### Como compilar o projeto:
- Certifique-se de ter instalado o .NET SDK

Abra um terminal e clone este repositório:
```
git clone https://github.com/1ukidev/portuguei
```

Entre dentro do diretório ``Portuguei`` e execute:
```
dotnet build
```

Para atualizar o código-fonte para o commit mais recente:
```
git pull
```
