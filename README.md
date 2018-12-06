# Desafio FullStack TOTVS

Esse repositório tem como objetivo a disponibilização da minha solução proposta para o desafio.

Essa solução deve abrangir:

# Recursos:
- CRUD de Usuário (api/user)
- CRUD de Leilão (api/audiction)
- CRUD de Lances de Leilões (api/audictionbid)

# Telas:
- Login/Logout
- Cadastro Usuário
- Cadastro de Leilão
- Listagem de leilões
- Cadastro de lance para leilão
- Listagem de lances para um leilão

# Funcionalidades
- Validação de CPF 
- Excluir usuário (Desativar usuário)
- Validação da exclusão de leilões (leilões que já possuem lances não poderão ser excluídos)
- Validação de lance (Não poderá ser criados novos lances para leilões finalizados)
- Validação de valor de lance (Valor do lance não poderá ser inferior ao último lance atual)

# Restrições de acesso
- Somente usuários administradores poderão acessar o cadastro de leilões
- Nenhum serviço pode ser acessado após o logout da aplicação