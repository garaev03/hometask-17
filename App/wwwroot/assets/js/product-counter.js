let PlusProduct = document.querySelectorAll(".PlusProduct")
let MinusProduct = document.querySelectorAll(".MinusProduct")

function ProductCounters(MinusProduct, PlusProduct) {
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
        if (btn.parentElement.getAttribute("class").includes("CartProductCounterDiv")){
            let price = btn.parentElement.parentElement.parentElement.children[4].children[0]
            let id = btn.parentElement.parentElement.parentElement.children[2].children[0].getAttribute("data-id")
            Change(btn.parentElement, count, price,GetDefaultPrice(count-1,parseInt(price.innerHTML)), id)
        }
    }))

    MinusProduct.forEach(btn => btn.addEventListener("click", () => {
        var count = btn.parentElement.children[1].getAttribute("value")
        if (count > 1) {
            count--
            btn.parentElement.children[1].setAttribute("value", count)
            if (btn.parentElement.getAttribute("class").includes("CartProductCounterDiv")) {
                let price = btn.parentElement.parentElement.parentElement.children[4].children[0]
                let id = btn.parentElement.parentElement.parentElement.children[2].children[0].getAttribute("data-id")
                Change(btn.parentElement, count, price,GetDefaultPrice(count+1,parseInt(price.innerHTML)), id)
            }
        }
    }))
}
ProductCounters(MinusProduct, PlusProduct)

