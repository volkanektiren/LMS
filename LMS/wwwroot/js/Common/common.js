var common = {
    requestSetup: function () {
        $.ajaxSetup({
            error: common.failFunction
        });
    },
    failFunction: function () {
        alert("Hata oluştu!!!");
    },
}