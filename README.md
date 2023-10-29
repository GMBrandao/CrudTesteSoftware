# CrudTesteSoftware

* Crud simples prevendo um relacionamento de Pessoa com Endereço

* Na entidade de Endereço quando é incluído um CEP ele vai buscar o resto do endereço numa API pública que contém os dados

* Não há nenhum tipo de validação dos dados intencionalmente para ser testado depois

* Um caso de teste legal seria um endereço com CEP inválido com os dados da pessoa corretos para tentar causar uma possível inconsistência de dados no banco
  
* Para acessar rapidamente e testar rode a aplicaçao e faça as requisições via Postman

Abra o Postman e aperte "Import" e inisira o link abaixo
https://api.postman.com/collections/28726049-0fc0c7ca-3326-470d-87d4-b1dc88252267?access_key=PMAT-01HDYRHZN64Q3K7G60SQ6W7M1V
