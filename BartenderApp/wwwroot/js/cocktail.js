




function placeOrder(id) {

    $.ajax({
        type: "GET",
        url: "/Admin/Order/Insert?id=" + id,
        success: function (data) {
            dataTable.clear();
            dataTable.rows.add(data.data).draw();
        }
    });
}