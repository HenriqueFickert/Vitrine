var request;
var cardElement;
var index = 1;
var totalPagina;

GetProductData()

async function GetProductData() {
    request = await GetData(`produtos?NumeroPagina=${index}&ResultadosExibidos=6`);
    totalPagina = request.resultado.dados.totalPaginas;
    let productList = request.resultado.pagina;
    console.log(productList);
    CreateCard(productList);
}

function CreateCard(result) {
    cardElement = document.getElementById("list-cards");

    result.forEach(element => {
        cardElement.innerHTML += `<li id ="${element.id}"class="card">
        <div class="card__image"><img class="product_image" src="${element.caminhoAbsoluto}"></div>
        <div class="card__texts">
            <h2 class="card__text-titulo">${element.nome}</h2>
            <p class="card__text-descricao">${element.descricao}</p>
            <p class="card__text-quantidade">Qnt: ${element.quantidade}</p>
            <h3 class="card__text-valor">R$ ${element.valor}</h3>
        </div>
        </li>`;
    });
}

function ShowMore() {
    index < totalPagina ? (index++, GetProductData(), index == totalPagina ? document.getElementById("btnShowMore").disabled = true : false) : false
}