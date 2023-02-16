var requestProduct;
var cardElement;
var index = 1;
var totalPagina;

var requestMenu;
var sideMenuElement;

GetMenuData();
GetProductData()

async function GetProductData() {
    requestProduct = await GetData(`produtos?NumeroPagina=${index}&ResultadosExibidos=6`);
    totalPagina = requestProduct.resultado.dados.totalPaginas;
    let productList = requestProduct.resultado.pagina;
    console.log(productList);
    CreateCard(productList);
}

async function GetMenuData() {
    requestMenu = await GetData(`categorias`);
    let menuList = requestMenu.resultado.pagina;
    CreatMenu(menuList);
}

function menu() {
    document.getElementById('mobile').classList.toggle('active')
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
            menu += `<li><a id="${menuElement.id}">${menuElement.nome}</a>` + submenus;
        } else {
            menu += `<li><a id="${menuElement.id}">${menuElement.nome}</a>`;
        }
    });

    menu += `</li>`
    sideMenuElement.innerHTML = menu;
}


function CreateCard(result) {
    cardElement = document.getElementById("list-cards");

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