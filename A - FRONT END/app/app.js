angular.module("myApp").config(function ($httpProvider) {

    // API interceptor
    $httpProvider.interceptors.push('apiInterceptor');
});