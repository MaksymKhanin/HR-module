function candidateWindow(action, process_id, xmlData) {

    var _canClose = true;
    var _initialLoad = true;

    function getTitle() {
        switch (action) {
            case "read":
                return "Кандидат: Перегляд";
            case "edit":
                return "Кандидат: Редагування";
            default:
                return "Кандидат: Додавання";
        }
    };

    function onClose(e) {
        if (!_canClose) {
            e.preventDefault();
            $(document).off("keyup", onEscKeyUp);
        }
    };

    var windowOptions = {
        
        title: getTitle(),
        close: onClose,
        overflow: "hidden",
        width: "960px",
        content: {
            template: kendo.template($("#candidateWindowTemplate").html())
        }
    };

    var contractWin = $("<div />").kendoWindow(WindowSettings(windowOptions));

    contractWin.data("kendoWindow").center().open();
}
