# Portuguei
Uma cópia barata do Portugol para fins educacionais.<br>
Desenvolvido em C# usando .NET Core.

### Funcionamento:
O programa recebe o texto, traduz para C++ e por fim compila usando GCC.

---

Exemplo de código:
```
iniciar
    escreva << "Hello, World!\n";
terminar
```

Traduzir e compilar:
```
.\portuguei.exe <arquivo>
```

Executar:
```
.\resultado.exe
```

Saída:
```
Hello, World!
```

---

| Comandos disponíveis | Equivalente em C++            |
| -------------------  | ----------------------------- |
| `iniciar`            | `int main(void) {`            |
| `inteiro`            | `int`                         |
| `real`               | `float`                       |
| `vazio`              | `void`                        |
| `escreva <<`         | `cout <<`                     |
| `leia >>`            | `cin >>`                      |
| `terminar`           | `}`                           |
| `retornar`           | `return`                      |
| `sistema()`          | `system()`                    |
