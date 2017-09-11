var app = angular.module('app', []);
app.controller('ctrl', function ($scope, $http) {
    $scope.loaddata = function () {
        $http.post('/Admin/Company_Query').success(function (d) {
            $scope.list = d;
            setTimeout(function () { $('.dataTables-example').dataTable(); }, 1);
        });
    };
    $scope.loaddata();
    $scope.save = function (e) {
        $http.post('/Admin/Company_Edit', {
            id: e.id,
            url: e.url
        }).success(function (d) {
            if (d == true) {
                alert('已保存');
                self.location.reload();
            } else {
                alert('http错误');
            }
        });
    };
    $scope.delete = function (e) {
        if (confirm('确定删除？')) {
            $http.post('/Admin/Company_Delete', {
                id: e.id,
            }).success(function (d) {
                if (d == true) {
                    alert('已删除');
                    self.location.reload();
                } else {
                    alert('http错误');
                }
            });
        }
    };
});