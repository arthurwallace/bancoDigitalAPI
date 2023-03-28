# Banco Digital API

API desenvolvida em .NET 6 com GraphQL para simular operações bancárias como saque, depósito e consulta de saldo.

## Requisitos

- .NET 6 SDK ou superior
- PostgreSQL

## Configuração

1. Clone o repositório
2. Configure a string de conexão com o banco de dados em `appsettings.json`
3. Execute o comando `dotnet ef database update` para criar as tabelas no banco de dados.

## Execução

Para executar a API, execute o comando `dotnet run` na pasta raiz do projeto.

A API estará disponível em `http://localhost:5000/graphql`.

## Operações

A API permite as seguintes operações:

- `saque`: realiza o saque de um valor da conta informada. Retorna o saldo atualizado ou uma mensagem de erro caso o saque não seja possível.
- `deposito`: realiza o depósito de um valor na conta informada. Retorna o saldo atualizado.
- `saldo`: consulta o saldo atual da conta informada.

## Exemplo de uso

### Saque

Para realizar um saque, envie uma mutação com a operação `saque`, informando o número da conta e o valor a ser sacado:

```
mutation {
saque(numeroConta: 12345, valor: 50) {
saldo
}
}
```


### Depósito

Para realizar um depósito, envie uma mutação com a operação `deposito`, informando o número da conta e o valor a ser depositado:

```
mutation {
deposito(numeroConta: 12345, valor: 100) {
saldo
}
}
```


### Saldo

Para consultar o saldo de uma conta, envie uma query com a operação `saldo`, informando o número da conta:

```
query {
saldo(numeroConta: 12345)
}
```

