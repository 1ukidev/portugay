# Portuguei
Uma cópia barata do Portugol para fins educacionais.<br>
Desenvolvido em C# usando .NET Core.

O código ainda é bem simples, não leve o projeto a sério.

### Funcionamento:
O programa recebe o texto, traduz para C++ e por fim compila usando GCC.

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
.\<arquivo>.exe
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
