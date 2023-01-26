var apiUrl = `http://fickert.cloud/v1/`

function GetData(route) {
    return new Promise((resolve, reject) => {
        const xhttp = new XMLHttpRequest();

        xhttp.onload = function () {
            resolve(JSON.parse(this.responseText));
        }

        xhttp.onerror = function () {
            reject();
        }

        xhttp.open("GET", apiUrl + route);
        xhttp.send();
    })
}