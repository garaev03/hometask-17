function GetDefaultPrice(count, price) {
    return price / count
}

function Change(ProductCounterDiv, count, price, defaultPrice, id) {
    let spinner = ('<div class="loco">salam</div>')
    //ProductCounterDiv.children[3].innerHTML+=spinner    
    setTimeout(() => {
        let mainBlock = document.querySelector(".main-block")
      
        fetch("/Cart/Edit/" + id + "?count=" + count)
            .then(resp => resp.text())
            .then(text => {
                if (text == "false") {
                    window.location.href = "/Error/Error404"
                }
                else {
                    // ProductCounterDiv.children[3].innerHTML="<span><i class='bx bx-check-circle bx-sm p-2 mt-1 text-success'></i></span>"
                    // setTimeout(() => {
                    let newPrice = count * defaultPrice
                    price.innerHTML = newPrice + "$"
                    //     ProductCounterDiv.children[3].innerHTML=""
                    // }, 1000);
                }
            })
    }, 0);
}

function ModalLoader() {
    // Function to pass into the lazy loader.
    var customLoaders = (function () {

        // Custom Loading modal
        $('#custom-loading').on('load', function (e) {

            // Prevent Default action
            e.preventDefault();

            // Change the default text of the loading modal
            $.modalLoader({ displayText: "Custom Loading" });

            // Wait 5 seconds and then remove the loading modal
            setInterval(function () {
                $.modalLoader('close');
            }, 5000);

        });

    });

    // Lazy Load the loading modal plugin
    ux.load("modalLoader", customLoaders);
}

