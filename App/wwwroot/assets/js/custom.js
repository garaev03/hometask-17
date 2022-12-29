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

listCount = $(".hiddenCount").val()
loadMore.addEventListener("click", () => {
    fetch("/Work/LoadMore?skip=" + skip + "&take=" + take)
        .then(response => response.text())
        .then(text => {
            $(".products").append(text)
            skip += take
            if (listCount < skip+take) {
                $(".loadMore").remove()
            }
        })
})