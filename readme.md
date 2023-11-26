
# Aplicação Web para Gerenciamento de Atividades Médicas

## Descrição
Esta aplicação web foi desenvolvida para possibilitar que usuários de clínicas médicas realizem agendamentos, alterações e exclusões de atividades médicas. Além disso, ela oferece a funcionalidade de verificar conflitos entre atividades agendadas pelo mesmo médico, além de gerar relatórios com os 10 médicos que mais horas trabalharam dentro de um período específico.

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

## Instalação
Para instalar e configurar a aplicação em seu ambiente local, siga as instruções abaixo:

### Pré-requisitos
Certifique-se de ter as seguintes ferramentas instaladas em sua máquina:
- Node.js
- Angular CLI
- ASP.NET Core SDK
- Banco de dados compatível com o Entity Framework Core

### Passos de Instalação
1. Clone o repositório para sua máquina local.
   ```bash
   git clone https://github.com/brunogomescarvalho/EAgenda-Medica.git
   ```
2. Acesse o diretório do frontend e instale as dependências.
```bash
cd nome-do-repositorio/frontend
```
```bash
npm install
```
3. Acesse o diretório do backend e restaure os pacotes NuGet.
```bash
cd ../backend
```
```bash
dotnet restore
```
4. Aplique as migrações para criar o esquema do banco de dados.
```bash
dotnet ef database update
```
5. Inicie a aplicação backend.
```bash
dotnet run
```
6. Em outra janela do terminal (cmd ou gitbash), inicie a aplicação frontend.
```bash
cd ../frontend
```
```bash
ng serve
```
Abra o navegador e acesse http://localhost:4200 para usar a aplicação.

# Funcionalidades

## Módulo Cirurgia e Consulta
Consultas
Agendamento de consultas médicas.
Alteração de horários para consultas existentes.
Exclusão de consultas agendadas.
Cirurgias
Agendamento de cirurgias médicas.
Alteração de horários para cirurgias existentes.
Exclusão de cirurgias agendadas.
Verificação de Conflitos
O sistema realiza automaticamente a verificação de conflitos entre consultas e cirurgias agendadas pelo mesmo médico, garantindo uma gestão eficiente do tempo médico.

## Módulo Médico
Inserção e Edição
Adição de novos médicos com informações detalhadas.
Edição de informações de médicos existentes.
Exclusão e Desativação
Remoção de médicos do sistema.
Desativação temporária de médicos.
Filtragem por CRM
Filtragem rápida e eficiente de médicos utilizando o número de CRM.
Funcionalidades Adicionais
Relatórios
Geração de relatórios com os 10 médicos que mais horas trabalharam dentro de um período específico.

## Visão Geral 
A aplicação oferece uma experiência abrangente e fácil de usar para a gestão eficiente das atividades médicas, dividindo-as em módulos específicos para consultas, cirurgias e médicos.

## Testes
A aplicação possui testes de unidades, serviços e domínio, além de testes de integração com o banco de dados.

Para executar os testes:

### Camada de Domínio
Navegue até a pasta
```bash
/backend/EAgendaUnitTests
```
Execute o comando
```bash
dotnet test
```

 ### Camada de Aplicação
 Navegue até a pasta
```bash
/backend/EAgendaMedica.AplicacaoUnitTests
```
Execute o comando
```bash
dotnet test
```

### Camada de infra
 Navegue até a pasta
```bash
/backend/EAgendaMedica.TestesIntegracao
```
Execute o comando
```bash
dotnet test
```

