var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#bookTable').DataTable({
        "ajax": {
            url: '/book/getall'
        },
        scrollX: true,
        "columns": [
            { data: 'title', "width": "20%" },
            { data: 'author', "width": "10%" },
            { data: 'publicatiionYear', "width": "10%" },
            { data: 'genre', "width": "10%" },
            { data: 'price', "width": "10%" },
            {
                data: 'id',
                "render": function (data) {
                    return `
                        <div class="w-75 btn-group" role="group" >
                            <a onClick=Delete('/book/delete?id=${data}') class="btn btn-outline-danger mx-2" >
                            <i class="bi bi-trash-fill"></i> Delete
                            </a >
                            <a href="/book/edit?id=${data}" class="btn btn-outline-success mx-2">
                               <i class="bi bi-pencil-square"></i> Edit
                            </a>
                        </div>
                    `
                },
                "width": "5%"
            }
        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                }
            })
        }
    })
}
