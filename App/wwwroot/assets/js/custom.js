const loadMore = document.querySelector(".loadMore")
let skip = 3
let take = 3
let listCount = 0
let CalledOnce = false

////fetch("/Work/GetProductsCount")
////    .then(response => response.text())
////    .then(count => {
////        listCount = count
////    })  

//loadMore.addEventListener("click", () => {
//    fetch("/Work/LoadMore?skip=" + skip + "&take=" + take)
//        .then(response => response.text())
//        .then(text => {

//            $(".products").append(text)
//            skip += take
//        })
//    if (listCount <= skip + take) {
//        $(".loadMore").remove()
//    }
//})
let addtocartbutton = document.querySelectorAll(".ProductAddToCart")

listCount = $(".hiddenCount").val()
loadMore.addEventListener("click", () => {
    fetch("/Work/LoadMore?skip=" + skip + "&take=" + take)
        .then(response => response.text())
        .then(text => {
            $(".products").append(text)
            skip += take

            //refreshing add to cart buttons
            let newaddtocartbutton = []
            document.querySelectorAll(".ProductAddToCart")
                .forEach(btn => {
                    let exist = false
                    addtocartbutton.forEach(btn2 => {
                        if (btn2 == btn) {
                            exist = true
                        }
                    });
                    if (!exist) {
                        newaddtocartbutton.push(btn)
                    }
                })
            ClickedAddToCart(newaddtocartbutton)
            //

            //refreshing product counters  
            let newPlusProduct = []
            let newMinusProduct = []
            document.querySelectorAll(".PlusProduct")
                .forEach(btn => {
                    let exist = false
                    PlusProduct.forEach(btn2 => {
                        if (btn2 == btn) {
                            exist = true
                        }
                    });
                    if (!exist) {
                        newPlusProduct.push(btn)
                    }
                })
            document.querySelectorAll(".MinusProduct")
                .forEach(btn => {
                    let exist = false
                    MinusProduct.forEach(btn2 => {
                        if (btn2 == btn) {
                            exist = true
                        }
                    });
                    if (!exist) {
                        newMinusProduct.push(btn)
                    }
                })
            ProductCounters(newMinusProduct, newPlusProduct)
            //

            if (listCount <= skip ) {
                $(".loadMore").remove()
            }
        })
})

//
{/* <div class="alert alert-success alert-dismissible fade show d-flex justify-content-between pe-2" style="width:30rem;" role="alert">
    <span class="pt-2">Item Added Succesfully!</span>
    <button betype="button" class="btn" data-bs-dismiss="alert" aria-lal="Close">X</button>
</div> */}
//
// function getcount(){
//     console.log(document.querySelectorAll(".ProductAddToCart"));
//     return document.querySelectorAll(".ProductAddToCart")
// }
//add to cart button and getting id
function ClickedAddToCart(addtocartbutton) {
    for (let i = 0; i < addtocartbutton.length; i++) {
        addtocartbutton[i].addEventListener("click", () => {
            var id = addtocartbutton[i].getAttribute("data-id")
            var count = addtocartbutton[i].parentElement.children[0].children[1].getAttribute("value")
            console.log(id);
            console.log(count);
            fetch("/Cart/AddToCart/" + id + "?count=" + count)
                .then(resp => resp.text())
                .then(text => {
                    console.log(text);
                    var alert = $(".alert")
                    if (text == "false") {
                        $(".alerts").append('<div class="alert alert-danger alert-dismissible fade show d-flex justify-content-between pe-2" style="width:30rem;" role="alert"> <span class="pt-2">Failed To Add Item!</span><button betype="button" class="btn" data-bs-dismiss="alert" aria-lal="Close">X</button></div>')
                    }
                    else {
                        $(".alerts").append('<div class="alert alert-success alert-dismissible fade show d-flex justify-content-between pe-2" style="width:30rem;" role="alert"> <span class="pt-2">Item Added Succesfully!</span><button betype="button" class="btn" data-bs-dismiss="alert" aria-lal="Close">X</button></div>')
                    }
                    for (let i = 0; i < alert.length; i++) {
                        setTimeout(() => {
                            alert[i].remove()
                        }, 5000);
                    }
                })
        })
    }
}
//

ClickedAddToCart(addtocartbutton)

