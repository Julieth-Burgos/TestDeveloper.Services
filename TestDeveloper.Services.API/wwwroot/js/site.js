// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
(function ($, window, document, undefined) {
    "use strict";

    $(document).ready(function () {

        // Obtiene el listado de autores para registrar los libros
        function GetAuthorList(field) {
            var selectOptions = document.querySelector(field);

            for (var i = selectOptions.options.length; i >= 0; i--) {
                selectOptions.remove(i);
            }

            var urlgetAuthors = window.location.href + "api/v1/Author/GetAuthorList";

            $.ajax({
                url: urlgetAuthors,
                type: 'GET',
                contentType: "application/json;charset=utf-8",
                success: function (data) {
                    console.log(data);
                    $.each(data, function (i, item) {
                        $(field).append($('<option>', {
                            value: item.authorId,
                            text: (item.name)
                        }));
                    });
                },
                error: function (error) {
                    console.log("Hubo un error al obtener la información de los autores");
                    console.log(error);
                }
            });
        }

        // Obtiene el listado de libros registrados
        var getBooksUrl = window.location.href + "api/v1/Book/GetBookList";

        var table = $('#example').DataTable({
            "ajax": {
                "url": getBooksUrl,
                "type": "GET",
                complete: function (response) {
                },
                error: function (error) {
                    console.log(error);
                }
            },
            "columns": [
                {
                    "data": "bookId",
                    "visible": false
                },
                {
                    "data": "title"
                },
                {
                    "data": "year"
                },
                {
                    "data": "numberPages"
                },
                {
                    "data": "authorId",
                    "visible": false
                },
                {
                    "data": "name"
                },
                {
                    "defaultContent": "<button class='btn btn-info btn-sm' data-toggle='modal' data-target='#EditBookModal'>Editar</button>" +
                        "<button class='btn btn-danger btn-sm' data-toggle='modal' data-target='#DeleteBookModal'>Borrar</button>"
                }
            ],
            "language": {
                "sLengthMenu": "<strong>Mostrar</strong> _MENU_ <strong>registros</strong>",
                "sSearch": "<strong>Filtrar: </strong>",
                "sProcessing": '<i class="fa fa-spinner fa-pulse fa-3x fa-fw"></i><span class="sr-only">Procesando...</span>',
                "sZeroRecords": "No se encontraron resultados",
                "sEmptyTable": "No hay información a mostrar",
                "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros.",
                "sInfo": "Mostrando página _PAGE_ de _PAGES_",
                "oPaginate": {
                    "sFirst": "Primero",
                    "sLast": "Último",
                    "sNext": "Siguiente",
                    "sPrevious": "Anterior"
                }
            }
        });

        $('#example tbody').on('click', 'tr', function () {
            var dataSelectTable;
            var queryTable = $('#example').DataTable();
            var rowSelect = $(this);

            if (queryTable.data().any()) {
                var dataIndex = queryTable.row(rowSelect).data();

                if (typeof dataIndex !== "undefined") {
                    dataSelectTable = dataIndex;
                }

                if (typeof dataIndex === "undefined") {
                    dataIndex = dataSelectTable;
                }

                GetAuthorList('#EditbookAuthor');

                document.getElementById("DeleteBookId").value = dataSelectTable.bookId;

                document.getElementById("EditbookId").value = dataSelectTable.bookId;
                document.getElementById("EditbookTitle").value = dataSelectTable.title;
                document.getElementById("EditbookYear").value = dataSelectTable.year;
                document.getElementById("EditbookNumberPages").value = dataSelectTable.numberPages;
                //$("#EditbookAuthor").val(dataSelectTable.authorId);

                var option = $('#EditbookAuthor > option[value="' + dataSelectTable.authorId + '"]')[0];
                //option.setAttribute('selected', true);
            }
        });

        // Guarda la información del nuevo autor
        var saveAuthor = document.getElementById("SaveAuthor");

        saveAuthor.addEventListener('click', function (event) {
            event.preventDefault();

            $('#AddAuthorModal').modal('hide');

            var formData = {
                "Name": document.getElementById("authorFullname").value,
                "Birthday": document.getElementById("authorBirthday").value,
                "City": document.getElementById("authorCity").value,
                "Email": document.getElementById("authorEmail").value,
            };

            var createAuthorUrl = window.location.href + "api/v1/Author/AddAuthor";

            $.ajax({
                type: 'POST',
                url: createAuthorUrl,
                contentType: "application/json;charset=utf-8",
                data: JSON.stringify(formData),
                success: function (data) {
                    swal({
                        title: "Proceso exitoso!",
                        text: data,
                        icon: "success",
                        button: "OK!",
                    });
                },
                error: function (error) {
                    swal({
                        title: "Lo sentimos!",
                        text: "Hubo un error al crear el autor: " + error.responseText,
                        icon: "error",
                        button: "OK!",
                    });
                    console.log(error);
                }
            });

        });

        // Guarda la información del nuevo libro
        var saveBook = document.getElementById("SaveBook");

        saveBook.addEventListener('click', function (event) {
            event.preventDefault();

            $('#AddBookModal').modal('hide');

            var formData = {
                "Title": document.getElementById("bookTitle").value,
                "Year": document.getElementById("bookYear").value,
                "NumberPages": document.getElementById("bookNumberPages").value,
                "AuthorId": $('#bookAuthor option:selected').val(),
            };

            var createBookUrl = window.location.href + "api/v1/Book/AddBook";

            $.ajax({
                type: 'POST',
                url: createBookUrl,
                contentType: "application/json;charset=utf-8",
                data: JSON.stringify(formData),
                success: function (data) {
                    swal({
                        title: "Proceso exitoso!",
                        text: data,
                        icon: "success",
                        button: "OK!",
                    }).then(function (value) {
                        location.reload();
                    });                    
                },
                error: function (error) {
                    swal({
                        title: "Lo sentimos!",
                        text: "Hubo un error al crear el libro" + error.responseText,
                        icon: "error",
                        button: "OK!",
                    });
                    console.log(error);
                }
            });
        });

        $('#AddBookModal').on('shown.bs.modal', function () {
            GetAuthorList('#bookAuthor');
        });

        // Actualiza la información de un libro especifico
        var saveBookChanges = document.getElementById("saveBookChanges");

        saveBookChanges.addEventListener('click', function (event) {
            event.preventDefault();

            $('#EditBookModal').modal('hide');

            var formData = {
                "BookId": document.getElementById("EditbookId").value,
                "Title": document.getElementById("EditbookTitle").value,
                "Year": document.getElementById("EditbookYear").value,
                "NumberPages": document.getElementById("EditbookNumberPages").value,
                "AuthorId": $('#EditbookAuthor option:selected').val(),
            };

            var updateBookUrl = window.location.href + "api/v1/Book/UpdateBook";

            $.ajax({
                type: 'PUT',
                url: updateBookUrl,
                contentType: "application/json;charset=utf-8",
                data: JSON.stringify(formData),
                success: function (data) {
                    swal({
                        title: "Proceso exitoso!",
                        text: data,
                        icon: "success",
                        button: "OK!",
                    }).then(function (value) {
                        location.reload();
                    });
                },
                error: function (error) {
                    swal({
                        title: "Lo sentimos!",
                        text: "Hubo un error al actualizar la información del libro",
                        icon: "error",
                        button: "OK!",
                    });
                    console.log(error);
                }
            });
        });

        // Elimina la información de un libro especifico
        $('#DeleteBookModal').on('shown.bs.modal', function () {
            var bookId = document.getElementById('DeleteBookId').value;
            swal({
                title: "¿Esta seguro?",
                text: "Una vez eliminado, ¡no podrá recuperar el registro!",
                icon: "warning",
                buttons: true,
                dangerMode: true,
            }).then(function (value) {
                if (value) {
                    $('#DeleteBookModal').modal('hide');
                    var deleteBookUrl = window.location.href + "api/v1/Book/DeleteBook?bookId=" + bookId;

                    $.ajax({
                        type: 'DELETE',
                        url: deleteBookUrl,
                        contentType: "application/json;charset=utf-8",
                        success: function (data) {
                            swal({
                                title: "Proceso exitoso!",
                                text: data,
                                icon: "success",
                                button: "OK!",
                            }).then(function (value) {
                                location.reload();
                            });
                        },
                        error: function (error) {
                            swal({
                                title: "Lo sentimos!",
                                text: "Hubo un error al actualizar la información del libro",
                                icon: "error",
                                button: "OK!",
                            });
                            console.log(error);
                        }
                    });
                }
            });
        });
    });

})(jQuery, window, document);

