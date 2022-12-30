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
//add to cart button and getting id
 function ClickedAddToCart() {
    for (let i = 0; i < addtocartbutton.length; i++) {
        addtocartbutton[i].addEventListener("click", () => {
            var id=$(".ProductAddToCart").eq(i).data("id")
            fetch("/Cart/AddToCart?id="+id)
            .then(resp=> resp.text())
            .then(text=>{
                console.log(text);
                if(text=="false"){
                    window.location.href="/Error/Error404"
                }
                else{
                    var myAlert=document.querySelector(".alerts").style.display="block"
                    console.log(myAlert);
                }
            })
        })
    }
}

ClickedAddToCart()
//


