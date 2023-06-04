var employee = {
    intiTbl: function (isSearch = false, pageNum = 1, pageSize = 10, reload = false) {

        var employeeId = $("#employee-search-id").val().trim();
        var employeeName = $("#employee-search-name").val().trim();
        var employeeEmail = $("#employee-search-email").val().trim();
        var employeePhoneNumber = $("#employee-search-phoneNumber").val().trim();
        var EmployeeRoleId = ($("#employee-search-roleId").val() != "") ? ($("#employee-search-roleId").val()) : (0);

       
       
     
        var data = {
            IsSearch: isSearch,
            Id: employeeId,
            Name: employeeName,
            Email: employeeEmail,
            PhoneNumber: employeePhoneNumber,
            RoleId: EmployeeRoleId
        };
        var columns = [
            { data: "id" },
            { data: "name" },
            { data: "email" },
            { data: "phoneNumber" },
            {
                "render": function (data, type, row) {

                    var roleBadgeObj = {
                        //    SuperAdmin: feather.icons['user'].toSvg({ class: 'font-medium-3 text-primary me-50' }),
                        admin: " <span class='badge rounded-pill  badge-light-warning'>admin</span>",
                        //  Maintainer: feather.icons['database'].toSvg({ class: 'font-medium-3 text-success me-50' }),
                        //Editor: feather.icons['edit-2'].toSvg({ class: 'font-medium-3 text-info me-50' }),
                        SuperAdmin: " <span class='badge rounded-pill  badge-light-danger'>superAdmin</span>",
                        employee: " <span class='badge rounded-pill  badge-light-primary'>employee</span>"
                    };
                    return roleBadgeObj[row.role.name_En];



                }

            }
        ];


        columns.push(
            {

                "render": function (data, type, row) {

                  



                    var str = '<a href="javascript:void(0);" title="edit" onclick="employee.edit(`' + row.id + '`)" class="item-edit">' +
                        feather.icons['edit'].toSvg({ class: 'font-medium-4 me-50' }) +
                        '</a>'






                

                    str +=   '<a href="javascript:void(0);" title="delete" onclick="employee.delete(`' + row.id + '`)" class="item-edit">' +
                        feather.icons['x'].toSvg({ class: 'font-medium-4' }) +
                        '</a>' +
                        '</div>';
                    return str;

                }


            });

        var url = "/admin/employee/allemployees";
        var tableId = "#employeeTbl";
        var pageSize = 15;
        var buttons =
            [


                {
                    text: feather.icons['plus'].toSvg({ class: 'me-50 font-small-4' }) + 'Add New Employee',
                    className: 'create-new btn btn-primary',
                    //attr: {
                    //    'data-bs-toggle': 'modal',
                    //    'data-bs-target': '#editUser'
                    //},
                    init: function (api, node, config) {
                        $(node).click(function () {

                            window.location.href = '/admin/employee/create';

                        })
                    }
                }

            ];


        general.intiDataTable(tableId, url, data, columns, buttons, pageSize);

    },
    edit: function (employeeId) {
       
        window.location.href = "/admin/employee/edit/" + employeeId;
                
    },
    delete: function (employeeId) {
        console.log("delete");
        var data = {};
        data.Id = employeeId
        general.callAjax("/admin/employee/Delete", data,
            function (response) {
                if (response.status == 1) {
                    toastr['info']('the class deleted successfully !! 😀', 'Success', {
                        positionClass: 'toast-top-right',
                        rtl: true,
                        timeOut: 1000,
                        onHidden: function () {
                            window.location.href = '/admin/employee/index';
                        }
                    });

                } else {
                    alert("somthing went wrong");
                }
        }, true);
    }
    ,
    submitForm: function () { 
        var data = {};
        data.Name = document.getElementById("employee-name").value.trim();
        data.Email = document.getElementById("employee-email").value.trim();
        data.Password = document.getElementById("employee-password").value.trim();
        data.PhoneNumber = document.getElementById("employee-phoneNumber").value.trim();
        data.RoleId = document.getElementById("employee-roleId").value.trim();
        data.Id = document.getElementById("employee-id").value.trim() == "" ? 0 : document.getElementById("employee-id").value.trim();

   
        general.callAjax("/admin/employee/AddEditEmployee", data, function (response) {
            if (response.status == 1) {
                var msg = "";
                console.log(isAdd);
                if (isAdd==true) {
                     msg = 'the class added successfully !! 😀';
                } else {
                    msg = 'the class is edited successfully !! 😀';
                }
                toastr['success'](msg, 'Success', {
                        positionClass: 'toast-top-right',
                        rtl: true,
                        timeOut: 3000,
                        onHidden: function () {
                            window.location.href = '/admin/employee/index';
                        }
                    });
                
               

               
            }
        }, true);
    }
};