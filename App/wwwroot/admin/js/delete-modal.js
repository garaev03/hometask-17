const ProductDelete=document.querySelectorAll(".ProductDelete")

ProductDelete.forEach(btn=>btn.addEventListener("click",(e)=>{
    Swal.fire({
      title: 'Are you sure?',
      text: "You are going to delete product!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
      if (result.isConfirmed) {
        var value=btn.getAttribute("data-id")
        fetch("/Admin/Products/Delete?id="+value)
        .then(resp => resp.text())
        .then(text=>{
            if(text=="true"){
                btn.parentElement.parentElement.parentElement.style.display="none"
                Swal.fire(
                  'Deleted!',
                  'Your file has been deleted.',
                  'success'
                )
            }
        })
      }
    })
}))