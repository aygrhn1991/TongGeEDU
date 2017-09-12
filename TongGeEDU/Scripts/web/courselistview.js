var app = angular.module('app', []);
app.controller('ctrl', function ($scope, $http) {
    $scope.grades = gradeArray;
    $scope.grades.unshift('全部');
    $scope.grade = $scope.grades[0];
    $scope.subjects = subjectArray;
    $scope.subjects.unshift('全部');
    $scope.subject = $scope.subjects[0];
    $scope.loaddata = function () {
        $http.post('/Admin/Course_Query', {
            grade: $scope.grade,
            subject: $scope.subject,
        }).success(function (d) {
            $scope.list = d;
            $('.dataTables-example').dataTable().fnDestroy();
            setTimeout(function () { $('.dataTables-example').dataTable(); }, 1);
        });
    };
    $scope.loaddata();
    $scope.delete = function (e) {
        if (confirm('确定删除？')) {
            $http.post('/Admin/Course_Delete', {
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
    $scope.setgrade = function (e, f) {
        $(e.target).siblings('span').removeClass('label-primary');
        $(e.target).addClass('label-primary');
        $scope.grade = f;
        $scope.loaddata();
    }
    $scope.setsubject = function (e, f) {
        $(e.target).siblings('span').removeClass('label-primary');
        $(e.target).addClass('label-primary');
        $scope.subject = f;
        $scope.loaddata();
    }
});