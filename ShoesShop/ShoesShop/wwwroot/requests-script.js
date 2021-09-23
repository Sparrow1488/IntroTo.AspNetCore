let nextBtn = document.querySelector(".next-product-btn");
let productId = 1;
nextBtn.addEventListener("click", async function(){
    window.location.search = `product=${productId}`;
});


// const response = (await (await fetch("https://localhost:44314/?product=2")).text());
    // console.log(document.body);
    // const parser = new DOMParser();
    // const html = response;
    // const doc1 = parser.parseFromString(html, "text/html");
    // document = doc1;