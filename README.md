# API de Listagem de Fornecedores e Empresas 📊

Esta API foi desenvolvida para fornecer listagens de fornecedores e empresas, permitindo consultas relacionadas entre essas entidades. Feita em .NET 8.0, ela utiliza Entity Framework para manipulação de dados, FluentValidation para validações e AutoMapper para mapeamento entre DTOs e entidades. Esta API é projetada para ser consumida pelo frontend desenvolvido em Angular.

## 🔗 Link para o Frontend

O frontend pode ser encontrado em: [ListaFornecedorEmpresa - FrontEnd](https://github.com/DaviJedrzejczyk/ListaFornecedorEmpresa-FrontEnd/tree/71fb49bb85f849f2364df41d72cd59dbba9684d6)

## 📌 Funcionalidades da API

- **Listagem de Fornecedores e Empresas**: Obtenha informações detalhadas de fornecedores e empresas, com dados relacionados.
- **Relacionamento entre Entidades**: Realiza consultas cruzadas entre fornecedores e empresas para visualização das relações.
- **Validação de Dados**: Utilização de FluentValidation para garantir que os dados recebidos estejam corretos.
- **Mapeamento de Objetos**: AutoMapper para conversão rápida entre modelos e DTOs.

## ⚙️ Tecnologias Utilizadas

- **.NET 8.0**: Framework principal para desenvolvimento da API.
- **Entity Framework**: ORM utilizado para interação com o banco de dados.
- **FluentValidation**: Biblioteca de validação para garantir a integridade dos dados.
- **AutoMapper**: Facilita o mapeamento entre entidades e DTOs, melhorando a organização do código.

## 📂 Estrutura do Projeto

- **Controllers**: Gerencia os endpoints da API para interação com fornecedores e empresas.
- **Services**: Contém a lógica de negócios e manipulação de dados.
- **DTOs (Data Transfer Objects)**: Estruturas de dados para transferência de informações entre a API e o cliente.
- **Mappers**: Configurações do AutoMapper para realizar as conversões entre modelos e DTOs.
- **Validations**: Classes para validação dos dados usando FluentValidation.

## 🚀 Como Executar o Projeto

### Pré-requisitos

- .NET 8.0 SDK
- Banco de dados configurado (pode ser ajustado nas configurações do `appsettings.json`)

### Passo a Passo

1. **Clone o repositório**:
   ```bash
   git clone https://github.com/SeuUsuario/NomeDoRepositorio.git
   cd NomeDoRepositorio
   ```

2. **Configurar o banco de dados**:
   - Defina a string de conexão no arquivo `appsettings.json`.
   - Execute as migrações com o Entity Framework:
     ```bash
     dotnet ef database update
     ```

3. **Executar a API**:
   ```bash
   dotnet run
   ```
   A API estará disponível em `http://localhost:5000`.

## 📈 Endpoints Principais

- **GET /api/fornecedores**: Retorna a lista de fornecedores.
- **GET /api/empresas**: Retorna a lista de empresas.
- **GET /api/fornecedores/{id}/empresas**: Lista as empresas relacionadas a um fornecedor específico.

## ✅ Validação e Mapeamento

- **FluentValidation**: Utilizado para garantir a qualidade dos dados enviados à API, oferecendo feedback claro para o cliente em caso de erro.
- **AutoMapper**: Simplifica a conversão de objetos para manter a API organizada e eficiente, reduzindo o esforço de mapeamento manual.

## 👤 Contato

Desenvolvido por [Davi Jedrzejczyk](https://www.linkedin.com/in/davi-jedrzejczyk-03b22a245/). Conecte-se comigo no LinkedIn para trocar ideias sobre desenvolvimento .NET e tecnologias associadas!

---

Essa API foi criada para aprendizado e serve como uma base robusta para projetos futuros que envolvam a listagem e gestão de dados relacionados entre entidades.
