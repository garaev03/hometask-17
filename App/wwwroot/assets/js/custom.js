const loadMore = document.querySelector(".loadMore")
let skip = 3
let take = 2
let listCount = 0

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
            addtocartbutton = document.querySelectorAll(".ProductAddToCart")
            ClickedAddToCart()
            //
            if (listCount < skip + take) {
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

//add to cart button and getting id
function ClickedAddToCart() {
    for (let i = 0; i < addtocartbutton.length; i++) {
        addtocartbutton[i].addEventListener("click", () => {
            var id = $(".ProductAddToCart").eq(i).data("id")
            console.log($(addtocartbutton[i]).data("id"));
            console.log(id);
            fetch("/Cart/AddToCart?id=" + id)
                .then(resp => resp.text())
                .then(text => {
                    console.log(text);
                    if (text == "false") {
                        window.location.href = "/Error/Error404"
                    }
                    else {
                        $(".alerts").append('<div class="alert alert-success alert-dismissible fade show d-flex justify-content-between pe-2" style="width:30rem;" role="alert"> <span class="pt-2">Item Added Succesfully!</span><button betype="button" class="btn" data-bs-dismiss="alert" aria-lal="Close">X</button></div>')
                        var alert = $(".alert")
                        for (let i = 0; i < alert.length; i++) {
                            setTimeout(() => {
                                alert[i].remove()
                            }, 5000);
                        }
                    }
                })
        })
    }
}

ClickedAddToCart()
//


