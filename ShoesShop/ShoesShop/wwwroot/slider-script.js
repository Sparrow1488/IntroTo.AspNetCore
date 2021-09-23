let currentSliderImage = document.querySelector(".slider__current-image img");
let listOfSliderImages = document.querySelectorAll(".slider-image");

for (let index = 0; index < listOfSliderImages.length; index++) {
    const img = listOfSliderImages[index];
    img.addEventListener("click", function(){
        currentSliderImage.style.opacity = "0";
        setTimeout(()=> {
            currentSliderImage.src = img.src;
            currentSliderImage.style.opacity = "1";
        }
        , 300)
       
    });
}
