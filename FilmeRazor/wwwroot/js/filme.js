var dataTable;

$(document).ready(function () {
    carregarDataTable();
});

function carregarDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/api/filme",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "id", "width": "5%" },
            { "data": "titulo", "width": "25%" },
            { "data": "dataLancamento", "width": "20%" },
            { "data": "genero", "width": "10%" },
            { "data": "preco", "width": "10%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                        <a href="/filme/InserirAtualizar?id=${data}" class='btn btn-success text-white' style='cursor:pointer; width:70px;'>
                            Editar
                        </a>
                        &nbsp;
                        <a class='btn btn-danger text-white' style='cursor:pointer; width:70px;'
                            onclick=Delete('/filme/Delete?id='+${data})>
                            Excluir
                        </a>
                        </div>`;
                }, "width": "30%"
            }
        ],
        "language": {
            "emptyTable": "não existe filme."
        },
        "width": "100%"
    });
}

function Delete(url) {
    swal({
        title: "Deseja excluir o registro?",
        text: "Depois de excluído, você não será capaz de recuperar",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}