$(document).ready(function () {
    initGrid();
});

function initGrid() {
    gridOptions.dataSource = dataSource;
    gridOptions.toolbar = kendo.template($("#toolbarTemplate").html());
    $("#grid").kendoGrid(gridOptions);
}

var dataSource = new kendo.data.DataSource({
    transport: {
        read: {
            url: "http://localhost:52811/api/candidatesapi/GetCandidates/",
            type: "get",
            dataType: "json"
        },
        create: {
            url: "http://localhost:52811/api/candidatesapi/PostCandidate/",
            type: "post",
            dataType: "json",
            complete: function (e) {
                $("#grid").data("kendoGrid").dataSource.read();
            }
        },
        update: {
            url: "http://localhost:52811/api/candidatesapi/PutCandidate/",
            type: "put",
            dataType: "json",
            complete: function (e) {
                $("#grid").data("kendoGrid").dataSource.read();
            }
        },
        destroy: {
            url: "http://localhost:52811/api/candidatesapi/DeleteCandidate/",
            type: "delete",
            dataType: "json"
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
    },
    pageSize: 20
});


var gridOptions = {
    scrollable: false,
    selectable: "row",
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
        alwaysVisible: true,
        buttonCount: 5,
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
        },
        {
            command: [{
                name: "  Details",
                iconClass: "k-icon k-i-info",
                click: function (e) {
                    e.preventDefault(); // prevent page scroll position change
                    // e.target is the DOM element representing the button
                    var tr = $(e.target).closest("tr"); // get the current table row (tr)
                    // get the data bound to the current table row
                    var data = this.dataItem(tr);
                    var id = data.Id;
                    if (id != undefined && id != 0) {
                        window.location = 'http://localhost:65424/Home/OrganisationBills/' + id;

                    }
                }
            },],
            title: "&nbsp;",
            width: "100px"
        }],
    createAt: 'bottom'
}



