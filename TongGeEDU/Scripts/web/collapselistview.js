var app = angular.module('app', []);
app.controller('ctrl', function ($scope, $http) {
    $scope.loaddata = function () {
        $http.post('/Admin/Collapse_Query').success(function (d) {
            $scope.list = d;
            setTimeout(function () { $('.dataTables-example').dataTable(); }, 1);
        });
    };
    $scope.loaddata();
    $scope.delete = function (e) {
        if (confirm('确定删除？')) {
            $http.post('/Admin/Collapse_Delete', {
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