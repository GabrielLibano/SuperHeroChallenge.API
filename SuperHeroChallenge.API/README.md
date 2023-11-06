# SuperHeroChallenge.API

Esse projeto foi feito para o processo seletivo da vetera. Que esse processo consistia em:
- Desenvolver o Font End (Angular) e Back End (.NET Core), usando a API da Marvel.
- No back end, fiz o padrão DDD. Meu projeto ficou bem facil de dar manutenção e escalonar ele.
- Estruturei o projeto em pastas e aplicações, sendo elas, Aplication, Domain, Services, Infra e ACL. Assim, fica mais facil de dar manutenção e compreender o código.

- Tenho a controller que tem um metodo GET, que pega pela URI o nome do personagem digitado no frontend, passa pela camada de Services que vai para a camada de ACL aonde eu posso me conectar externamente com a API da Marvel.
- Faço outra chamada para pegar os eventos daquele personagem pelo ID dele.
- retorno isso, e vai passando pelas camadas novamente até chegar na controller. Envio isso para o front end, e la exibo na tela as informações passadas.
