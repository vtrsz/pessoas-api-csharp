# <p align="center">Pessoas API</p>

## Tecnologias Utilizadas:

- C#
- ASP.NET
- EF.CORE
- Docker
- OpenAPI Swagger

## Endpoints

<img src="https://i.imgur.com/WZpFndT.png" alt="Endpoints" style="align-items: center"/>

Link da documenta��o: http://localhost:5000/swagger/index.html
(em ambiente local utilizando a porta padr�o.)

## Rodar a aplica��o

1. #### Instalar Docker
   ###### <a href="https://www.docker.com/get-started/"> Docker Download</a>

2. #### Configurar .env caso ache necess�rio.

3. #### Iniciar o container
   Linux: `sudo docker-compose up -d` \
   Windows: `docker compose up -d`
   ###### Tenha certeza que ter� permiss�o para rodar o comando.


### Exemplo de requests:

##### /api/person POST:
```json
{
  "name": "John Doe",
  "birthDate": "1990-01-27",
  "addresses": [
    {
      "street": "Rua Nova",
      "number": "100",
      "city": "S�o Paulo",
      "state": "SP",
      "cep": "00000000",
      "main": true
    }
  ]
}
```
##### /address/ POST:
```json
{
  "street": "Rua Nova",
  "number": "100",
  "city": "S�o Paulo",
  "state": "SP",
  "cep": "00000000",
  "main": true,
  "personId": 1
}
```
(Para obter mais exemplos consultar a documenta��o do Swagger)


## Como rodar o projeto?

Ter a <a href="https://www.oracle.com/br/java/technologies/downloads/#java17">JDK 17</a> instalada na sua maquina e uma IDE de prefer�ncia.