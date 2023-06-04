var general = {

    intiDataTable: function (tableId, ajaxUrl, ajaxdata = {}, columns,buttons, pageSize) {
        console.log("general");
        $(tableId).DataTable({
            searching: false,
            destroy: true,
            ajax: {
                "url": ajaxUrl,
                "type": "POST",
                "data": { "search": ajaxdata },
                "dataSrc": function (result) {

                    return result.data;
                }
                // "data": { "search": ajaxData },
                //"datatype": "json"
            },
            columns: columns,
            pageLength: pageSize,
            dom:
                '<"d-flex justify-content-between align-items-center header-actions mx-2 row mt-75"' +
                '<"col-sm-12 col-lg-4 d-flex justify-content-center justify-content-lg-start" l>' +
                '<"col-sm-12 col-lg-8 ps-xl-75 ps-0"<"dt-action-buttons d-flex align-items-center justify-content-center justify-content-lg-end flex-lg-nowrap flex-wrap"<"me-1"f>B>>' +
                '>t' +
                '<"d-flex justify-content-between mx-2 row mb-1"' +
                '<"col-sm-12 col-md-6"i>' +
                '<"col-sm-12 col-md-6"p>' +
                '>',
          
            buttons: buttons



        });



    },
    callAjax: function (url, data, onSuccess, isPost = false) {
        console.log(url);
        $.ajax({
            url: url,
            type: (isPost) ? ("POST") : ("GET"),
            data:  data ,
            success: onSuccess,
            error: function (error) {
                console.log(error);
            }
        });
    }
}