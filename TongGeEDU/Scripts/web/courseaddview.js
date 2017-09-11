var app = angular.module('app', []);
app.controller('ctrl', function ($scope, $http) {
    $scope.grades = ['一年级', '二年级', '三年级', '四年级', '五年级', '六年级', '七年级', '八年级', '九年级', '高一', '高二', '高三'];
    $scope.subjects = ['语文', '数学', '英语', '物理', '化学', '生物', '政治', '历史', '地理'];
    $scope.add = function () {
        if ($('#url').val() == null || $('#url').val() == '') {
            alert('URL不能为空');
            return;
        }
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
                    $('#url').val('');
                    $('#file').val('')
                } else {
                    alert('http错误');
                }
            },
        });
    }
});