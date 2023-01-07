let PlusProduct = document.querySelectorAll(".PlusProduct")
let MinusProduct = document.querySelectorAll(".MinusProduct")

function ProductCounters(MinusProduct,PlusProduct) {
    PlusProduct.forEach(btn => btn.addEventListener("mouseover", () => {
        btn.parentElement.children[1].setAttribute("class", "PlusProductCounter text-center text-light bg-success")
    }))

    PlusProduct.forEach(btn => btn.addEventListener("mouseout", () => {
        btn.parentElement.children[1].setAttribute("class", "ProductCounter text-center text-light bg-success")
    }))

    MinusProduct.forEach(btn => btn.addEventListener("mouseover", () => {
        btn.parentElement.children[1].setAttribute("class", "MinusProductCounter text-center text-light bg-success")
    }))
    MinusProduct.forEach(btn => btn.addEventListener("mouseout", () => {
        btn.parentElement.children[1].setAttribute("class", "ProductCounter text-center text-light bg-success")
    }))

    PlusProduct.forEach(btn => btn.addEventListener("click", () => {
        var count = btn.parentElement.children[1].getAttribute("value")
        count++
        btn.parentElement.children[1].setAttribute("value", count)
        ChangeProductPriceField(count)
    }))

    MinusProduct.forEach(btn => btn.addEventListener("click", () => {
        var count = btn.parentElement.children[1].getAttribute("value")
        if (count > 1) {
            count--
            btn.parentElement.children[1].setAttribute("value", count)
        }
        ChangeProductPriceField(count)
    }))
}
ProductCounters(MinusProduct,PlusProduct)

