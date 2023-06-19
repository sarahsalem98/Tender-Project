var tender = {
    //is all=1,current**all tender after its published date=2,finished=3
    intiTbl: function (isSearch = false, filter = 1, pageNum = 1, pageSize = 10, reload = false) {

        var tenderType = ($("#tender-search-type").val() != "") ? ($("#tender-search-type").val()) : (0);
        var tenderStatus = ($("#tender-search-status").val() != "") ? ($("#tender-search-status").val()) : (0);
        var tenderName = $("#tender-search-name").val().trim();
        var tenderCreatedBy = $("#tender-search-createdBy").val().trim();
        var tenderApprovedBy = $("#tender-search-approvedBy").val().trim();
        console.log($("#tender-search-type").val());

        var data = {
            IsSearch: isSearch,
            TenderFilter: filter,
            Type: tenderType,
            Status: tenderStatus,
            Name: tenderName,
            CreatedBy: tenderCreatedBy,
            ApprovedBy: tenderApprovedBy
        };
        var columns = [
            { data: "type" },
            { data: "id" },
            { data: "name" },
            { data: "recievingOffersDeadline" },
        
            {
                "render": function (data, type, row) {
                    var str = "";
                    var content = "";
                    var className = "";
                  
                    if (row.state == tenderStatses[0].Item1 && row.state == 1) {  className = "secondary"; content = tenderStatses[0].Item2 }
                    if (row.state == tenderStatses[1].Item1 && row.state == 2) { className = "secondary"; content = tenderStatses[1].Item2 }
                    if (row.state == tenderStatses[2].Item1 && row.state == 3) { className = "info"; content = tenderStatses[2].Item2 }
                    if (row.state == tenderStatses[3].Item1 && row.state == 4) { className = "primary"; content = tenderStatses[3].Item2 }
                    if (row.state == tenderStatses[4].Item1 && row.state == 5) { className = "warning"; content = tenderStatses[4].Item2 }
                    if (row.state == tenderStatses[5].Item1 && row.state == 6) { className = "success"; content = tenderStatses[5].Item2 }
                    if (row.state == tenderStatses[6].Item1 && row.state == 7) { className = "dark"; content = tenderStatses[6].Item2 }
                    if (row.state == tenderStatses[7].Item1 && row.state == 8) { className = "danger"; content = tenderStatses[7].Item2 }
                   
                  
                    
        

                    return ` <span class='badge rounded-pill  badge-light-${className}'>${content} </span>`;

                }
            }
            
            


        ];
        columns.push({
            "render": function (data, type, row) {

                var str = '<div class="d-inline-flex">';
       
                if (row.state == 1) {
                    str +=
                        '<a href="javascript:void(0);" title="sent to approve" onclick="supplier.details(`' + row.id + '`)" class="item-edit me-50">' +
                        feather.icons['check-circle'].toSvg({ class: 'font-medium-4 me-50' }) +
                        '</a>';
                    str +=
                        '<a href="javascript:void(0);" title="edit tender"  onclick="supplier.details(`' + row.id + '`)" class="item-edit me-50">' +
                        feather.icons['edit'].toSvg({ class: 'font-medium-4 me-50' }) +
                        '</a>';


                    str += '<a href="javascript:void(0);"  title="delete tender"  onclick="supplier.details(`' + row.id + '`)" class="item-edit me-50">' +
                        feather.icons['trash-2'].toSvg({ class: 'font-medium-4 me-50' }) +
                        '</a>';


                } 

                //state=>2
                if (row.state == 2) {
                    str += '<a href="javascript:void(0);"  title="agree to tender"  onclick="supplier.details(`' + row.id + '`)" class="item-edit me-50">' +
                        feather.icons['thumbs-up'].toSvg({ class: 'font-medium-4 me-50' }) +
                        '</a>';
                    str += '<a href="javascript:void(0);"  title="refuse tender"  onclick="supplier.details(`' + row.id + '`)" class="item-edit me-50">' +
                        feather.icons['slash'].toSvg({ class: 'font-medium-4 me-50' }) +
                        '</a>';
                }
                //state=>3
                if (row.state == 3) {
                    if (row.type == 2) {
                        str += '<a href="javascript:void(0);"  title="send invitaion"  onclick="supplier.details(`' + row.id + '`)" class="item-edit me-50">' +
                            feather.icons['mail'].toSvg({ class: 'font-medium-4 me-50' }) +
                            '</a>';

                    } else {
                  
                        str += '<a href="javascript:void(0);"  title="publish"  onclick="supplier.details(`' + row.id + '`)" class="item-edit me-50">' +
                        feather.icons['send'].toSvg({ class: 'font-medium-4 fs-5 me-50' }) +
                        '</a>';
                    }
                }


                if (row.state == 1 || row.state == 2 || row.state == 3) {
                    str +=
                        '<a href="javascript:void(0);"  title="show details"  onclick="supplier.details(`' + row.id + '`)" class="item-edit me-50">' +
                        feather.icons['info'].toSvg({ class: 'font-medium-4 me-50' }) +
                        '</a>' +

                        '</div>';
                } 

                //state=>4

                if (row.state == 4) {
                    str += '<a href="javascript:void(0);"  title="add offers"  onclick="supplier.details(`' + row.id + '`)" class="item-edit me-50">' +
                        feather.icons['plus-circle'].toSvg({ class: 'font-medium-4 fs-5 me-50' }) +
                        '</a>';
                    str += '<a href="javascript:void(0);"  title="open envelops"  onclick="supplier.details(`' + row.id + '`)" class="item-edit me-50">' +
                        feather.icons['mail'].toSvg({ class: 'font-medium-4 fs-5 me-50' }) +
                        '</a>';

                }

                //state=>5
                if (row.state == 5) {
                    str += '<a href="javascript:void(0);"  title="technical assesment"  onclick="supplier.details(`' + row.id + '`)" class="item-edit me-50">' +
                        feather.icons['clipboard'].toSvg({ class: 'font-medium-4 fs-5 me-50' }) +
                        '</a>';
                }
                //state=>6
                if (row.state == 6) {
                    str += '<a href="javascript:void(0);"  title="tarsia"  onclick="supplier.details(`' + row.id + '`)" class="item-edit me-50">' +
                        feather.icons['check-square'].toSvg({ class: 'font-medium-4 fs-5 me-50' }) +
                        '</a>';
                }
                if (row.state == 4 || row.state == 5 || row.state == 6) {
                    str += '<a href="javascript:void(0);"  title="Suppliers"  onclick="supplier.details(`' + row.id + '`)" class="item-edit me-50">' +
                        feather.icons['users'].toSvg({ class: 'font-medium-4 fs-5 me-50' }) +
                        '</a>';
                    str += '<a href="javascript:void(0);"  title="cancel tender"  onclick="supplier.details(`' + row.id + '`)" class="item-edit me-50">' +
                        feather.icons['x'].toSvg({ class: 'font-medium-4 fs-5 me-50' }) +
                        '</a>' +

                        '</div>';
                }
                //state=>6

                if (row.state == 7) {
                    str += '<a href="javascript:void(0);"  title="tender tarsia results"  onclick="supplier.details(`' + row.id + '`)" class="item-edit me-50">' +
                        feather.icons['bar-chart-2'].toSvg({ class: 'font-medium-4 fs-5 me-50' }) +
                        '</a>';
                    str += '<a href="javascript:void(0);"  title="show results"  onclick="supplier.details(`' + row.id + '`)" class="item-edit me-50">' +
                        feather.icons['upload'].toSvg({ class: 'font-medium-4 fs-5 me-50' }) +
                        '</a>' +

                        '</div>';
                }
               


              
               
        

                return str;

            }
        });

        var url = "/admin/tender/allTenders";
        var tableId = "#tenderTbl";
        var pageSize = 15;
        var buttons =
            [


                {
                    text: feather.icons['plus'].toSvg({ class: 'me-50 font-small-4' }) + 'Add new Tender',
                    className: 'create-new btn btn-primary',
                    //attr: {
                    //    'data-bs-toggle': 'modal',
                    //    'data-bs-target': '#editUser'
                    //},
                    init: function (api, node, config) {
                        $(node).click(function () {

                            window.location.href = '/admin/tender/create';

                        })
                    }
                }

            ];

       var columnsDefs = [{
            "targets": [0],
            "visible": false,
            "searchable": false
        }];

        general.intiDataTable(tableId, url, data, columns, columnsDefs, buttons, pageSize);
    },
    clearSearch: function () {
   
        document.getElementById("tender-search-type").value = "";
        document.getElementById("tender-search-status").value="";
        document.getElementById("tender-search-name").value = "";
        document.getElementById("tender-search-createdBy").value = "";
        document.getElementById("tender-search-approvedBy").value = "";
    }
    }