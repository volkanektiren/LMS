var books = {
    /**
     * kitap tablosunu yükler
     */
    load: function () {
        let targetEl = $("#booksTable");

        common.requestSetup();
        targetEl.load("/InventoryManagement/Book/ListPartial",
            function (response, status, xhr) {
                books.loadTableData();
            }
        );
    },
    /**
     * kitap tablo datasını yükler
     */
    loadTableData: function () {
        let targetEl = $("#booksTableBody");

        common.requestSetup();
        targetEl.load("/InventoryManagement/Book/ListTableDataPartial",
            function (response, status, xhr) {
                
            }
        );
    },
    /**
     * kitap ekleme formunu yükler
     */
    loadCreate: function () {
        let targetEl = $("#addBookModalBody");

        common.requestSetup();
        targetEl.load("/InventoryManagement/Book/CreatePartial",
            function (response, status, xhr) {

            }
        );
    },
    /**
     * kitap ekleme post
     */
    create: function () {
        var formElement = document.getElementById('addBookForm');
        var formData = new FormData(formElement);

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
    /**
     * kitap ödünç verme formunu yükler
     * @param {any} bookId
     */
    loadLend: function (bookId) {
        let targetEl = $("#lendItModalBody_" + bookId);

        common.requestSetup();
        targetEl.load("/InventoryManagement/Book/LendPartial", { bookId: bookId },
            function (response, status, xhr) {

            }
        );
    },
    /**
     * kitap ödünç verme post
     * @param {any} bookId
     */
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
    /**
     * kitabın ödünç verilme bilgisini getirir
     * @param {any} bookId
     */
    loadLendingDetails: function (bookId) {
        let targetEl = $("#lendingDetailsModalBody_" + bookId);

        common.requestSetup();
        targetEl.load("/InventoryManagement/Book/LendingDetailsPartial", { bookId: bookId },
            function (response, status, xhr) {

            }
        );
    },
    /**
     * kitap iadesi post
     * @param {any} bookId
     */
    refund: function (bookId) {
        var lendId = $("#bookLendId_" + bookId).val();

        common.requestSetup();
        $.post("/InventoryManagement/Book/Refund", { lendId: lendId })
            .done(function () {
                var targetModal = $("#lendingDetailsModal_" + bookId);
                targetModal.on('hidden.bs.modal', function (e) {
                    books.loadTableData();
                })

                targetModal.modal('hide');
            });
    },
}