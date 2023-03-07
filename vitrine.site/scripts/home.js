//Cards de Produto
var productRequest;
var cardElement = document.getElementById("list-cards");
var index = 1;
var totalPages;

//Menu de Busca Lateral
var requestMenu;
var sideMenuElement = document.getElementById("menu-busca__list");
var lastClicked = "";

//Buscar
var searchInput = document.getElementById("buscar-input");

GetMenuData();
GetProductData()
searchInput.addEventListener("keyup", function () {
    GetSearchProducts(searchInput.value)
})

function ToogleSideMenuBuscaButton() {
    document.getElementById('sideMenuBusca').classList.toggle('active')
}

async function GetProductData() {
    productRequest = await GetData(`produtos?NumeroPagina=${index}&ResultadosExibidos=6`);
    totalPages = productRequest.resultado.dados.totalPaginas;
    let productList = productRequest.resultado.pagina;

    CreateCard(productList);

    if (index == totalPages)
        document.getElementById("btnShowMore").disabled = true
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
    index < totalPages ? (index++, GetProductData(), index == totalPages ? document.getElementById("btnShowMore").disabled = true : false) : false
}

async function GetMenuData() {
    requestMenu = await GetData(`categorias`);
    let menuList = requestMenu.resultado.pagina;
    CreatMenu(menuList);
}
function CreatMenu(result) {

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

    sideMenuElement.innerHTML += menu;
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

async function GetSearchProducts(params) {
    productRequest = await GetData(`produtos?PalavraChave=${params}`);
    cardElement.innerHTML = "";

    if (!productRequest.sucesso) {
        cardElement.innerHTML += `<h5 class="mensagem-erro-buscar">${productRequest.erros[0]}</h5>`
    } else {
        totalPages = productRequest.resultado.dados.totalPaginas;
        let productList = productRequest.resultado.pagina;
        CreateCard(productList);
    }
}