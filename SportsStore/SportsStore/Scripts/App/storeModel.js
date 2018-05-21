app.controller("productController", function ($scope) {
    model = {
        products: ["aaaaaa", "bbbbbb"],
        orders: [],
        authenticated: false,
        username: null,
        password: null,
        error: "",
        gotError: false
    };
    //cuando se ejecuta e controller llama a lo siguiente
    setDefaultCallbacks(function (data, ) {
        if (data) {
            console.log("---Begin Success---");
            console.log(JSON.stringify());
            console.log("---End Success---")
        } else {
            console.log("Success (no data)");
        }
        model.gotError = false;//
    },
        function (statusCode, statusText ) {
            console.log("Error: " + statusCode + " (" + statusText + ")");
          model.error = statusCode + " (" + statusText + ")";
          model.gotError = true;
        }
    );
});





