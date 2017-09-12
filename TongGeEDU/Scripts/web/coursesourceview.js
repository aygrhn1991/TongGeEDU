var app = angular.module('app', []);
app.controller('ctrl', function ($scope, $http) {
    var parentid = getUrlParam('parentid');
    $scope.state = 'add';
    $scope.loaddata = function () {
        $http.post('/Admin/CourseSource_Query', {
            parentid: parentid
        }).success(function (d) {
            $scope.list = d;
        });
    };
    $scope.loaddata();
    $scope.delete = function (e) {
        if (confirm('确定删除？')) {
            $http.post('/Admin/CourseSource_Delete', {
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
    $scope.clear = function () {
        $scope.item = {
            parentid: parentid,
            title: null,
            chapter: null,
        };
        $('#file').val('');
        $scope.state = 'add';
    }
    $scope.add = function () {
        var formData = new FormData();
        formData.append('file', $('#file')[0].files[0]);
        formData.append('parentid', parentid);
        formData.append('title', $scope.item.title);
        formData.append('chapter', $scope.item.chapter);
        $.ajax({
            url: '/Admin/CourseSource_Add',
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
    $scope.edit = function (e) {
        $http.post('/Admin/CourseSource_Query_Item', {
            id: e.id
        }).success(function (d) {
            $scope.state = 'edit';
            $scope.item = d;
            $('#videoframe').attr('src', '/Admin/VideoFrame?src=/Attachments/course/' + $scope.item.filename);
        });
    }
    $scope.save = function () {
        $http.post('/Admin/CourseSource_Edit', {
            id: $scope.item.id,
            title: $scope.item.title,
            chapter: $scope.item.chapter,
        }).success(function (d) {
            if (d == true) {
                alert('已修改');
                self.location.reload();
            } else {
                alert('http错误');
            }
        });
    }
});