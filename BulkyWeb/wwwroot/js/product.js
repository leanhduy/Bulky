$(document).ready(function () {
    loadTable();
});

function loadTable() {
    dataTable = $('#productTable').DataTable({
        "ajax": { url: '/admin/product/getall' },
        "columns": [
            { "data": "isbn" },
            { "data": "title" },
            { "data": "author" },
            { "data": "listPrice" },
            { "data": "description" },
            { "data": "category.name" }
        ]
    });
}