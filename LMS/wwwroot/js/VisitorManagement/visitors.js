var visitors = {
    load: function () {
        let targetEl = $("#visitorListModalBody");

        common.requestSetup();
        targetEl.load("/VisitorManagement/Visitor/ListPartial",
            function (response, status, xhr) {
                visitors.loadTableData();
            }
        );
    },
    loadTableData: function () {
        let targetEl = $("#visitorsTableBody");

        common.requestSetup();
        targetEl.load("/VisitorManagement/Visitor/ListTableDataPartial",
            function (response, status, xhr) {

            }
        );
    },
    loadCreate: function () {
        let targetEl = $("#addVisitorModalBody");

        common.requestSetup();
        targetEl.load("/VisitorManagement/Visitor/CreatePartial",
            function (response, status, xhr) {
                $("#visitorListModal").modal('hide');
            }
        );
    },
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