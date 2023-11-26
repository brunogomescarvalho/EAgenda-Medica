
# Aplica��o Web para Gerenciamento de Atividades M�dicas

## Descri��o
Esta aplica��o web foi desenvolvida para possibilitar que usu�rios de cl�nicas m�dicas realizem agendamentos, altera��es e exclus�es de atividades m�dicas. Al�m disso, ela oferece a funcionalidade de verificar conflitos entre atividades agendadas pelo mesmo m�dico, al�m de gerar relat�rios com os 10 m�dicos que mais horas trabalharam dentro de um per�odo espec�fico.

## Tecnologias Utilizadas
### Frontend:
- Angular ^16.2.0
- Angular Material ^16.2.12
- Bootstrap ^5.3.2

### Backend:
- ASP.NET Core 6.0
- Entity Framework Core 6.0.22
- AutoMapper 12.0.1
- FluentValidation 11.8.0
- Serilog

## Instala��o
Para instalar e configurar a aplica��o em seu ambiente local, siga as instru��es abaixo:

### Pr�-requisitos
Certifique-se de ter as seguintes ferramentas instaladas em sua m�quina:
- Node.js
- Angular CLI
- ASP.NET Core SDK
- Banco de dados compat�vel com o Entity Framework Core

### Passos de Instala��o
1. Clone o reposit�rio para sua m�quina local.
   ```bash
   git clone https://github.com/brunogomescarvalho/EAgenda-Medica.git
   ```
2. Acesse o diret�rio do frontend e instale as depend�ncias.
```bash
cd nome-do-repositorio/frontend
```
```bash
npm install
```
3. Acesse o diret�rio do backend e restaure os pacotes NuGet.
```bash
cd ../backend
```
```bash
dotnet restore
```
4. Aplique as migra��es para criar o esquema do banco de dados.
```bash
dotnet ef database update
```
5. Inicie a aplica��o backend.
```bash
dotnet run
```
6. Em outra janela do terminal (cmd ou gitbash), inicie a aplica��o frontend.
```bash
cd ../frontend
```
```bash
ng serve
```
Abra o navegador e acesse http://localhost:4200 para usar a aplica��o.

# Funcionalidades

## M�dulo Cirurgia e Consulta
Consultas
Agendamento de consultas m�dicas.
Altera��o de hor�rios para consultas existentes.
Exclus�o de consultas agendadas.
Cirurgias
Agendamento de cirurgias m�dicas.
Altera��o de hor�rios para cirurgias existentes.
Exclus�o de cirurgias agendadas.
Verifica��o de Conflitos
O sistema realiza automaticamente a verifica��o de conflitos entre consultas e cirurgias agendadas pelo mesmo m�dico, garantindo uma gest�o eficiente do tempo m�dico.

## M�dulo M�dico
Inser��o e Edi��o
Adi��o de novos m�dicos com informa��es detalhadas.
Edi��o de informa��es de m�dicos existentes.
Exclus�o e Desativa��o
Remo��o de m�dicos do sistema.
Desativa��o tempor�ria de m�dicos.
Filtragem por CRM
Filtragem r�pida e eficiente de m�dicos utilizando o n�mero de CRM.
Funcionalidades Adicionais
Relat�rios
Gera��o de relat�rios com os 10 m�dicos que mais horas trabalharam dentro de um per�odo espec�fico.

## Vis�o Geral 
A aplica��o oferece uma experi�ncia abrangente e f�cil de usar para a gest�o eficiente das atividades m�dicas, dividindo-as em m�dulos espec�ficos para consultas, cirurgias e m�dicos.

## Testes
A aplica��o possui testes de unidades, servi�os e dom�nio, al�m de testes de integra��o com o banco de dados.

Para executar os testes:

### Camada de Dom�nio
Navegue at� a pasta
```bash
/backend/EAgendaUnitTests
```
Execute o comando
```bash
dotnet test
```

 ### Camada de Aplica��o
 Navegue at� a pasta
```bash
/backend/EAgendaMedica.AplicacaoUnitTests
```
Execute o comando
```bash
dotnet test
```

### Camada de infra
 Navegue at� a pasta
```bash
/backend/EAgendaMedica.TestesIntegracao
```
Execute o comando
```bash
dotnet test
```

