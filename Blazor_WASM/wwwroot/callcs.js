// DotNet.invokeMethodAsync will be providfed by the
// dotnet.x.x.x.js object in WebAssembly Project
// DotNet.invokeMethodAsync("[Assembly-Name]", "[Method-Identifier-To-Invoke]")
// the global scope object

console.log('CS to JS File');
window.callCSMethods = {
    fn: function () {
        console.log('fs');
    },
    showMesage: function () {
        DotNet.invokeMethodAsync("Blazor_WASM", "ShowMessage")
            .then((message) => {
                alert(`Message Received from CSharp is ${message}`);
            });
    },

    addMethod: function () {
        // passing parameters to CSharp method
        DotNet.invokeMethodAsync("Blazor_WASM", "add", 300,500)
            .then((message) => {
                alert(`Addition from CSharp is ${message}`);
            });
    },
    getProductsMethod: function () {
        // passing parameters to CSharp method
        DotNet.invokeMethodAsync("Blazor_WASM", "getProducts")
            .then((message) => {
                alert(`Data Receivd From AJAX Call ${JSON.stringify(message)}`);
            });
    }
};