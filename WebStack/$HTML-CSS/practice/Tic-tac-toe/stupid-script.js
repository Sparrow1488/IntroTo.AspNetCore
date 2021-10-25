const cells = document.querySelectorAll(".cell");
const columns = document.querySelectorAll(".column");
const rowsIndexes = ["0", "1", "2"];
let winSymbol = "";
let currentSymbol = "X";
cells.forEach(cell => {
    cell.addEventListener("click", function(){
        if(!this.innerHTML){
            this.innerHTML = `<p>${currentSymbol}</p>`;
            if(currentSymbol == "X")
                currentSymbol = "O"
            else currentSymbol = "X"
        }
        handleMotion();
    });
});

function handleMotion(){
    if(cellsEquals()){
        displayWin();
    }
}
function displayWin(){
    alert(winSymbol + " win!");
}
function cellsEquals(){
    const cellsValues = [];
    let result = false;
    cells.forEach(cell => cellsValues.push(cell.innerText));
    if(cellsValues[0] == cellsValues[1] && cellsValues[0] == cellsValues[2] && cellsValues[0].length > 0){
        winSymbol = cellsValues[0]
        result = true;
    }
    if(cellsValues[0] == cellsValues[3] && cellsValues[0] == cellsValues[6] && cellsValues[0].length > 0)
    {
        winSymbol = cellsValues[0]
        result = true;
    }
    if(cellsValues[1] == cellsValues[4] && cellsValues[1] == cellsValues[7] && cellsValues[1].length > 0)
    {
        winSymbol = cellsValues[1]
        result = true;
    }
    if(cellsValues[2] == cellsValues[5] && cellsValues[2] == cellsValues[8] && cellsValues[5].length > 0)
    {
        winSymbol = cellsValues[2]
        result = true;
    }
    if(cellsValues[2] == cellsValues[5] && cellsValues[2] == cellsValues[8] && cellsValues[5].length > 0)
    {
        winSymbol = cellsValues[2]
        result = true;
    }
    if(cellsValues[3] == cellsValues[4] && cellsValues[3] == cellsValues[5] && cellsValues[3].length > 0)
    {
        winSymbol = cellsValues[3]
        result = true;
    }
    if(cellsValues[6] == cellsValues[7] && cellsValues[6] == cellsValues[8] && cellsValues[6].length > 0)
    {
        winSymbol = cellsValues[6]
        result = true;
    }
    if(cellsValues[0] == cellsValues[4] && cellsValues[0] == cellsValues[8] && cellsValues[0].length > 0)
    {
        winSymbol = cellsValues[0]
        result = true;
    }
    if(cellsValues[2] == cellsValues[4] && cellsValues[2] == cellsValues[6] && cellsValues[2].length > 0)
    {
        winSymbol = cellsValues[2]
        result = true;
    }
    return result;
}