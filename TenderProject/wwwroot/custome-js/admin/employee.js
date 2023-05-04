var employee = {
    intiTbl: function (isSearch = false, pageNum = 1, pageSize = 10, reload = false) {
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

                    var str = '<div class="d-inline-flex">' +
                        '<a class="pe-1 dropdown-toggle hide-arrow text-primary" data-bs-toggle="dropdown">' +
                        feather.icons['more-vertical'].toSvg({ class: 'font-small-4' }) +
                        '</a>' +
                        '<div class="dropdown-menu dropdown-menu-end">';



                    str += '<a href="javascript:void(0);" onclick="employee.edit(`' + row.id + '`)" class="dropdown-item delete-record">' +
                        feather.icons['edit'].toSvg({ class: 'font-small-4 me-50' }) +
                        'Edit</a>'






                    str += '</div>' +

                        '<a href="javascript:void(0);" onclick="supplier.details(`' + row.id + '`)" class="item-edit">' +
                        feather.icons['eye'].toSvg({ class: 'font-small-4' }) +
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


        general.intiDataTable(tableId, url, data = {}, columns, buttons, pageSize);

    },
    edit: function (employeeId) {
       
        window.location.href = "/admin/employee/edit/" + employeeId;
                
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

       console.log(data)   ;
        general.callAjax("/admin/employee/create", data, function (response) {
            if (response.status == 1) {
                alert("class is added success");
            }
        }, true);
    }
};