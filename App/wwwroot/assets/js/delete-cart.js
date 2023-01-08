let CartTrash = document.querySelectorAll(".CartTrash")

window.onload = (
    CartTrash.forEach(btn => {
        btn.addEventListener("click", () => {
            id = btn.parentElement.getAttribute("data-id");
            const swalWithBootstrapButtons = Swal.mixin({
                customClass: {
                    confirmButton: 'btn btn-success text-light ms-3',
                    cancelButton: 'btn btn-danger text-light'
                },
                buttonsStyling: false
            })
            swalWithBootstrapButtons.fire({
                title: 'Are you sure?',
                text: "You are going to delete product from cart!",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonText: 'Yes, delete it!',
                cancelButtonText: 'No, cancel!',
                reverseButtons: true
            }).then((result) => {
                if (result.isConfirmed) {
                    fetch("/Cart/Delete/" + id)
                        .then(resp => resp.text()).then(text => {
                            if (text == "true") {
                                btn.parentElement.parentElement.parentElement.style.display = "none";
                                let No=parseInt(btn.parentElement.parentElement.parentElement.children[0].innerHTML)+1
                                btn.parentElement.parentElement.parentElement.children[0].innerHTML=No
                                swalWithBootstrapButtons.fire(
                                    'Deleted!',
                                    'Product has been deleted.',
                                    'success'
                                )
                            }
                            else {
                                swalWithBootstrapButtons.fire(
                                    'Cancelled',
                                    'Product not found!',
                                    'error'
                                )
                            }
                        })
                } else if (
                    /* Read more about handling dismissals below */
                    result.dismiss === Swal.DismissReason.cancel
                ) {
                    swalWithBootstrapButtons.fire(
                        'Cancelled',
                        'Product is safe for now:)',
                        'error'
                    )
                }
            })
        })
    })
)   