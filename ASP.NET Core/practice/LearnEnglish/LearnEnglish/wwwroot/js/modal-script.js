let modal = document.getElementById("myModal");
let openModalBtn = document.querySelector(".open-modal");

let closeSpan = document.querySelector(".close");
closeSpan.onclick = function() {
    modal.style.display = "none";
}

openModalBtn.onclick = function() {
  modal.style.display = "block";
}

window.onclick = function(event) {
  if (event.target == modal) {
    modal.style.display = "none";
  }
}