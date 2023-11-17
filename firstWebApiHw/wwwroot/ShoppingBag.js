showBag = () => {
let cartString=sessionStorage.getItem("cart")
    let myCart = JSON.parse(cartString)
    for (let i = 0; i < myCart.length; i++) {
        let tmp = document.getElementById("temp-row");
        let clone = tmp.content.cloneNode(true);
        clone.querySelector(".image").src = "images/" + myCart[i].productImage;
        document.querySelector("tbody").appendChild(clone);




    }




}