
var supplier = {
    intiTbl: function (isSearch = false, pageNum = 1, pageSize = 10, reload = false) {



        var supplierName = $("#supplier-name").val().trim();
        var supplierEmail = $("#supplier-email").val().trim();
        var supplierCRN = $("#supplier-crn").val().trim();
        var cityId = ($("#supplier-cityId").val() != "") ? ($("#supplier-cityId").val()) : (0);
        var status = ($("#supplier-status").val() != "") ? ($("#supplier-status").val()) : (0);
        var data = {
            IsSearch: isSearch,
            Name: supplierName,
            Email: supplierEmail,
            CRN: supplierCRN,
            CityId: cityId,
            Status: status

        };


        var columns = [
            { data: "id" },
            { data: "name" },
            { data: "commercialRegisterationNumber" },
            { data: "email" },
            { data: "releaseDate" },
            { data: "endDate" },
            {
                "render": function (data, type, row) {

                    var str = "";
                    if (row.status == 1) {

                        str = " <span class='badge rounded-pill  badge-light-info'> InReview</span>";
                    } else if (row.status == 2) {
                        str = "<span class='badge rounded-pill  badge-light-success'>Activated</span>";
                    } else if (row.status == 3) {
                        str = " <span class='badge rounded-pill  badge-light-warning'>Deactivated</span>";
                    } else {
                        str = "<span class='badge rounded-pill  badge-light-danger'>Declined</span>";
                    }

                    return str;
                }
            }];
        columns.push(
            {

                "render": function (data, type, row) {

                    var str = '<div class="d-inline-flex">' +
                        '<a class="pe-1 dropdown-toggle hide-arrow text-primary" data-bs-toggle="dropdown">' +
                        feather.icons['more-vertical'].toSvg({ class: 'font-small-4' }) +
                        '</a>' +
                        '<div class="dropdown-menu dropdown-menu-end">';


                    if (row.status != 2) {
                        str += '<a href="javascript:void(0);" onclick="supplier.activate(`' + row.id + '`)" class="dropdown-item">' +
                            feather.icons['check'].toSvg({ class: 'font-small-4 me-50' }) +
                            'Activate</a>';
                    } if (row.status != 3 && row.status!=1) {
                        str += '<a href="javascript:void(0);" onclick="supplier.deactivate(`'+row.id+'`)" class="dropdown-item">' +
                            feather.icons['slash'].toSvg({ class: 'font-small-4 me-50' }) +
                            'Deactivate</a>';
                    } if (row.status != 4) {
                        str += '<a href="javascript:void(0);" onclick="supplier.decline(`'+row.id+'`)" class="dropdown-item delete-record">' +
                            feather.icons['user-x'].toSvg({ class: 'font-small-4 me-50' }) +
                            'Decline</a>'
                    }


                    
                    
                       
                    str += '</div>' +

                        '<a href="javascript:void(0);" onclick="supplier.details(`'+row.id+'`)" class="item-edit">' +
                        feather.icons['info'].toSvg({ class: 'font-small-4' }) +
                        '</a>' +
                        '</div>';
                    return str;
                 
                }

            });




        var url = "/admin/supplier/allsuppliers";
        var tableId = "#supplierTbl";
        var pageSize = 15;
        var buttons = [];
        //    [


        //    {
        //        text: feather.icons['plus'].toSvg({ class: 'me-50 font-small-4' }) + 'Add New User',
        //        className: 'create-new btn btn-primary',

        //        init: function (api, node, config) {
        //            $(node).click(function () {

        //                window.location.href = '/';

        //            })
        //        }
        //    }

        //]
        //  }



        general.intiDataTable(tableId, url, data, columns, buttons, pageSize);
    },
    activate: function (supplierId) {

        var url = window.location.href;

        var newUrl = "/admin/supplier/activate/" + supplierId + "?returnUrl=" + encodeURIComponent(url);
        window.location.href = newUrl;

        console.log(newUrl);


        

    },
    deactivate: function (supplierId) {
        var url = window.location.href;

        var newUrl = "/admin/supplier/deactivate/" + supplierId + "?returnUrl=" + encodeURIComponent(url);
        window.location.href = newUrl;
        console.log("99");
        
    },
    decline: function (supplierId) {
        var url = window.location.href;

        var newUrl = "/admin/supplier/decline/" + supplierId + "?returnUrl=" + encodeURIComponent(url);
        window.location.href = newUrl;
    },
    details: function (supplierId) {
        var url = window.location.href;

        var newUrl = "/admin/supplier/details/" + supplierId + "?returnUrl=" + encodeURIComponent(url);
        window.location.href = newUrl;
    }



}