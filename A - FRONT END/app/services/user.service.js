angular.module('myApp')
    .service('$user',function(appSettings, apiUrls, $http){
    this.login = function (username, password) {
        var url = appSettings.endPoint.apiService + '/' + apiUrls.account.login;
        return $http
            .post(url,{username: username, password: password})
            .then(function (x) {
                return x.data;
            });
    };

    this.register = function (model) {
        var url = appSettings.endPoint.apiService + '/' + apiUrls.account.register;
        return $http
            .post(url, model)
            .then(function (x) {
                return x.data;
            });
    }
});