
var PolizasService = function() {
    var borrarPoliza = (polizaId, done, fail) => {
        $.post("/api/polizas/" + polizaId)
            .done(done)
            .fail(fail);
    };

    return {
        borrarPoliza: borrarPoliza,
    };
}();
