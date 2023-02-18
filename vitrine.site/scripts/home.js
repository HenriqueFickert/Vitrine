var requestProduct;
var cardElement = document.getElementById("list-cards");
var index = 1;
var totalPagina;

var requestMenu;
var sideMenuElement;
var lastClicked = "";

var buscar = document.getElementById("buscar");

GetMenuData();
GetProductData()

async function GetProductData() {
    requestProduct = await GetData(`produtos?NumeroPagina=${index}&ResultadosExibidos=6`);
    totalPagina = requestProduct.resultado.dados.totalPaginas;
    let productList = requestProduct.resultado.pagina;

    CreateCard(productList);

    if (index == totalPagina)
        document.getElementById("btnShowMore").disabled = true

}

async function GetMenuData() {
    requestMenu = await GetData(`categorias`);
    let menuList = requestMenu.resultado.pagina;
    CreatMenu(menuList);
}

function ToogleSideMenuBuscaButton() {
    document.getElementById('sideMenuBusca').classList.toggle('active')
}

function CreatMenu(result) {
    sideMenuElement = document.getElementById("menu-busca__list");
    let menu = '';

    result.forEach(menuElement => {
        let submenus = `<ul class="submenu__list clearfix">`;

        if (menuElement.subCategorias != null) {
            menuElement.subCategorias?.forEach(submenuElement => {
                submenus += `<li>
                    <a id="${submenuElement.id}">${submenuElement.nome}</a>
                </li>`;
            });
            submenus += `</ul>`;
            menu += `<li id="${menuElement.id}-check"><a onclick="ShowSubMenuButtonResponsive(event)" id="${menuElement.id}">
            ${menuElement.nome}</a>` + submenus;
            menu += `</li> `
        } else {
            menu += `<li><a id="${menuElement.id}">${menuElement.nome}</a>`;
            menu += `</li>`
        }
    });
    sideMenuElement.innerHTML = menu;
}

function CreateCard(result) {

    result.forEach(element => {
        cardElement.innerHTML += `<li id ="${element.id}"class="card">
        <div class="card__image"><img class="product_image" src="${element.uploads[0].caminhoAbsoluto}"></div>
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

function ShowSubMenuButtonResponsive(event) {
    const elementos = document.querySelectorAll('.submenuvisible');
    elementos.forEach(function (elemento) {
        elemento.classList.remove('submenuvisible');
    });

    if (lastClicked != event.target.id) {
        document.getElementById(event.target.id + '-check').classList.add('submenuvisible')
        lastClicked = event.target.id;
    } else {
        document.getElementById(event.target.id + '-check').classList.remove('submenuvisible');
        lastClicked = "";
    }
}

buscar.addEventListener("keyup", function () {
    GetBuscarProdutos(buscar.value)
})

async function GetBuscarProdutos(params) {
    requisicaoProduto = await GetData(`produtos?PalavraChave=${params}`);
    cardElement.innerHTML = "";
    if (!requisicaoProduto.sucesso) {
        cardElement.innerHTML += `<h5 class="mensagem-erro-buscar">${requisicaoProduto.erros[0]}</h5>`
    } else {
        totalPagina = requisicaoProduto.resultado.dados.totalPaginas;
        let productList = requisicaoProduto.resultado.pagina;
        CreateCard(productList);
    }
}