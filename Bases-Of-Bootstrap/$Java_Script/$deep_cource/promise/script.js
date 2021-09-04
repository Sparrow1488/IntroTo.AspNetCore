const passport = {
    pass : "1234",
    login : "Sparrow"
};
console.log(passport);

const authUser = new Promise(async function(resolve, reject){
    console.log("Async task started...");
    let authorizateResult = false;

    if(passport === undefined || passport === null){
        reject("Object reference null or undefined exception!");
    }
    else{
        authorizateResult = await isAuthorizate(passport);
        resolve(authorizateResult);
    }
});
authUser.catch((err) => {
    console.error("EXCEPTION IS", err);
})
.then(function(successAuth){
    console.log("Auth result :", successAuth);
    if(successAuth){
        console.log("Authorization was success!");
    }
    else{
        console.log("Authorizate was failed");
    }
});

function isAuthorizate(passport){
    return new Promise(function(resolve){
        setTimeout(() => {
            let authRes = false;
            if(passport.login === "Sparrow" &&
                passport.pass === "1234"){
                authRes = true;
            }
            resolve(authRes);
        }, 2000);
    }); 
}

// вызывается, когда массив промисов в параметре был выполнен
Promise.all([authUser]).then(()=>{
    console.log("Task was completed.");
});

// Promise.race([authUser, ...]).then(() => {
//     console.log("The first promise of array was completed.");
// });