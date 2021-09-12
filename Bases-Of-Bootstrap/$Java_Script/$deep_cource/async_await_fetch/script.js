// "use strict"
async function getDataAsync(url){
    const data = await (await fetch(url)).json(); // html as text
    return data;
}
getDataAsync('https://jsonplaceholder.typicode.com/todos/1')
.then(data => {
    console.log(data);
});