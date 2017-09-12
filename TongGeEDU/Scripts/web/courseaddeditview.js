var app = angular.module('app', []);
app.controller('ctrl', function ($scope, $http) {
    $scope.grades = gradeArray;
    $scope.subjects = subjectArray;
    $scope.id = getUrlParam('id');
    if ($scope.id == 0) {
        $scope.item = {
            grade: '',
            subject: '',
            title: '',
            teacher: '',
            price: 0,
            introduction: ''
        };
    } else {
        $http.post('/Admin/Course_Query_Item', {
            id: $scope.id
        }).success(function (d) {
            $scope.item = d;
        })
    }
    $scope.add = function () {
        var formData = new FormData();
        formData.append('file', $('#file')[0].files[0]);
        formData.append('grade', $scope.item.grade);
        formData.append('subject', $scope.item.subject);
        formData.append('title', $scope.item.title);
        formData.append('teacher', $scope.item.teacher);
        formData.append('price', $scope.item.price);
        formData.append('introduction', $scope.item.introduction);
        $.ajax({
            url: '/Admin/Course_Add',
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
    $scope.save = function () {
        var formData = new FormData();
        formData.append('file', $('#file')[0].files[0]);
        formData.append('id', $scope.item.id);
        formData.append('grade', $scope.item.grade);
        formData.append('subject', $scope.item.subject);
        formData.append('title', $scope.item.title);
        formData.append('teacher', $scope.item.teacher);
        formData.append('price', $scope.item.price);
        formData.append('introduction', $scope.item.introduction);
        $.ajax({
            url: '/Admin/Course_Edit',
            type: 'POST',
            data: formData,
            // 告诉jQuery不要去处理发送的数据
            processData: false,
            // 告诉jQuery不要去设置Content-Type请求头
            contentType: false,
            success: function (d) {
                if (d == true) {
                    alert('保存成功');
                    self.location.reload();
                } else {
                    alert('http错误');
                }
            },
        });
    }
});