function GridSettings(options) {
    if (options === undefined || options == null) options = {};

    options = $.extend(true,
        {
            dataSource: {},
            width: "100%",
            scrollable: false,
            reorderable: false,
            navigatable: true,
            sortable: {
                mode: "single",
                allowUnsort: true
            },
            selectable: "row",
            resizable: true,
            filterable: {
                extra: false,
                operators: {
                    string: {
                        contains: "Contains"
                    }
                },
                cell: {
                    enabled: false
                }
            },
            editable: false,
            noRecords: {
                template: '<hr class="modal-hr"/><b>Дані відсутні</b><hr class="modal-hr">'
            },
            pageable: {
                refresh: true,
                messages: {
                    empty: "Дані відсутні",
                    allPages: "Всі"
                },
                pageSizes: [10, 20, 30, "All"],
                buttonCount: 5
            },
            createAt: 'bottom'
        }, options);

    return options;
};

function DataSourceSettings(options) {
    if (options === undefined || options == null) options = {};

    options = $.extend(true,
        { 
            transport: {
                read: {
                    type: "GET",
                    dataType: "json"
                }
            },
            pageSize: 20
        }, options);

    return options;
};

function WindowSettings(options) {
    if (options === undefined || options == null) options = {};

    options = $.extend(true,
        {
            actions: ["Close"],
            title: "",
            resizable: false,
            modal: true,
            draggable: true,
            width: "50%",
            refresh: function () {
                this.center();
            },
            deactivate: function () {
                bars.ui.loader(this, false);
                this.destroy();
            },
            content: {}

        }, options);

    return options;
};


function onEscKeyUp(e) {
    if (e.keyCode == 27) {
        var visibleWindow = $(".k-window:visible > .k-window-content:last");
        if (visibleWindow.length)
            visibleWindow.data("kendoWindow").close();
    }
};

$(document).on('keyup', onEscKeyUp);
