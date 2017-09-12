var app = angular.module('app', []);
app.controller('ctrl', function ($scope, $http) {
    $scope.add = function () {
        var formData = new FormData();
        formData.append('file', $('#file')[0].files[0]);
        formData.append('url', $('#url').val());
        $.ajax({
            url: '/Admin/Company_Add',
            type: 'POST',
            data: formData,
            // 告诉jQuery不要去处理发送的数据
            processData: false,
            // 告诉jQuery不要去设置Content-Type请求头
            contentType: false,
            success: function (d) {
                if (d == true) {
                    alert('添加成功');
                    self.location.reload();
                } else {
                    alert('http错误');
                }
            },
        });
    }
});