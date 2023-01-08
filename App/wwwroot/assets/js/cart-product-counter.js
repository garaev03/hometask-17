function GetDefaultPrice(count, price) {
    return price / count
}

function Change(ProductCounterDiv, count, price, defaultPrice, id, PlusMinus) {
    setTimeout(() => {
        fetch("/Cart/Edit/" + id + "?count=" + count)
            .then(resp => resp.text())
            .then(text => {
                if (text == "false") {
                    window.location.href = "/Error/Error404"
                }
                else {
                    // ProductCounterDiv.children[3].innerHTML="<span><i class='bx bx-check-circle bx-sm p-2 mt-1 text-success'></i></span>"
                    // setTimeout(() => {
                    let TotalPrice = document.querySelector(".totalprice")
                    let newPrice = count * defaultPrice
                    let newTotalPrice=0
                    if(PlusMinus==true){
                        newTotalPrice = parseInt(TotalPrice.innerHTML) + defaultPrice
                    }
                    else{
                        newTotalPrice = parseInt(TotalPrice.innerHTML) - defaultPrice
                    }
                    price.innerHTML = newPrice + "$"
                    TotalPrice.innerHTML = newTotalPrice + "$"
                    //     ProductCounterDiv.children[3].innerHTML=""
                    // }, 1000);
                }
            })
    }, 0);
}

