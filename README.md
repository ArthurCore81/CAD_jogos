# CadJogosWF

Sistema desktop para **cadastro e gerenciamento de jogos**, desenvolvido em **C# com Windows Forms**, utilizando **SQL Server** como banco de dados.

O projeto foi desenvolvido com finalidade acadêmica, aplicando conceitos de programação orientada a objetos, desenvolvimento de interfaces gráficas e integração de uma aplicação C# com banco de dados relacional.

## Sobre o projeto

O **CadJogosWF** é uma aplicação desktop que permite realizar operações de cadastro e gerenciamento de jogos armazenados em um banco de dados SQL Server.

A aplicação utiliza uma organização baseada em:

- Interface gráfica com Windows Forms;
- Model para representação dos dados;
- DAO (Data Access Object) para acesso ao banco;
- Classe auxiliar para execução dos comandos SQL;
- SQL Server para persistência dos dados.

O projeto foi desenvolvido utilizando o **Visual Studio** e **.NET Framework 4.8**.

## Funcionalidades

O sistema possui operações de CRUD (**Create, Read, Update e Delete**) para os jogos cadastrados.

### Operações disponíveis

- **Inserir** um novo jogo;
- **Consultar** um jogo pelo ID;
- **Alterar** os dados de um jogo;
- **Deletar** um jogo pelo ID;
- **Listar** os jogos cadastrados;
- Exibir os resultados em uma `DataGridView`.

### Informações dos jogos

Cada registro trabalha com informações como:

| Campo | Tipo |
|---|---|
| ID | `int` |
| Nome | `string` |
| Valor | `float` |
| Data | `DateTime` |
| ID da Categoria | `int` |

## Tecnologias utilizadas

- **C#**
- **.NET Framework 4.8**
- **Windows Forms**
- **SQL Server**
- **ADO.NET**
- **Visual Studio**

## Estrutura do projeto

```text
CadJogosWF/
│
├── DAO/
│   ├── ConexaoBD.cs
│   ├── HelperDAO.cs
│   └── JogosDAO.cs
│
├── Model/
│   └── JogosViewModel.cs
│
├── Properties/
│   ├── AssemblyInfo.cs
│   ├── Resources.Designer.cs
│   ├── Resources.resx
│   ├── Settings.Designer.cs
│   └── Settings.settings
│
├── Form1.cs
├── Form1.Designer.cs
├── Form1.resx
├── Program.cs
├── App.config
└── CadJogosWF.csproj
```

## Organização do código

### `Form1.cs`

É responsável pela interface gráfica e pelo tratamento dos eventos dos botões.

Através da tela principal, o usuário consegue realizar as operações de:

- Inserção;
- Consulta;
- Alteração;
- Exclusão;
- Listagem.

Os dados informados na interface são utilizados para criar os objetos do modelo e realizar as operações através da camada DAO.

### `Model/JogosViewModel.cs`

Representa os dados de um jogo dentro da aplicação.

A classe possui propriedades para armazenar:

```text
ID
Nome
Valor
Data
ID da Categoria
```

### `DAO/ConexaoBD.cs`

Responsável por estabelecer a conexão entre a aplicação e o SQL Server.

A configuração utilizada no projeto é direcionada a um ambiente **local de desenvolvimento**, utilizando o servidor `LOCALHOST` e o banco `jogosDB`.

As credenciais presentes no projeto (`sa` / `123456`) são utilizadas apenas como configuração do ambiente local utilizado durante o desenvolvimento acadêmico.

> **Observação:** essas credenciais não devem ser reutilizadas em ambientes de produção ou servidores reais. Em aplicações reais, recomenda-se utilizar configurações externas, variáveis de ambiente ou outros mecanismos apropriados para armazenamento de credenciais.

### `DAO/HelperDAO.cs`

Contém métodos auxiliares utilizados para executar comandos SQL e consultas ao banco de dados.

A classe auxilia o restante da aplicação na comunicação com o SQL Server, utilizando parâmetros nas operações que recebem dados do usuário.

### `DAO/JogosDAO.cs`

É responsável pelas operações relacionadas aos jogos no banco de dados.

Entre as operações implementadas estão:

```text
Inserir()
Alterar()
Deletar()
Consulta()
Listagem()
```

Também é responsável por transformar os dados retornados pelo banco em objetos `JogosViewModel`.

## Banco de dados

O projeto utiliza o banco de dados:

```text
jogosDB
```

A aplicação trabalha com uma tabela de jogos utilizada pelas operações de CRUD.

Os principais dados utilizados pelo sistema são:

```text
ID
Nome
Valor
Data
ID da Categoria
```

### Configuração local

A conexão do projeto foi desenvolvida considerando um SQL Server instalado localmente:

```text
Servidor: LOCALHOST
Banco de dados: jogosDB
Usuário: sa
Senha: 123456
```

Essa configuração faz parte do ambiente de desenvolvimento utilizado no projeto acadêmico.

Caso o SQL Server do usuário utilize configurações diferentes, será necessário ajustar a conexão utilizada pela aplicação.

> O projeto disponibilizado não possui um script SQL separado para criação e configuração completa do banco de dados. Portanto, o banco `jogosDB` e a estrutura necessária para a aplicação devem estar configurados antes da execução.

## Como executar

### Pré-requisitos

Para executar o projeto, é necessário possuir:

- Windows;
- Visual Studio;
- .NET Framework 4.8;
- SQL Server;
- SQL Server Management Studio ou ferramenta equivalente;
- Banco de dados `jogosDB` configurado.

### 1. Clone o repositório

```bash
git clone <URL_DO_REPOSITORIO>
```

### 2. Abra a solução

Abra o arquivo:

```text
CadJogosWF.sln
```

no Visual Studio.

### 3. Configure o banco de dados

Certifique-se de que o SQL Server esteja em execução e que o banco:

```text
jogosDB
```

esteja disponível.

Também é necessário que a tabela utilizada pela aplicação esteja criada com uma estrutura compatível com as operações realizadas pelo projeto.

### 4. Verifique a conexão

A configuração da conexão pode ser encontrada na camada:

```text
DAO/ConexaoBD.cs
```

Caso o ambiente local utilize outro servidor, usuário, senha ou banco de dados, ajuste essas informações.

### 5. Execute a aplicação

No Visual Studio, compile a solução e execute o projeto utilizando:

```text
F5
```

ou o botão **Start**.

## Fluxo da aplicação

A comunicação entre a interface e o banco segue uma estrutura semelhante a:

```text
┌──────────────────────┐
│       Usuário        │
└──────────┬───────────┘
           │
           ▼
┌──────────────────────┐
│      Windows Forms   │
│        (Form1)       │
└──────────┬───────────┘
           │
           ▼
┌──────────────────────┐
│   JogosViewModel     │
└──────────┬───────────┘
           │
           ▼
┌──────────────────────┐
│       JogosDAO       │
└──────────┬───────────┘
           │
           ▼
┌──────────────────────┐
│      HelperDAO       │
└──────────┬───────────┘
           │
           ▼
┌──────────────────────┐
│      ConexaoBD       │
└──────────┬───────────┘
           │
           ▼
┌──────────────────────┐
│      SQL Server      │
└──────────────────────┘
```

Essa organização separa a interface gráfica da lógica responsável pelo acesso aos dados.

## Operações CRUD

### Inserção

O usuário informa os dados do jogo e seleciona a opção de inserção.

```text
Form1
  ↓
JogosViewModel
  ↓
JogosDAO
  ↓
SQL Server
```

### Consulta

O ID informado pelo usuário é utilizado para localizar um registro específico no banco de dados.

Quando encontrado, seus dados podem ser apresentados novamente na interface.

### Alteração

Através do ID, o sistema localiza o registro e permite atualizar suas informações.

### Exclusão

O ID é utilizado para localizar o jogo que deverá ser removido do banco de dados.

### Listagem

A aplicação consulta os registros armazenados e apresenta os resultados em uma `DataGridView`.

## Tratamento de erros

As operações realizadas pela interface possuem tratamento de exceções.

Quando uma operação encontra algum problema, uma mensagem é apresentada ao usuário por meio de `MessageBox`.

Isso permite evitar que erros durante a execução encerrem inesperadamente a aplicação.

## Objetivo acadêmico

O projeto foi desenvolvido como parte do processo de aprendizado em desenvolvimento de aplicações com **C#**, com foco na integração entre uma aplicação desktop e um banco de dados SQL Server.

Entre os conceitos aplicados estão:

- Programação Orientada a Objetos;
- Windows Forms;
- Modelos de dados;
- DAO;
- ADO.NET;
- Comandos SQL;
- CRUD;
- Conexão com banco de dados;
- Tratamento de exceções;
- Manipulação de componentes de interface.

## Possíveis melhorias

Como evolução futura do projeto, algumas melhorias podem ser implementadas:

- Separar as credenciais do banco do código-fonte;
- Utilizar um arquivo de configuração para a conexão;
- Criar um script SQL para instalação do banco;
- Melhorar a validação dos campos;
- Adicionar gerenciamento de categorias;
- Implementar pesquisa por nome;
- Melhorar a apresentação das mensagens de erro;
- Adicionar confirmação antes da exclusão;
- Utilizar `decimal` para valores monetários;
- Implementar testes automatizados;
- Melhorar a organização e reutilização da interface.

## Status

**Projeto acadêmico concluído.**

O código disponibilizado representa a versão desenvolvida durante o processo de aprendizagem e pode ser utilizado como base para futuras melhorias e refatorações.

## Autor

**Arthur Carvalho**

Projeto desenvolvido para fins acadêmicos e de estudo em **C#, Windows Forms e integração com SQL Server**.
