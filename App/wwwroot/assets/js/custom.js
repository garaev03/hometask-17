const loadMore=document.querySelector(".loadMore")
let skip=3
let take=3

loadMore.addEventListener("click",()=>{
    fetch("/Work/LoadMore?skip="+skip+"&take="+take) 
    .then(response=> response.text())   
    .then(text=>{
        $(".products").append(text)
        skip+=take
    })      

    fetch("/Work/GetProductsCount")
    .then(response=> response.text())
    .then(count=> {   
        if(count<=skip+take){
            $(".loadMore").remove()
        }})
})
