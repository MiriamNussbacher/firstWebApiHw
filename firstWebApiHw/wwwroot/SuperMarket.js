
const getAllProducts = async( desc,  minPrice,  maxPrice, categoryIds) => {
    try {
      
        let url = `https://localhost:44354/api/Products`;
        if (desc || minPrice || maxPrice || categoryIds)url+=`?`
        if (desc) url += `&desc=${desc}`;
        if (minPrice) url += `&minPrice=${minPrice}`;
        if (maxPrice) url += `&maxPrice=${maxPrice}`;
        if (categoryIds) { 
        for (let i = 0; i < categoryIds.length; i++) {
            url +=`&categoryIds=${categoryIds[i]}`
        }}
        const res = await fetch(url);
        const products = await res.json();
        return products
    } catch (e) {
        console.log(e)
    }
}
const getAllCategories = async () => {
    try {
        const res = await fetch("https://localhost:44354/api/Categories");
        const categories = await res.json();
        return categories
    } catch (e) {
        console.log(e)
    }
}

const showProducts=async()=>{
    const products = await getAllProducts();
    for (var i = 0; i < products.length;i++) {
        let tmp = document.getElementById("temp-card");
        let clone = tmp.content.cloneNode(true);
        clone.querySelector("img").src = "./images/" + products[i].productImage;
        clone.querySelector("h1").innerText = products[i].productName;
        clone.querySelector(".description").innerText = products[i].productDescription
        clone.querySelector(".price").innerText = products[i].productPrice+"¤";
        document.getElementById("PoductList").appendChild(clone);
    }
}
const filterProducts = async () => {
    let checkedCategories = [];
    const allCategoriesOptions = document.querySelectorAll(".opt");
    for (let i = 0; i < allCategoriesOptions.length; i++) {
        if (allCategoriesOptions[i].checked) checkedCategories.push(allCategoriesOptions[i].id)
    }
    let minPrice = document.getElementById("minPrice").innerText;
    let maxPrice = document.getElementById("maxPrice").innerText;
    let desc = document.getElementById("nameSearch").innerText;
    const products = await getAllProducts(desc, minPrice, maxPrice, checkedCategories);
    document.getElementById("PoductList").children = [];
    for (var i = 0; i < products.length; i++) {
        let tmp = document.getElementById("temp-card");
        let clone = tmp.content.cloneNode(true);
        clone.querySelector("img").src = "./images/" + products[i].productImage;
        clone.querySelector("h1").innerText = products[i].productName;
        clone.querySelector(".description").innerText = products[i].productDescription
        clone.querySelector(".price").innerText = products[i].productPrice + "¤";
        document.getElementById("PoductList").appendChild(clone);
    }
}

const showCategories = async () => {
    const categories = await getAllCategories();
    for (var i = 0; i < categories.length; i++) {
        let tmp = document.getElementById("temp-category");
        let clone = tmp.content.cloneNode(true);
        clone.querySelector("label").for = categories[i].categoryName;
        clone.querySelector("input").value = categories[i].categoryName;
        clone.querySelector("input").id = categories[i].categoryId;
        clone.querySelector(".OptionName").innerText = categories[i].categoryName;
        document.getElementById("categoryList").appendChild(clone);

    }
}
