# CrudTesteSoftware

* Crud simples prevendo um relacionamento de Pessoa com Endereço

* Na entidade de Endereço quando é incluído um CEP ele vai buscar o resto do endereço numa API pública que contém os dados

* Não há nenhum tipo de validação dos dados intencionalmente para ser testado depois

* Um caso de teste legal seria um endereço com CEP inválido com os dados da pessoa corretos para tentar causar uma possível inconsistência de dados no banco
