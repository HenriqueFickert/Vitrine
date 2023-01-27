var request;
var cardElement;
var index = 1;
var totalPagina;

GetProductData()

async function GetProductData() {
    request = await GetData(`produtos?NumeroPagina=${index}&ResultadosExibidos=6`);
    totalPagina = request.dados.dados.totalPaginas;
    let productList = request.dados.pagina;
    CreateCard(productList);
}

function CreateCard(result) {
    cardElement = document.getElementById("list-cards");

    result.forEach(element => {
        cardElement.innerHTML += `<li id ="${element.id}"class="card">
        <div class="card__image"></div>
        <div class="card__text">
            <h2 class="card__text-titulo">${element.nome}</h2>
            <p class="card__text-descricao">At vero eos et accusamus et iusto odio
                dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos
                dolores et quas.</p>
            <p class="card__text-quantidade">Qnt: ${element.quantidade}</p>
            <h3 class="card__text-valor">R$ ${element.valor}</h3>
        </div>
        </li>`;
    });
}

function ShowMore() {
    index < totalPagina ? (index++, GetProductData(), index == totalPagina ? document.getElementById("btnShowMore").disabled = true : false) : false
}