var formConfig = {

    gridOptions: {

        columns: [
            {
                title: 'Sirname',
                field: 'Sirname'
            },
            {
                title: 'Name',
                field: 'Name'
            },
            {
                title: 'Vacancy',
                field: 'Vacancy',
                width: "120px"
            },
            {
                title: 'Experience',
                field: 'Experience',
                width: "130px"
            },
            {
                title: 'PhoneNumber',
                field: 'PhoneNumber'
            },
            {
                title: 'Email',
                field: 'Email'
            },
            {
                title: 'Status',
                field: 'Status',
                width: "130px"
            }]

    },

    dataSource: {
        transport: {
            read: {
                url: "http://localhost:52811/api/candidatesapi/GetCandidates/"

            },
            create: {
                url: "http://localhost:52811/api/candidatesapi/PostCandidate/",
                complete: function (e) {
                    $("#grid").data("kendoGrid").dataSource.read();
                }
            },
            update: {
                url: "http://localhost:52811/api/candidatesapi/PutCandidate/",
                complete: function (e) {
                    $("#grid").data("kendoGrid").dataSource.read();
                }
            },
            destroy: {
                url: "http://localhost:52811/api/candidatesapi/DeleteCandidate/",
            }
        },
        schema: {
            model: {
                id: "CandidateId",
                fields: {
                    Sirname: { type: "string" },
                    Name: { type: "string" },
                    Vacancy: { type: "string" },
                    Experience: { type: "number" },
                    PhoneNumber: { type: "string" },
                    Email: { type: "string" },
                    Status: { type: "string" }
                }
            }
        }
    }





}

function configureButtons() {

    $("#grid tbody").on("click", "tr", function (e) {

        var rowElement = this;
        var row = $(rowElement);
        var grid = $("#grid").getKendoGrid();

        if (row.hasClass("k-state-selected")) {

            var selected = grid.select();

            selected = $.grep(selected, function (x) {
                var itemToRemove = grid.dataItem(row);
                var currentItem = grid.dataItem(x);

                return itemToRemove.CandidateId != currentItem.CandidateId
            })

            grid.clearSelection();

            grid.select(selected);

            e.stopPropagation();
        } else {
            grid.select(row);

            var strip = grid.dataItem(grid.select());

            alert(strip.Sirname);

            e.stopPropagation();
        }
    });

    $("#btnCreate").click(function () {
        candidateWindow("create");
    });

}

function initGrid() {
    var dataSource = formConfig.dataSource;
    dataSource = DataSourceSettings(dataSource);
    dataSourcec = new kendo.data.DataSource(dataSource);

    var gridOptions = formConfig.gridOptions;
    gridOptions.dataSource = dataSource;
    gridOptions.toolbar = kendo.template($("#toolbarTemplate").html());
    gridOptions = GridSettings(gridOptions);
    $("#grid").kendoGrid(gridOptions);

    configureButtons();
}

$(document).ready(function () {
    initGrid();
});
