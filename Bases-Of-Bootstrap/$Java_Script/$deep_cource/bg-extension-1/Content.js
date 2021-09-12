// const rule34Url = "https://rule34.xxx/index.php?page=post&s=list&tags=all";
const rule34Url = "https://rule34.xxx/index.php?page=post&s=list&tags=female";
const baseRule34Url = "https://rule34.xxx/";

async function getRemoteHtml(url){
    const html = (await (await fetch(url)).text());
    const doc = new DOMParser().parseFromString(html, 'text/html');
    return doc;
}

function getCurrentImagesLinks(contentHtmlLinks){
    const currentImagesLinks = [];
    for (let i = 0; i < contentHtmlLinks.length; i++) {
        const currentImageLink = baseRule34Url + healthLink(contentHtmlLinks[i].href);
        currentImagesLinks.push(currentImageLink);
    }
    console.log(currentImagesLinks);
    return currentImagesLinks;
}

function healthLink(brakeLink){
    const goodLink = brakeLink.split('/').pop();
    return goodLink;
}

async function getDownloadFileLink(currentPageLink){
    let imageLink = "";
    try{
        // console.log("[Load image] Current page", currentPageLink);
        const rootImageDocument = await getRemoteHtml(currentPageLink);
        console.log(rootImageDocument);
        const imageTag = rootImageDocument.querySelector("#image");
        imageLink = imageTag.src;
        return imageLink;
    }
    catch(err){
        console.error("[ERROR]: Received page wasn't has link on IMAGE!");
    }
}

async function parseRule34Content(siteHomeDocument){
    try {
        const contentPanel = siteHomeDocument.querySelector(".content");
        console.log("Content", contentPanel);
        const contentHtmlLinks = contentPanel.querySelectorAll(":scope > div > .thumb > a");
        console.log("Content links", contentHtmlLinks);
        const currentImagePages = getCurrentImagesLinks(contentHtmlLinks);
        // save first 10 files
        for (let i = 0; i < 9; i++) {
            const downloadLink = await getDownloadFileLink(currentImagePages[i]);
            if(downloadLink !== undefined && downloadLink !== null){
                console.log("Download link", downloadLink);
                downloadURL(downloadLink);
            }
        }
    }
    catch(error){
        console.error("[Full party]Script ERROR:", error);
    }
}

function getLinksOnImages(currentImagesPages){
    console.log(currentImagesPages);
    for (let i = 0; i < currentImagesPages.length; i++) {
        
    }
}

function downloadURL(link) {
    console.log("Download image by URL: ", link);
    chrome.downloads.download({
        url: link
    });
}

getRemoteHtml(rule34Url)
.then(async function(remoteDoc){
    console.log(remoteDoc);
    await parseRule34Content(remoteDoc);
});


// downloadURL("https://rule34.xxx//samples/4454/sample_f12c17bd02ee3ae1529d5edf866237f1.jpg?5069743");


    

//     // var htmlLink = document.createElement('a');
//     // htmlLink.textContent = 'download image';

//     // htmlLink.addEventListener('click', function(ev) {
//     //     htmlLink.href = "https://www.w3schools.com/html/pic_trulli.jpg";
//     //     htmlLink.download = "image.jpg";
//     // }, false);

//     // document.body.appendChild(htmlLink);
//     // htmlLink.click();



// function onStartedDownload(id) {
//     console.log(`Started downloading: ${id}`);
// }

// function onFailed(error) {
//     console.log(`Download failed: ${error}`);
// }



// async function getImageByView(url){
//     var html = (await (await fetch(url)).text());
//     var doc = new DOMParser().parseFromString(html, 'text/html');
//     const findImage = doc.querySelector("#image");
//     console.log("[getImageByView] result: ", findImage.src);
//     return findImage.src;
// };
