
var PolizasController = function (polizasService) {
    var link;

    var init = function (container) {
        $(container).on("click", ".js-borrar", borrarPoliza);
    };

    var borrarPoliza = function (e) {
        if (!confirm("Desea borrar la poliza?")) {
            return;
        }

        link = $(e.target);
        var polizaId = link.attr("data-poliza-id");
        polizasService.borrarPoliza(polizaId, done, fail);
    };

    var done = function () {
        location.reload();
    };

    var fail = function () {
        alert("No fue posible borrar la poliza");
    };

    return {
        init: init
    };

}(PolizasService);
