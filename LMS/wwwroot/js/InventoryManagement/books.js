var books = {
    load: function () {
        let targetEl = $("#booksTable");

        common.requestSetup();
        targetEl.load("/InventoryManagement/Book/ListPartial",
            function (response, status, xhr) {
                books.loadTableData();
            }
        );
    },
    loadTableData: function () {
        let targetEl = $("#booksTableBody");

        common.requestSetup();
        targetEl.load("/InventoryManagement/Book/ListTableDataPartial",
            function (response, status, xhr) {
                
            }
        );
    },
    loadCreate: function () {
        let targetEl = $("#addBookModalBody");

        common.requestSetup();
        targetEl.load("/InventoryManagement/Book/CreatePartial",
            function (response, status, xhr) {

            }
        );
    },
    create: function () {
        var dto = {
            Title: $("#addBookTitle").val(),
            Author: $("#addBookAuthor").val(),
            Description: $("#addBookDescription").val(),
            ISBN: $("#addBookISBN").val(),
            Publisher: $("#addBookPublisher").val(),
        };

        common.requestSetup();
        $.post("/InventoryManagement/Book/Create", { dto: dto })
        .done(function () {
            $("#addBookModal").modal('hide');

            books.loadTableData();
        });
    }
}