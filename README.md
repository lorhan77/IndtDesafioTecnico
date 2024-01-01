"# IndtDesafioTecnico" 

## Introdução

Esta documentação fornece informações detalhadas sobre a API de Usuários da aplicação, destacando os endpoints disponíveis, os métodos de requisição e as respostas esperadas. A API é desenvolvida em .NET Core 8.0 então (verifique se o seu ambiente também está na mesma versão) e permite a realização de operações CRUD (Create, Read, Update, Delete) relacionadas aos usuários.

### Execução Local

Primeiramente configure a string de conexão com o MySqlServer nos arquivos `Program.cs` e `appsettings.Development.json`. 

Para executar a API localmente, siga os passos abaixo:

1. Abra um terminal.
3. Digite `dotnet restore` para instalar as dependências do NuGet. 
4. Navegue até o diretório do projeto `IndtApi`.
5. Execute o comando `dotnet run`.
6. Para gerar a Migration digite no terminal o seguinte comando : `Add-Migration Init`
7. Após gerar a Migartion usaremos o comando `Update-Database Init ` no terminal para atualizar uma tabela existente num banco de dados SQL existente.
8. Acesse a API em [http://127.0.0.1:5004](http://127.0.0.1:5004) ou [http://127.0.0.1:719](http://127.0.0.1:7193).

## Endpoints

### 1. Listar Todos os Usuários

- **Método HTTP:** GET
- **Rota:** `/usuarios`
- **Descrição:** Retorna a lista de todos os usuários.
- **Resposta de Exemplo:**
```json
[
  {
    "Id": 1,
    "Nome": "John",
    "Sobrenome": "Doe",
    "Email": "john.doe@example.com",
    "Senha": "hashed_password",
    "NivelDeAcesso": administrador | comum
  },
  // ...
]
```

### 2. Obter Usuário por ID

- **Método HTTP:** GET
- **Rota:** `/usuarios/{id}`
- **Descrição:** Retorna os detalhes de um usuário específico.
- **Resposta de Exemplo:**
```json
{
  "Id": 1,
  "Nome": "John",
  "Sobrenome": "Doe",
  "Email": "john.doe@example.com",
  "Senha": "hashed_password",
  "NivelDeAcesso": administrador | comum
}
```

### 3. Criar Usuário

- **Método HTTP:** POST
- **Rota:** `/usuarios`
- **Descrição:** Cria um novo usuário.
- **Corpo da Requisição (Exemplo):**
```json
{
  "Nome": "Jane",
  "Sobrenome": "Doe",
  "Email": "jane.doe@example.com",
  "Senha": "hashed_password",
  "NivelDeAcesso": administrador | comum
}
```
- **Resposta de Exemplo:**
```json
{
  "Id": 2,
  "Nome": "Jane",
  "Sobrenome": "Doe",
  "Email": "jane.doe@example.com",
  "Senha": "hashed_password",
  "NivelDeAcesso": administrador | comum
}
```

### 4. Atualizar Usuário por ID

- **Método HTTP:** PUT
- **Rota:** `/usuarios/{id}`
- **Descrição:** Atualiza os detalhes de um usuário existente.
- **Corpo da Requisição (Exemplo):**
```json
{
  "Nome": "Updated",
  "Sobrenome": "User",
  "Email": "updated.user@example.com",
  "Senha": "new_hashed_password",
  "NivelDeAcesso": administrador | comum
}
```
- **Resposta de Sucesso:** 204 No Content

### 5. Excluir Usuário por ID

- **Método HTTP:** DELETE
- **Rota:** `/usuarios/{id}`
- **Descrição:** Exclui um usuário por ID.
- **Resposta de Sucesso:**
```json
{
  "Id": 2,
  "Nome": "Jane",
  "Sobrenome": "Doe",
  "Email": "jane.doe@example.com",
  "Senha": "hashed_password",
  "NivelDeAcesso": administrador | comum
}
```

## Validações e Filtros

A API utiliza filtros para realizar validações em diversas etapas do processamento:

- Filtro de validação de ID de Usuário.
- Filtro de validação durante a criação de Usuários.
- Filtro de validação durante a atualização de Usuários.
- Filtro de exceções durante a atualização de Usuários.

## Exemplos de Uso

A seguir estão alguns exemplos de como utilizar os endpoints da API.

### Listar Todos os Usuários

```bash
curl http://127.0.0.1:5004/usuarios
```

### Obter Usuário por ID

```bash
curl http://127.0.0.1:5004/usuarios/1
```

### Criar Usuário

```bash
curl -X POST -H "Content-Type: application/json" -d '{"Nome": "Jane", "Sobrenome": "Doe", "Email": "jane.doe@example.com", "Senha": "hashed_password", "NivelDeAcesso": administrador | comum}' http://127.0.0.1:5004/usuarios
```

### Atualizar Usuário por ID

```bash
curl -X PUT -H "Content-Type: application/json" -d '{"Nome": "Updated", "Sobrenome": "User", "Email": "updated.user@example.com", "Senha": "new_hashed_password", "NivelDeAcesso": administrador | comum}' http://127.0.0.1:5004/usuarios/2
```

### Excluir Usuário por ID

```bash
curl -X DELETE http://127.0.0.1:5004/usuarios/2
```

## Referências

- [.NET Core Documentation](https://docs.microsoft.com/en-us/dotnet/)
- [Microsoft.AspNetCore.Mvc Namespace](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc)
