 
APi simples com Asp Net core feita a partir da documentação da microsoft. 
    link: https://docs.microsoft.com/pt-br/learn/modules/build-web-api-aspnet-core/1-introduction


 Chamadas HTTP - 

    GetAll - 
        Responde apenas ao verbo HTTP GET, conforme indicado pelo atributo [HttpGet].
        Consulta o serviço para todas as pizzas e retorna automaticamente os dados com um Content-Type igual a application/json.

    Get by Id - 
        Responde apenas ao verbo HTTP GET, conforme indicado pelo atributo [HttpGet].
        Requer que o valor do parâmetro id seja incluído no segmento da URL após produto/. Lembre-se, o padrão /produto foi definido pelo atributo [Route] do nível do controlador.
        Consulta o banco de dados para um produto que corresponda ao parâmetro id fornecido.

    POST - 
        O atributo [HttpPost] mapeará solicitações HTTP POST enviadas para http://localhost:5000/produto para o método Create(). Em vez de retornar uma lista de produtos, como vimos com o método Get(), esse método retornará uma resposta IActionResult, que informará ao cliente se a solicitação teve êxito e a ID do produto recém-criada. Isso é feito usando códigos de status HTTP padrão, portanto, a integração com os clientes é fácil, independentemente da linguagem ou da plataforma em que estão sendo executados.

        CreatedAtAction	201	
            O produto foi adicionada ao cache na memória.
            O prodto está incluída no corpo da resposta no tipo de mídia, conforme definido no cabeçalho da solicitação HTTP accept (JSON por padrão).
        BadRequest está implícito 
            400	O objeto produto do corpo da solicitação é inválido.


    PUT - 
        Cada ActionResult usado na ação anterior é mapeado para o código de status HTTP correspondente na tabela a seguir.

        NoContent	204	
            O produto foi atualizada no cache na memória.
        BadRequest	400	
            O valor Id do corpo da solicitação não corresponde ao valor id da rota.
        BadRequest está implícito	400	
            O objeto Produto do corpo da solicitação é inválido.

    DELETE - 
        NoContent	204	
            O produto foi excluída do cache na memória.
        NotFound	404	
            Um produto que corresponde ao parâmetro id fornecido não existe na memória.