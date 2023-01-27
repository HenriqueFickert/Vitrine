var request;
var cardElement;
var index = 1;
var totalPagina;

GetProductData()

async function GetProductData() {
    request = await GetData(`produtos?NumeroPagina=${index}&ResultadosExibidos=5`);
    totalPagina = request.dados.dados.totalPaginas;
    let productList = request.dados.pagina;
    CreateCard(productList);
}

function CreateCard(result) {
    cardElement = document.getElementById("list-cards");

    result.forEach(element => {
        cardElement.innerHTML += `<li id ="${element.id}"class="list__cards__card">
        <div class="list__cards__card__image"></div>
        <div class="list__cards__card__text">
            <h2 class="list__cards__card__text__titulo">${element.nome}</h2>
            <p class="list__cards__card__text__descricao">At vero eos et accusamus et iusto odio
                dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos
                dolores et quas.</p>
            <p class="list__cards__card__text__quantidade">Qnt: ${element.quantidade}</p>
            <h3 class="list__cards__card__text__valor">R$ ${element.valor}</h3>
        </div>
        </li>`;
    });
}

function ShowMore() {
    index < totalPagina ? (index++, GetProductData(), index == totalPagina ? document.getElementById("btnShowMore").disabled = true : false) : false
}