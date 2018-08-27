$(document).ready(function () {
    initGrid();
});

function initGrid() {
    var dataSource = new kendo.data.DataSource({
        transport: {
            read: {
                url: "http://localhost:52811/api/candidates/GetCandidates/",
                type: "get",
                dataType: "json"
            },
            create: {
                url: "http://localhost:52811/api/candidates/PostCandidate/",
                type: "post",
                dataType: "json",
                complete: function (e) {
                    $("#grid").data("kendoGrid").dataSource.read();
                }
            },
            update: {
                url: "http://localhost:52811/api/candidates/PutCandidate/",
                type: "put",
                dataType: "json",
                complete: function (e) {
                    $("#grid").data("kendoGrid").dataSource.read();
                }
            },
            destroy: {
                url: "http://localhost:52811/api/candidates/DeleteCandidate/",
                type: "delete",
                dataType: "json"
            }
        },
        batch: false,
        schema: {
            model: {
                id: "Id",
                fields: {
                    Id: { editable: false, nullable: true, type: 'number' },
                    Name: { editable: true, validation: { required: true } },
                    Type: { editable: true, validation: { required: true } }
                }
            }
        },
        pageSize: 9,
        serverFiltering: false,
    });
    var singleSelectEditor = function (container, options) {
        $('<input data-bind="value:' + options.field + '"/>')
            .appendTo(container)
            .kendoDropDownList({
                suggest: true,
                dataSource: ['Financial', 'Law', 'Medical', 'IT', 'Educational', 'Industrial', 'Consulting', 'Entertaining']
            });
    };

    $("#grid").kendoGrid({
        dataSource: dataSource,
        pageable: {
            pageSizes: true,
            alwaysVisible: false
        },
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
        sortable: true,
        width: "100%",
        toolbar: [
            { name: "create", text: "Add new candidate" }
        ],
        columns: [

            { title: 'Sirname', field: 'Sirname', editor: singleSelectEditor },
            { title: 'Name', field: 'Name' },
            { title: 'Vacancy', field: 'Vacancy' },
            { title: 'Experience', field: 'Experience' },
            { title: 'PhoneNumber', field: 'PhoneNumber' },
            { title: 'Status', field: 'Status' },
            {
                command: ["edit", "destroy", {
                    name: "  Details",
                    iconClass: "k-icon k-i-info",
                    click: function (e) {

                        // prevent page scroll position change
                        e.preventDefault();
                        // e.target is the DOM element representing the button
                        var tr = $(e.target).closest("tr"); // get the current table row (tr)
                        // get the data bound to the current table row
                        var data = this.dataItem(tr);
                        //console.log("Details for: " + data.name);
                        var id = data.Id;
                        if (id != undefined && id != 0) {
                            window.location = 'http://localhost:65424/Home/OrganisationBills/' + id;

                        }
                    }
                },], title: "&nbsp;", width: "300px"
            }],
        editable: 'popup',
        createAt: 'bottom',
        saveChanges: function (e) {
            if (!confirm("Are you sure you want to save all changes?")) {
                e.preventDefault();
            }
        },
    });
}