// simple one-way method w/o input and output parameters
function display() {
    alert('The Display is called');
}

// Biredirection method with input and output parameters
function addValues(x, y) {
    var res = x + y;
    return res;
}

// the complex method that is performing Ajax promise based calls
function getProducts() {
    return new Promise((resolve, reject) => {
        let xhr = new XMLHttpRequest();

        xhr.onload = function () {
            if (xhr.status == 200) {
                console.log(`Received Responsed ${xhr.response}`);
                resolve(xhr.response);
            } else {
                reject('Some Error Occured in Response');
            }
        };

        xhr.onerror = function () {
            reject('Some Error Occured in Request / Response');
        }

        xhr.open("GET", "https://apiapptrainingnewapp.azurewebsites.net/api/Products");
        xhr.send();
    });
   
}