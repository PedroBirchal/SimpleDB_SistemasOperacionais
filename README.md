# SimpleD_SistemasOperacionais
 
    O banco de dados deve ser utilizado atraves do console juntamente da estrutura de comando ("dotnet run {comando} {argumento 1} {argumento 2}").

    COMANDOS:

    -cache-size {size} {policy} : instancia um novo banco de dados de tamanho size, que utiliza a politica {policy}
    --insert {key} {value} : insere um novo objeto no banco de dados com a chave {key} e valor {value}
    --remove {key} : remove objeto do banco de dados correspondente a chave {key}
    --search {key} : procura se existe um objeto com chave {key} no banco de dados
    --update {key} {value} : procura um objeto no banco de dados com a chave {key} e altera seu valor para {value}

    OBS:
        - O banco de dados não pode ter capacidade negativa e sua policy deve ser ou "fifo" ou "lru"
        - Chaves informadas não podem ser valores negativos
        - Caso existam chaves duplicadas no banco de dados, o metodo de pesquisa sempre retornara o primeiro na listagem
