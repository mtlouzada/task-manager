
# Desafio Técnico - API de Gerenciamento de Animes Favoritos (Nível Estagiário Java)

## Objetivo do Desafio
Construa uma API RESTful simples chamada **MyAnimeList-Pessoal**, onde o usuário pode cadastrar e gerenciar seus animes favoritos.

É um desafio 100% focado em fundamentos de Java + REST, com complexidade ideal para estagiário ou pessoa desenvolvedora júnior em início de carreira.

## Endpoints Obrigatórios

| Método | Endpoint               | Descrição                                                  | Status Sucesso       | Status Erro         |
|--------|------------------------|------------------------------------------------------------|----------------------|---------------------|
| POST   | `/animes`              | Cadastra um novo anime                                     | 201 Created          | 400 Bad Request     |
| GET    | `/animes`              | Lista todos os animes cadastrados                          | 200 OK               | -                   |
| GET    | `/animes/{id}`         | Busca um anime específico pelo ID                          | 200 OK               | 404 Not Found       |
| PUT    | `/animes/{id}`         | Atualiza informações de um anime existente                 | 200 OK               | 404 Not Found       |
| DELETE | `/animes/{id}`         | Remove um anime da lista                                   | 204 No Content       | 404 Not Found       |

### Exemplo de corpo JSON (POST e PUT)

```json
{
  "titulo": "Jujutsu Kaisen",
  "genero": "Shounen",
  "anoLancamento": 2020,
  "estudio": "MAPPA",
  "notaPessoal": 9.5,
  "assistido": true
}
```

O campo `id` (Long) deve ser gerado automaticamente pela aplicação.

## Requisitos Técnicos (mesmos do desafio anterior)

- .NET 8 ou superior
- ASP.NET - MVC
- Armazenamento em memória (Dictionary<TKey, TValue> e List<T>)
- Tudo em JSON
- Sem autenticação
- Código limpo e bem organizado

## Estrutura Sugerida

```
src/main/dotnet/com.seunome.myanimelist/
├── model/
│   └── Anime.cs
├── service/
│   └── AnimeService.cs
├── controller/
│   └── AnimeController.cs
└── MyAnimeListApplication.cs
```

## Exemplo de testes com curl

```bash
# Cadastrar
curl -X POST http://localhost:8080/animes -H "Content-Type: application/json" -d '{
  "titulo":"Chainsaw Man","genero":"Shounen","anoLancamento":2022,"estudio":"MAPPA","notaPessoal":9.8,"assistido":false
}'

# Listar tudo
curl http://localhost:8080/animes

# Buscar um específico
curl http://localhost:8080/animes/1

# Marcar como assistido + mudar nota
curl -X PUT http://localhost:8080/animes/1 -H "Content-Type: application/json" -d '{
  "notaPessoal":10.0, "assistido":true
}'

# Remover
curl -X DELETE http://localhost:8080/animes/1
```

## O que será avaliado (exatamente o mesmo do desafio anterior)

- Todos os 5 endpoints funcionando corretamente
- Códigos HTTP corretos (201, 200, 204, 404)
- Tratamento de anime não encontrado (404)
- Separação clara entre model / service / controller
- Código limpo, legível e comentado
- Geração automática de ID

## Bônus (opcionais - diferenciam o candidato)

- Persistência em arquivo JSON ou SQLite
- Validação (ex: nota entre 0 e 10, título obrigatório)
- Filtro GET `/animes?assistido=true` ou `/animes?genero=Shounen`
- Testes unitários/integração
- Swagger/OpenAPI
- Criar Views

## Entrega

- Repositório Git público
- README.md com instruções claras de como rodar
- Commits organizados

**Divirta-se construindo sua própria MyAnimeList!**  
Boa sorte e que venha o 10/10!
```

