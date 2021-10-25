let mapSideSize = 0;

function initGame(mapSize){
    console.log("Initialize game...");
    console.log("Game map size is ", mapSize);
    console.log("Good luck!");

    mapSideSize = mapSize;
    const table = document.querySelector(".table");
    table.innerHTML = "";
    for (let i = 0; i < mapSize; i++) {
        let column = createColumn();
        for (let j = 0; j < mapSize; j++)
            column.appendChild(createCell());   
        table.append(column);
    }
}

let inputMapSize = parseInt(prompt("Set map size (one side lenght)", 3));
initGame(inputMapSize);

const columns = document.querySelectorAll(".column");
const cells = document.querySelectorAll(".cell");
let currentSymbol = "O";
let winner = "";

function createCell(){
    const cell = document.createElement("div");
    cell.classList.add("cell");
    return cell;
}
function createColumn(){
    const column = document.createElement("div");
    column.classList.add("column");
    return column;
}

cells.forEach(function(cell) {
    cell.addEventListener("click", clickEventHandler.bind(cell));
});

function clickEventHandler() {
    if(!this.innerHTML){
        if(currentSymbol == "O")
            currentSymbol = "X"
        else currentSymbol = "O";
            this.innerHTML = `<p>${currentSymbol}</p>`;
        handleMotion();
    }
}

function handleMotion(){
    let displayResultsFlag = false;
    let winMessage = "";
    if(rowsEquals()){
        winMessage = "Row is filled";
        displayResultsFlag = true;
    }
    if(columnsEquals()){
        winMessage = "Column is filled";
        displayResultsFlag = true;
    }
    if(diagonalsEquals()){
        winMessage = "Diagonal is filled";
        displayResultsFlag = true;
    }
    if(displayResultsFlag)
        displayResults(winMessage);
}

function displayResults(message){
    alert(message + "! " + `'${winner}' win!`);
}

function rowsEquals(){
    const rowsHeight = columns[0].querySelectorAll(".cell").length;
    for (let index = 0; index < rowsHeight; index++) {
        let row = [];
        columns.forEach(column => {
            const columnCells = column.querySelectorAll(".cell");
            const cell = columnCells[index];
            row.push(cell.innerText);
        });
        if(rangeEquals(row))
            return true;
    }
    return false;
}

function columnsEquals(){
    let result = false;
    columns.forEach(column => {
        let cellsValues = [];
        column.querySelectorAll(".cell").forEach(cell => {
            cellsValues.push(cell.innerText);
        });
        winner = cellsValues[0];
        if(rangeEquals(cellsValues))
            result = true;
    });
    return result;
}

function diagonalsEquals(){
    const cells = document.querySelectorAll(".cell");
    let firstDiagonalCells = [];
    let secondDiagonalCells = [];
    // the first diagonal
    for (let index = 0; index < cells.length; index += (mapSideSize + 1)) { 
        const cell = cells[index];
        firstDiagonalCells.push(cell.innerText);
    }
    // the second diagonal
    for (let index = mapSideSize - 1; index < cells.length - (mapSideSize - 1); index += (mapSideSize - 1)) { 
        const cell = cells[index];
        secondDiagonalCells.push(cell.innerText);
    }
    console.log(firstDiagonalCells, secondDiagonalCells);
    return rangeEquals(firstDiagonalCells) || rangeEquals(secondDiagonalCells);
}

function rangeEquals(values){
    let equalsResult = false;
    let lastValue = "";
    for (let index = 0; index < values.length; index++) {
        const value = values[index];
        if(index == 0)
            lastValue = value;
        if(value.length < 1 && index > 0)
            return false;
        else if(value === lastValue){
            winner = value;
            equalsResult = true;
        }
        else return false;
    }
    return equalsResult;
}
