var visitors = {
    /**
     * ziyaretçi tablosunu yükler
     */
    load: function () {
        let targetEl = $("#visitorListModalBody");

        common.requestSetup();
        targetEl.load("/VisitorManagement/Visitor/ListPartial",
            function (response, status, xhr) {
                visitors.loadTableData();
            }
        );
    },
    /**
     * ziyaretçi tablo datasını yükler
     */
    loadTableData: function () {
        let targetEl = $("#visitorsTableBody");

        common.requestSetup();
        targetEl.load("/VisitorManagement/Visitor/ListTableDataPartial",
            function (response, status, xhr) {

            }
        );
    },
    /**
     * ziyaretçi ekleme formunu yükler
     */
    loadCreate: function () {
        let targetEl = $("#addVisitorModalBody");

        common.requestSetup();
        targetEl.load("/VisitorManagement/Visitor/CreatePartial",
            function (response, status, xhr) {
                $("#visitorListModal").modal('hide');
            }
        );
    },
    /**
     * ziyaretçi ekleme post
     */
    create: function () {
        var dto = {
            Name: $("#addVisitorName").val(),
            Surname: $("#addVisitorSurname").val(),
            Email: $("#addVisitorEmail").val(),
            Phone: $("#addVisitorPhone").val(),
            BirthDate: $("#addVisitorBirthDate").val(),
        };

        common.requestSetup();
        $.post("/VisitorManagement/Visitor/Create", { dto: dto })
        .done(function () {
            $("#addVisitorModal").modal('hide');
        });
    }
}