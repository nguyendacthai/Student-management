var myApp = angular.module("myApp");
    myApp.constant('statusConstant', {
        listStatus: [{
                name : 'Deleted',
                id : 0
            },
            {
                name : 'Active',
                id : 1
            }]
    });