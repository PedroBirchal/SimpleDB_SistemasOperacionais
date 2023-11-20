# SimpleD_SistemasOperacionais
 SimpleDb
Trabalho de SO

Compilado no .Net 7

Recebe apenas um input por iteração

Inputs possiveis: -cache-size {tamanho} {policy(valores possiveis:fifo,lru)}
                  --insert {chave de valor inteiro} {valor string}
                  --remove {chave do obj a ser removido}
                  --update {chave do valor a ser alterado}
                  --search {chave do valor buscado}

Exemplos: -cache-size 10 fifo 
          --insert 10 pedro
          --remove 10
          --update 10 luana
          --search 10
          
 
