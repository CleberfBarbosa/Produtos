O teste em questão foi aplicado em um processo seletivo na Isthmus Sistemas, uma empresa a qual eu já trabalho há 6 anos. Eu realizei sua implementação apenas como um exercicio pessoal.

Para rodar a aplicação você irá precisar ter o docker e docker compose instalado. Uma vez devidamente configurado e instalado, basta rodar o comando:
docker compose up -d

Dentro da raiz do reposistorio, onde está localizado o arquivo docker-compose.yml. 
Ele irá subir um Sql server, rodar migrations e adicionar uma coleção de produtos para carga de dados, o Sql server irá expor acesso externo pela porta padrão 1433 e a aplicação na porta 35456.

Para visualizar a aplicação basta acessar a url:
http://localhost:35456/swagger/index.html

Para parar toda a aplicação basta rodar o comando:
docker compose down
