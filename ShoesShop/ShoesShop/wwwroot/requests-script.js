let nextBtn = document.querySelector(".next-product-btn");
nextBtn.addEventListener("click", async function(){
    const path = window.location.search;
    if(path.endsWith("1"))
        window.location.search = `product=2`;
    else window.location.search = `product=1`;
});