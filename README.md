# Banco Digital API

API desenvolvida em .NET 6 com GraphQL para simular operações bancárias como saque, depósito e consulta de saldo.

## Requisitos

- .NET 6 SDK ou superior

## Configuração

1. Clone o repositório
2. Configure a string de conexão com o banco de dados em `appsettings.json`
3. Execute o comando `dotnet ef database update` para criar as tabelas no banco de dados.

## Execução

Para executar a API, execute o comando `dotnet run` na pasta raiz do projeto.

A API estará disponível em `http://localhost:5000/graphql`.

## Operações

A API permite as seguintes operações:
- `criar`: cria uma nova conta.
- `sacar`: realiza o saque de um valor da conta informada. Retorna o saldo atualizado ou uma mensagem de erro caso o saque não seja possível.
- `depositar`: realiza o depósito de um valor na conta informada. Retorna o saldo atualizado.
- `conta`: consulta os dados atuais da conta informada.

## Exemplo de uso

### Criar Conta

Para criar uma nova conta, envie uma mutação com a operação `criar`

```
mutation criarConta {
  criar {
    id,
    numeroConta,
    saldo,
    movimentacoes {
      id
      valor
    }
  }
}
```


### Saque

Para realizar um saque, envie uma mutação com a operação `sacar`, informando o número da conta e o valor a ser sacado:

```
mutation sacar {
  sacar (numeroConta: 43027, valor: 2) {
    numeroConta
    saldo
  }
}
```


### Depósito

Para realizar um depósito, envie uma mutação com a operação `depositar`, informando o número da conta e o valor a ser depositado:

```
mutation depositar {
  depositar (numeroConta: 43027, valor: 200.50) {
    numeroConta
    saldo
  }
}
```


### Conta

Para consultar os dados de uma conta, envie uma query com a operação `conta`, informando o número da conta:

```
query conta {
  conta(numeroConta: 43027) {
    id
    numeroConta
    saldo
    movimentacoes {
      valor
      dataMovimentacao
      descricao
    }
  }
}
```

