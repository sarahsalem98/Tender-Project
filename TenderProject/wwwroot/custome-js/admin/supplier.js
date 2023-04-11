
var supplier = {
    intiTbl: function (pageNum = 1, pageSize = 10, reload = false) {
        var columns = [
            { data: "id" },
            { data: "name" },
            { data: "email" },
            { data: "commercialRegisterationNumber" },
            { data: "releaseDate" },
            { data: "endDate" },
        ];
        var url = "/getSuppliers";
        var tableId = "#supplierTbl";
        var pageSize = 15;
        general.intiDataTable(tableId, url, columns, pageSize);
    }
    }