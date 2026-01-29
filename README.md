# Cadastro de Super-Heróis

Sistema full-stack para gerenciamento de super-heróis e seus superpoderes, desenvolvido com .NET 10 no backend e Angular 21 no frontend.

## Sobre o Projeto

Este projeto é uma aplicação completa de CRUD (Create, Read, Update, Delete) para cadastro de super-heróis, permitindo associar múltiplos superpoderes a cada herói. A aplicação foi desenvolvida seguindo os princípios de Clean Architecture e boas práticas de desenvolvimento.

### Funcionalidades

- ✅ Cadastro, edição, visualização e exclusão de super-heróis
- ✅ Gerenciamento de superpoderes
- ✅ Associação de múltiplos superpoderes a cada herói
- ✅ Validação de dados no frontend e backend
- ✅ Interface moderna e responsiva
- ✅ API RESTful documentada com Swagger

---

## Backend (.NET 10)

### Estrutura do Backend

```
SuperHero/
├── Domain/                     
│   ├── Entities/                    
│   │   ├── Heroi.cs
│   │   ├── Superpoder.cs
│   │   ├── HeroiSuperpoder.cs
│   │   └── BaseEntity.cs
│   ├── Interfaces/                  
│   │   ├── IHeroiRepository.cs
│   │   ├── ISuperoderRepository.cs
│   │   └── IBaseRepository.cs
│   └── Exceptions/                 
│       ├── BusinessException.cs
│       └── NotFoundException.cs
│
├── ApplicationService/              
│   ├── Services/                    
│   │   ├── HeroiService.cs
│   │   └── SuperpoderService.cs
│   ├── Interfaces/                  
│   │   ├── IHeroiService.cs
│   │   └── ISuperoderService.cs
│   ├── Dtos/                        
│   │   ├── HeroiDto.cs
│   │   ├── SuperpoderDto.cs
│   │   └── HeroiSuperoderDto.cs
│   ├── Mappings/                    
│   │   ├── HeroiMapping.cs
│   │   └── SuperpoderMapping.cs
│   └── Common/                      
│       └── Result.cs
│
├── Infrastructure/                  
│   ├── Data/                        
│   │   ├── AppDbContext.cs
│   │   ├── Configurations/
│   │   └── Migrations/
│   └── Repository/                  
│       ├── HeroiRepository.cs
│       ├── SuperpoderRepository.cs
│       └── BaseRepository.cs
│
├── WebApi/                          
│   ├── Controllers/                 
│   │   ├── HeroisController.cs
│   │   └── SuperpoderesController.cs
│   ├── Middlewares/                 
│   │   └── ExceptionMiddleware.cs
│   ├── Program.cs                   
│   ├── appsettings.json            
│   └── Dockerfile                   
│
└── Shema-DataBase-Super-Heroi.sql  # Script do banco de dados
```

### Tecnologias Utilizadas (Backend)

- **.NET 10** - Framework principal
- **ASP.NET Core Web API** - Criação da API RESTful
- **Entity Framework Core** - ORM para acesso ao banco de dados
- **SQL Server** - Banco de dados relacional
- **Swagger/OpenAPI** - Documentação da API
- **Mapperly** - Mapeamento objeto-objeto (source generator)
- **FluentValidation** - Validação de dados

### Arquitetura

O backend segue os princípios de **Clean Architecture**, dividido em camadas:

- **Domain**: Contém as entidades de negócio e interfaces de repositórios
- **ApplicationService**: Lógica de aplicação, DTOs e serviços
- **Infrastructure**: Implementação de repositórios e acesso a dados
- **WebApi**: Camada de apresentação (Controllers e Middlewares)

---

## Frontend (Angular 21)

### Estrutura do Frontend

```
SuperHero-UI/
├── src/
│   ├── app/
│   │   ├── Components/
│   │   │   ├── counter/
│   │   │   ├── error-display/
│   │   │   ├── footer/
│   │   │   ├── header/
│   │   │   ├── hero-card/
│   │   │   └── loader/
│   │   │
│   │   ├── Pages/
│   │   │   ├── home/
│   │   │   ├── layout/
│   │   │   ├── heroi/
│   │   │   ├── cadastro-heroi/
│   │   │   └── editar-heroi/
│   │   │
│   │   ├── Core/
│   │   │   ├── Service/
│   │   │   │   ├── heroi.service.ts
│   │   │   │   ├── superpoder.service.ts
│   │   │   │   └── error-handler.service.ts
│   │   │   └── Interfaces/
│   │   │       ├── IHeroi.ts
│   │   │       ├── ISuperpoder.ts
│   │   │       └── IApiError.ts
│   │   │
│   │   ├── app.routes.ts
│   │   ├── app.config.ts
│   │   ├── app.config.server.ts
│   │   ├── app.routes.server.ts
│   │   └── app.ts
│   │
│   ├── styles.scss
│   ├── index.html
│   ├── main.ts
│   ├── main.server.ts
│   └── server.ts
│
├── public/
├── angular.json
├── package.json
├── tsconfig.json
└── tsconfig.app.json
```

### Tecnologias Utilizadas (Frontend)

- **Angular 21** - Framework frontend
- **TypeScript 5.9** - Linguagem de programação
- **SCSS** - Pré-processador CSS
- **RxJS 7.8** - Programação reativa
- **Angular Router** - Roteamento
- **Angular Forms** - Formulários reativos
- **Angular SSR** - Server-Side Rendering

---

## Como Rodar o Projeto

### Pré-requisitos

- **.NET 10 SDK** - [Download](https://dotnet.microsoft.com/download/dotnet/10.0)
- **Node.js 20+** e **npm 11+** - [Download](https://nodejs.org/)
- **SQL Server** (LocalDB ou Express) - [Download](https://www.microsoft.com/sql-server/sql-server-downloads)
- **Visual Studio 2022** ou **VS Code** (opcional)

### Configuração do Banco de Dados

1. **Criar o banco de dados:**
   ```bash
   # Execute o script SQL localizado em:
   SuperHero/Shema-DataBase-Super-Heroi.sql
   ```

2. **Configurar a connection string:**
   - Edite o arquivo `SuperHero/WebApi/appsettings.json`
   - Atualize a connection string com suas credenciais:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=SEU_SERVIDOR;Database=Desafio_Trainee_Viceri;Trusted_Connection=True;TrustServerCertificate=True;"
     }
   }
   ```

### Executando o Backend

1. **Navegue até a pasta do backend:**
   ```bash
   cd SuperHero/WebApi
   ```

2. **Restaure as dependências:**
   ```bash
   dotnet restore
   ```

3. **Execute a aplicação:**
   ```bash
   dotnet run
   ```

4. **Acesse a API:**
   - API: `https://localhost:7176`
   - Swagger: `https://localhost:7176/swagger`

### Executando o Frontend

1. **Navegue até a pasta do frontend:**
   ```bash
   cd SuperHero-UI
   ```

2. **Instale as dependências:**
   ```bash
   npm install
   ```

3. **Execute a aplicação:**
   ```bash
   npm start
   ```
   ou
   ```bash
   ng serve
   ```

4. **Acesse a aplicação:**
   - Frontend: `http://localhost:4200`

### Configuração da API no Frontend

O frontend está configurado para se conectar à API em `https://localhost:7176`. Se necessário, altere a URL base no arquivo de configuração dos serviços.

---

## Endpoints da API

### Heróis (`/api/Herois`)
- `GET /api/Herois` - Lista todos os heróis
- `GET /api/Herois/{id}` - Busca um herói específico por ID
- `POST /api/Herois` - Cria um novo herói
- `PUT /api/Herois/{id}` - Atualiza um herói existente
- `DELETE /api/Herois/{id}` - Remove um herói

### Superpoderes (`/api/Superpoderes`)
- `GET /api/Superpoderes` - Lista todos os superpoderes disponíveis

## Desenvolvedor

Desenvolvido por **Augusto**

---

## Licença

Este projeto foi desenvolvido para fins educacionais e de demonstração de habilidades técnicas.
