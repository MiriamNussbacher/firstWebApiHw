showBag = () => {
let cartString=sessionStorage.getItem("cart")
    let myCart = JSON.parse(cartString);
    let totalSum = 0;
    let i = 0;
    while (myCart.length != 0) {
        let c = myCart[0];
        let tmp = document.getElementById("temp-row");
        let clone = tmp.content.cloneNode(true);
        let count = myCart.filter(p => p.productId == myCart[i].productId)
        clone.querySelector(".image").src = "images/" + myCart[i].productImage;
        clone.querySelector(".quantity").innerHTML = count.length;
        clone.querySelector(".DeleteButton").addEventListener('click', () => deleteProduct(c))
        clone.querySelector(".AddButton").addEventListener('click', () => addProduct(c))
        clone.querySelector(".sum").innerHTML = count.length * myCart[i].productPrice+"$";
        totalSum += count.length * myCart[i].productPrice;
        document.querySelector("tbody").appendChild(clone);
        myCart = myCart.filter(p => p.productId != myCart[i].productId)
    }
    document.querySelector("#totalAmount").innerHTML=totalSum+"$"


}

deleteProduct=(product)=>{
    let cartString = sessionStorage.getItem("cart")
    let myCart = JSON.parse(cartString);
    let index = myCart.findIndex(p => p.productId == product.productId);
    myCart = myCart.filter((p, i) => i != index);
    sessionStorage.cart = JSON.stringify(myCart);
    document.querySelector("tbody").replaceChildren([]);
    showBag();
}
addProduct = (product) => {
    let cartString = sessionStorage.getItem("cart")
    let myCart = JSON.parse(cartString);
    myCart = [...myCart,product];
    sessionStorage.cart = JSON.stringify(myCart);
    document.querySelector("tbody").replaceChildren([]);
    showBag();
}

closeOrder = () => {
    let arr = ["a", "b", "c"];
   




}