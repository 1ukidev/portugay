# Portuguei
Uma cópia do Portugol para fins educacionais.<br>
Desenvolvido em C# usando .NET Core.

O código ainda é simples, não leve o projeto a sério.

### Funcionamento:
O programa recebe o texto, traduz para C++ em um novo arquivo e por fim compila usando GCC.

---

Exemplo de código:
```
iniciar
    escreva << "Hello, World!\n";
terminar
```

Usar o programa para traduzir e compilar:
```
.\portuguei.exe <arquivo>
```

Agora basta executar o binário gerado:
```
.\<nome do arquivo>.exe
```

Saída:
```
Hello, World!
```

O arquivo com código traduzido ficará em ``<nome do arquivo>.cpp``

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
