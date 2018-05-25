'use strict';
app.factory('authService', ['$http', '$q', function ($http, $q) {
    var authenticateUrl = '/authenticate';
    var authServiceFactory = {};

    var _authentication = {
        isAuth: false,
        userName: ''
    };

    var _authenticate = function (authData) {
        var deferred = $q.defer();
        $http.post(
            authenticateUrl,
            "grant_type=password&username="+authData.userName+"&password="+authData.password,
             {
                 headers: {
                     'Content-Type': 'application/x-www-form-urlencoded'
                 }
        })
        .then(
            function (response) {//success callback
                
                //console.log('success ' + JSON.stringify(response.data));
                //console.log('data token: ' + response.data.access_token);
                _authentication.isAuth = true;
                _authentication.userName = authData.userName;
                deferred.resolve(_authentication);

            },
            function (response) {//error calback
                //console.log('error: ' + response.data.error_description);
                deferred.reject(response.data.error_description);
                //return response.data;
            });
        debugger;
        return deferred.promise;
    };

    authServiceFactory.authenticate = _authenticate;
    authServiceFactory.welcome = function () { console.log('Welcome !!!'); };
    //authServiceFactory.authentication = _authentication
    return authServiceFactory;
}]);