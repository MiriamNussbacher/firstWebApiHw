
const getAllProducts = async () => {
    try {
        const res = await fetch("https://localhost:44354/api/Products");
        const products = await res.json();
        return products
    } catch (e) {
        console.log(e)
    }
}


const showProducts=async()=>{
    const products = await getAllProducts();
    for (var i = 0; i < products.length;i++) {
        let tmp = document.getElementById("tmp-prod");
        let clone = tmp.content.cloneNode(true);
        clone.querySelector("img").src = "./images/"+ products[i].productImage;
        clone.querySelector("p").innerHtml = products[i].productDescription
        clone.querySelector("h3").innerHtml = products[i].productPrice;
        document.getElementById("products").appendChild(clone);



    }


}