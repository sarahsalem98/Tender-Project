var rolee = {
    createRolePermissionObject: function () {
        var rolePermissionArray = [];
      
        var trs = document.querySelectorAll("tr:not(:first-child)");
     
        trs.forEach(function (tr) {
            var controllerName = tr.querySelector('td:first-child').textContent;
            var tdSecond = tr.querySelector('td:nth-child(2)');

            var labels = tdSecond.querySelectorAll('label');
            var inputs = tdSecond.querySelectorAll('input');
            var object = {};


            for (var i = 0; i < labels.length; i++) {
                object[labels[i].textContent] = inputs[i].checked;

            }

            var object2 = { "Controller": controllerName, "ActionsPermissions": object }
            rolePermissionArray.push(object2);

        });
           //console.log(rolePermissionArray);

       return rolePermissionArray;

    },
    submitFormRolePermission: function () {
        var dataObject = rolee.createRolePermissionObject();
        var nameAr = document.getElementById("Role-Name-Ar").value.trim();
        var nameEn = document.getElementById("Role-Name-En").value.trim();
        var id = document.getElementById("Role-Id").value.trim();
        var dataModel = { RoleId:id ,Name_Ar: nameAr, Name_En: nameEn, PermissionLists: dataObject };
        var data = {
            dataModel: dataModel
        }
      // console.log(data);
        general.callAjax("/admin/role/AddEditRole", data,
            function (response) {
                if (response.status == 1) {
                    toastr['info']('the permission for the role added successfully !! 😀', 'Success', {
                        positionClass: 'toast-top-right',
                        rtl: true,
                        timeOut: 3000,
                        onHidden: function () {
                            window.location.href = '/admin/role/index';
                        }
                    });

                } else {
                    toastr['error']('tsomething went wrong when added permission!! 😕', 'Success', {
                        positionClass: 'toast-top-right',
                        rtl: true
                    });
                  }
            }, true);



    },
    openDeleteModal: function (roleId) {
        var deleteModal = document.getElementById("danger");
        $("#danger-modal-title").html(`Detele Role with ID :${roleId}`)
        $("#danger-modal-body").html(`??Are you sure you want to delete this Role`);
        $("#danger").modal("show");
        document.getElementById("danger-accept-btn").setAttribute("onclick", `rolee.deleteRole(${roleId});`);
    },

    deleteRole: function (roleId) {

        var data = {};
        data.Id = roleId;
        general.callAjax("/admin/role/delete", data
            , function (response) {
                if (response.status == 1) {
                    toastr['info'](' the role deleted successfully !! 😀', 'Success', {
                        positionClass: 'toast-top-right',
                        rtl: true,
                        timeOut: 3000,
                        onHidden: function () {
                            window.location.href = '/admin/role/index';
                        }
                    });

                } else {
                    toastr['error']('something went wrong !! 😕', 'danger', {
                        positionClass: 'toast-top-right',
                        rtl: true
                    });
                }
            }, true
        );
        $("#danger").modal("hide");
    },
    copyRole: function (element) {
        var roleName = element.dataset.message
        navigator.clipboard.writeText(roleName);
    }
    


};






