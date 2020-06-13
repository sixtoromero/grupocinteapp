var oTableUsers;

var URL = 'http://localhost:63842/';

$(document).ready(function () {
    ConfigTable();
    GetTiposdeIdentificacion();
    GetUsuarios();

    $("#txtNumero").inputFilter(function (value) {
        return /^\d*$/.test(value);
    });

    $("#txtIDUsuario").val(0);

});

$.fn.inputFilter = function (inputFilter) {
    return this.on("input keydown keyup mousedown mouseup select contextmenu drop", function () {
        if (inputFilter(this.value)) {
            this.oldValue = this.value;
            this.oldSelectionStart = this.selectionStart;
            this.oldSelectionEnd = this.selectionEnd;
        } else if (this.hasOwnProperty("oldValue")) {
            this.value = this.oldValue;
            this.setSelectionRange(this.oldSelectionStart, this.oldSelectionEnd);
        }
    });
};

function ConfigTable() {
    var dtData = []; oTableUsers = $('#GridUsuarios').dataTable({
        'aaData': dtData,
        "sPaginationType": "full_numbers",
        "sPageButton": "paginate_button",
        "sPageButtonActive": "paginate_active",
        "sPageButtonStaticDisabled": "paginate_buttond",
        "iDisplayLength": 10,
        "bAutoWidth": false,
        "aoColumns": [{ "sWidth": "25%" }, { "sWidth": "25%" }, { "sWidth": "25%" }, { "sWidth": "15%" }],
        "oLanguage": {
            "sProcessing": "Procesando...",
            "sLengthMenu": "Mostrar _MENU_ registros",
            "sZeroRecords": "No se encontraron resultados",
            "sInfo": "Mostrando desde _START_ hasta _END_ de _TOTAL_ registros",
            "sInfoEmpty": "Mostrando desde 0 hasta 0 de 0 registros",
            "sInfoFiltered": "(filtrado de _MAX_ registros en total)",
            "sInfoPostFix": "",
            "sSearch": "Buscar:",
            "sUrl": "",
            "oPaginate": {
                "sFirst": "Primero",
                "sPrevious": "Anterior",
                "sNext": "Siguiente",
                "sLast": "Último"
            }
        }
    });
}

function validar_email(email) {
    var regex = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    return regex.test(email) ? true : false;
}

function ValidForm() {

    if ($('#txtNombres').val().length === 0) {
        Swal.fire({
            icon: 'warning',
            title: 'Campo requerido',
            text: 'El campo Nombres es requerido ',
            footer: '<a href>el * indica que es requerido</a>'
        });

        return false;
    }

    if ($('#txtApellidos').val().length === 0) {
        Swal.fire({
            icon: 'warning',
            title: 'Campo requerido',
            text: 'El campo Apellidos es requerido ',
            footer: '<a href>el * indica que es requerido</a>'
        });

        return false;
    }

    if ($('#cboTipoId').val().length === 0) {
        Swal.fire({
            icon: 'warning',
            title: 'Campo requerido',
            text: 'El campo Tipo de Identificación es requerido',
            footer: '<a href>el * indica que es requerido</a>'
        });

        return false;
    }

    let result = validar_email($('#txtCorreo').val());
    if (!result) {
        Swal.fire({
            icon: 'warning',
            title: 'Formato inválido',
            text: 'Ha registrado un correo inválido',
            footer: '<a href>Si el problema persiste contactenos?</a>'
        });

        return false;
    }

    if ($('#txtNumero').val().length === 0) {
        Swal.fire({
            icon: 'warning',
            title: 'Campo requerido',
            text: 'El campo Número de Identificación es requerido ',
            footer: '<a href>el * indica que es requerido</a>'
        });

        return false;
    }

    if ($('#txtContrasena').val().length > 0) {
        if ($('#txtContrasena').val().length < 5) {
            Swal.fire({
                icon: 'warning',
                title: 'Campo inválido',
                text: 'Ha registrado una clave muy corta',
                footer: '<a href>la contraseña debe ser igual o superior a 5 caracteres</a>'
            });

            return false;
        }
    } else {
        Swal.fire({
            icon: 'warning',
            title: 'Campo requerido',
            text: 'El campo Contraseña es requerido',
            footer: '<a href>el * indica que es requerido</a>'
        });

        return false;
    }

    return true;
}

function GetTiposdeIdentificacion() {

    $("#cboTipoId").empty();
    $("#cboTipoId").append("<option  value=''></option>");

    $.ajax({
        type: "GET",
        url: URL + 'api/TipoId/GetAllAsync',
        data: {},
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.IsSuccess === true) {
                if (data.Data.length > 0) {
                    $(data.Data).each(function () {
                        $("#cboTipoId").append("<option  value='" + this.IDTipoId + "'>" + this.Nombre + "</option>");
                    });
                }
            } else {
                Swal.fire({
                    icon: 'error',
                    title: 'Oops...',
                    text: 'Ha ocurrido un error inesperado!',
                    footer: '<a href>Si el problema persiste contactenos?</a>'
                });
            }
        },
        complete: function () {
        },
        error: function (data) {
            //alert("Error: " + data.responseText);
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Ha ocurrido un error inesperado!',
                footer: '<a href>Si el problema persiste contactenos?</a>'
            });
        } //fin error
    });    //Fin Cargar Combo
}

function GetUsuarios() {

    let param = '';

    $.ajax({
        type: "GET",
        url: URL + 'api/Usuarios/GetAllAsync',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.IsSuccess === true) {
                if (data.Data.length > 0) {

                    oTableUsers.fnClearTable();

                    $(data.Data).each(function () {
                        param = this.IDUsuario + '|' + this.Nombres + '|' + this.Apellidos + '|' + this.IDTipoId + '|' + this.Numero + '|' + this.Contrasena + '|' + this.Correo;
                        oTableUsers.fnAddData([this.Nombres,
                            this.Apellidos,
                            this.Correo,
                            '<table><tr><td><a class="btn btn-danger" href="#" role="button" onclick="EliminarRegistro(' + this.IDUsuario + ');">eliminar</a></td><td><a class="btn btn-primary" href="#"  onclick="EditarForm(' + "'" + param + "'" + ');" role="button">editar</a></td></tr></table>']);
                    });
                }
            } else {
                Swal.fire({
                    icon: 'error',
                    title: 'Oops...',
                    text: 'Ha ocurrido un error inesperado!',
                    footer: '<a href>Si el problema persiste contactenos?</a>'
                });
            }
        },
        complete: function () {
        },
        //error: ErrorGeneralCallBackGMS
        error: function (data) {
            //alert("Error: " + data.responseText);
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Ha ocurrido un error inesperado!',
                footer: '<a href>Si el problema persiste contactenos?</a>'
            });
        } //fin error
    });    //Fin Cargar Combo
}

function GetCorreo() {

    $.ajax({
        type: "GET",
        url: URL + 'api/Usuarios/GetCorreo?Correo=' + $("#txtCorreo").val(),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            //oTableUsers.fnClearTable();
            if (data.IsSuccess === true) {
                if (data.Data != null) {
                    if (data.Data.length > 0) {
                        Swal.fire({
                            icon: 'warning',
                            title: 'Correo ya tomado',
                            text: 'Por favor registre un correo que no exista en nuestra base de datos',
                            footer: '<a href>el * indica que es requerido</a>'
                        });
                        return true;
                    } else {
                        
                        return false;
                    }
                } else {
                    Swal.fire({
                        icon: 'error',
                        title: 'Oops...',
                        text: 'Ha ocurrido un error inesperado!',
                        footer: '<a href>Si el problema persiste contactenos?</a>'
                    });

                    return false;
                }
            } else {
                Swal.fire({
                    icon: 'error',
                    title: 'Oops...',
                    text: 'Ha ocurrido un error inesperado!',
                    footer: '<a href>Si el problema persiste contactenos?</a>'
                });
            }
        },
        complete: function () {

        },
        error: function (data) {
            //alert("Error: " + data.responseText);
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Ha ocurrido un error inesperado!',
                footer: '<a href>Si el problema persiste contactenos?</a>'
            });
        } //fin error
    });    //Fin Cargar Combo
}



function InsertUsuarios() {
    if (ValidForm()) {

        if (!GetCorreo()) {

            let URI = 'api/Usuarios/InsertAsync';
            let Tipo = 'POST';

            var params = new Object();

            if ($("#txtIDUsuario").val() != '0') {
                params.IDUsuario = $("#txtIDUsuario").val();
                URI = 'api/Usuarios/UpdateAsync';
                Tipo = 'PUT';
            }

            params.Nombres = $("#txtNombres").val();
            params.Apellidos = $("#txtApellidos").val();
            params.IDTipoId = $("#cboTipoId").val();
            params.Numero = $("#txtNumero").val();
            params.Contrasena = $("#txtContrasena").val();
            params.Correo = $("#txtCorreo").val();

            let model = JSON.stringify(params);

            $.ajax({
                type: Tipo,
                url: URI,
                data: model,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.Data == true) {

                        $("#txtIDUsuario").val(0);

                        Swal.fire({
                            icon: 'success',
                            title: 'Bien hecho',
                            text: 'Registro ingresado exitosamente.',
                            footer: '<a href="https://grupocinte.com/grupocintecolombia/">GRUPO CINTE</a>'
                        });
                        $('#frmUsers').trigger("reset");
                        GetUsuarios();
                    }
                },
                complete: function () {
                },
                error: function (data) {
                    Swal.fire({
                        icon: 'error',
                        title: 'Oops...',
                        text: 'Ha ocurrido un error inesperado!',
                        footer: '<a href>Si el problema persiste contactenos?</a>'
                    });
                } //fin error
            });  //Fin
        }
    }
}

function EliminarRegistro(IDUsuario) {

    $.ajax({
        type: "DELETE",
        url: URL + 'api/Usuarios/DeleteAsync?IDUsuario=' + IDUsuario,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            console.log(data);
            if (data.IsSuccess === true) {
                if (data.Data === true) {
                    Swal.fire({
                        icon: 'success',
                        title: 'Bien hecho',
                        text: 'Registro eliminado exitosamente.',
                        footer: '<a href="https://grupocinte.com/grupocintecolombia/">GRUPO CINTE</a>'
                    });
                    GetUsuarios();
                }
            } else {
                Swal.fire({
                    icon: 'error',
                    title: 'Oops...',
                    text: 'Ha ocurrido un error inesperado!',
                    footer: '<a href>Si el problema persiste contactenos?</a>'
                });
            }
        },
        complete: function () {

        },
        error: function (data) {
            console.log("Error: " + data.responseText);
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Ha ocurrido un error inesperado!',
                footer: '<a href>Si el problema persiste contactenos?</a>'
            });
        } //fin error
    });    //Fin Cargar Combo
}

function EditarForm(item) {
    var pos = item.split('|');

    $('#txtIDUsuario').val(pos[0]);
    $('#txtNombres').val(pos[1]);
    $('#txtApellidos').val(pos[2]);
    $('#cboTipoId').val(pos[3]);
    $('#txtNumero').val(pos[4]);
    $('#txtContrasena').val(pos[5]);
    $('#txtCorreo').val(pos[6]);    
}