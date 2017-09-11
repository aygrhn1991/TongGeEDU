var app = angular.module('app', []);
app.controller('ctrl', function ($scope, $http) {
    var id = getUrlParam('id');
    $scope.loaddata = function () {
        $http.post('/Admin/CollapseLink_Query', {
            id: id
        }).success(function (d) {
            $('.click2edit').html(d.content);
        });
    };
    $scope.loaddata();
    $scope.edit = function () {
        $("#eg").addClass("no-padding");
        $('.click2edit').summernote({
            lang: 'zh-CN',
            focus: true
        });
    };
    $scope.save = function () {
        $("#eg").removeClass("no-padding");
        var aHTML = $('.click2edit').code();
        $http.post('/Admin/CollapseLink_Edit', {
            id: id,
            content: aHTML
        }).success(function (d) {
            if (d == true) {
                alert('保存完成');
            } else {
                alert('http错误');
            }
        });
        $('.click2edit').destroy();
    };
});