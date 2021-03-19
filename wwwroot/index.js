// Получение всех пользователей
async function GetItems() {
    // отправляет запрос и получаем ответ
    const response = await fetch("/api/items", {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    // если запрос прошел нормально
    if (response.ok === true) {
        // получаем данные
        const items = await response.json();
        let rows = document.querySelector("tbody");

        items.forEach(item => {
            // добавляем полученные элементы в таблицу
            rows.append(row(item));
        });
    }
}
async function sortbyParameter(sortingParameter) {
    const response = await fetch("/api/items/" + sortingParameter, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    // если запрос прошел нормально
    if (response.ok === true) {
        // получаем данные
        const items = await response.json();
        
        $("tbody").children().remove();
        //location.reload();
        let rows = document.querySelector("tbody");
        items.forEach(item => {
            // добавляем полученные элементы в таблицу
            rows.append(row(item));
        });      
    }
}
function row(item) {

    const tr = document.createElement("tr");
    tr.setAttribute("data-rowid", item.id);

    const nameTd = document.createElement("td");
    nameTd.append(item.name);
    tr.append(nameTd);

    const priceTd = document.createElement("td");
    priceTd.append(item.price);
    tr.append(priceTd);

    return tr;
}
GetItems();