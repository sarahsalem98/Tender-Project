var general = {

    intiDataTable: function (tableId, ajaxUrl, columns,pageSize) {
        $(tableId).DataTable({
            ajax: {
                "url": ajaxUrl,
                "type": "POST",
                "dataSrc":""
               // "data": { "search": ajaxData },
                //"datatype": "json",



            },
            columns: columns,
            pageLength: pageSize,


        });
    }
    }