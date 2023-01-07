let ProductPriceField = document.querySelectorAll(".ProductPrice")
let ProductPrices = []

function GetProductPrices() {
    ProductPriceField.forEach(price => {
        let count = price.parentElement.parentElement.children[3].children[0].children[1].getAttribute("value");
        let productPrice = parseInt(price.innerHTML) / count
        ProductPrices.push(productPrice)
    })
}
GetProductPrices()

function ChangeProductPriceField() {
    for (let i = 0; i < ProductPriceField.length; i++) {
        let count = ProductPriceField[i].parentElement.parentElement.children[3].children[0].children[1].getAttribute("value");
        let newPrice = count * ProductPrices[i]
        ProductPriceField[i].innerHTML = newPrice + "$"
        let id=ProductPriceField[i].parentElement.parentElement.children[2].children[0].getAttribute("data-id") 
        fetch("/Cart/Edit/" + id + "?count=" + count)
            .then(resp => resp.text())
            .then(text => {
                if (text == "false") {
                    window.location.href = "/Error/Error404"
                }
            })
    }
}
