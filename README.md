# LarApi

Uma API que permite criar, listar, buscar, editar e excluir: usuários; pessoas e seus telefones.

## Tecnologias Utilizadas

- **.Net:** Plataforma de desenvolvimento.
- **PostGreSQL:** Banco de dados SQL.
- **Entity Framework:** Mapeamento objeto-relacional.
- **.Docker:** Conteiners.
- **Swagger-OpenAPI:** Biblioteca utilizada para documentar a API, documentação disponível na rota /swagger/index.html.

## Como usar a API

Para utilizar esta API, você precisará de um cliente HTTP como Postman ou Insomnia para fazer as requisições, mas pode ser utilizada a documentação do swagger/openAPI também.

## Endpoints

Uma documentação detalhada consta na própria API na rota:

```sh
http://localhost:8080/swagger/index.html
```
## Executando o projeto

Faça um clone deste repositório e instale no seu ambiente de desenvolvimento utilizando o seguinte comando no seu terminal (escolha um diretório apropriado):

```shell
git clone git@github.com:guilhermemon18/lar-api.git
```

Após clonar o conteúdo do repositório, acesse o diretório "Backend.Api e execute os comandos abaixo:

```shell
dotnet restore
docker-compose up --build
```

Após a execução do comando acima o servidor estará em execução no endereço `http://localhost:8080`, com a possibilidade de ser testado diretamente em `http://localhost:8080/swagger/index.html`

## Usuário Administrador pré-configurado

Para utilizar as rotas que exigem autorização,  é necessário fazer o sigin  na rota `http://localhost:8080/api/users/signin`, utilizando as seguintes credenciais no corpo de requisição:

```shell
{
  "email": "admin@exemplo.com",
  "password": "admin123"
}
```
Em seguida, utilizar o bearer token recebido como resposta para fazer a autorização no swagger ou inserir no Headers a chave Authorization com o Bearer Token da seguinte forma:
```shell
{
  Key: "Authorization",
  Value: "Bearer {token}"
}
```
