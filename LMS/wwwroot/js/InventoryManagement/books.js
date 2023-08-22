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
        var formElement = document.getElementById('addBookForm');
        var formData = new FormData(formElement);
        for (var pair of formData.entries()) {
            console.log(pair[0] + ', ' + pair[1]);
        }

        var dto = {
            Title: $("#addBookTitle").val(),
            Author: $("#addBookAuthor").val(),
            Description: $("#addBookDescription").val(),
            ISBN: $("#addBookISBN").val(),
            Publisher: $("#addBookPublisher").val(),
        };

        common.requestSetup();
        $.ajax({
            url: '/InventoryManagement/Book/Create',
            type: 'POST',
            cache: false,
            processData: false,
            contentType: false,
            data: formData,
            success: function () {
                $("#addBookModal").modal('hide');

                books.loadTableData();
            }
        });
    },
    loadLend: function (bookId) {
        let targetEl = $("#lendItModalBody_" + bookId);

        common.requestSetup();
        targetEl.load("/InventoryManagement/Book/LendPartial", { bookId: bookId },
            function (response, status, xhr) {

            }
        );
    },
    lend: function (bookId) {
        var dto = {
            BookId: bookId,
            VisitorId: $("#lendVisitorSelect_" + bookId).val(),
            EstimatedReturnDate: $("#lendEstimatedReturnDate_" + bookId).val(),
        };

        common.requestSetup();
        $.post("/InventoryManagement/Book/Lend", { dto: dto })
            .done(function () {
                var targetModal = $("#lendItModal_" + bookId);
                targetModal.on('hidden.bs.modal', function (e) {
                    books.loadTableData();
                })

                targetModal.modal('hide');
            });
    },
}