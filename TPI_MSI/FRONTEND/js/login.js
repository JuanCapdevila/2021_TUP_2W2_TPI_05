"use strict";

$( document ).ready(function() {

    //AJAX para obtener los Roles
    $.ajax({
        url: "https://localhost:5001/Roles/ObtenerRoles",
        type: "GET",
        success: function(result) {
            if(result.ok)
            {
                cargarCombo(result.return);                    
            }
            else{
                Swal.fire({
                    icon: 'error',
                    title: 'Error',
                    text: 'Error al cargar el combo',

                });
            }
        },
        error: function(error) {
            console.log(error);
        }
    });  

    //Funcion para cargar el combo Roles
    function cargarCombo(datos){
        const select = document.getElementById("cboRol");
        for (let i = 0; i < datos.length; i++) {
            var option = document.createElement('option');
            option.text = datos[i].descripcion;
            select.add(option);
        }
        console.log(select.value);
    }

    $("#btnIngresar").click(function(event){
        event.preventDefault();
        const user = $("#inputusuario").val();
        const pass = $("#inputpass").val();
        const rol = $("#cboRol option:selected").index(); 

        if(!validar(user, pass, rol)){
            swal.fire("Por favor ingrese datos válidos");
            return false;
        }
        else{
            realizarLogin(user, pass, rol);            
        }
        
    });

    function validar(user, pass, rol){
        
        //Validacion Usuario
        if (user === "" || user === null){
            return false;
        }
                   
        //Validacion Contraseña
        if (pass === ""){            
            return false;         
        }

        //Validacion roles
        if(rol == 0){            
            return false;
        }       
        
        return true;
    }

    //Funcion para realizar el login
    function realizarLogin(user, pass, rol){
        const comando = {
            "usuario": user,
            "contrasenia": pass,
            "idrol": rol
        };  
        
        $.ajax({
            url: "https://localhost:5001/Login/ValidarDatos",
            type: "POST",
            dataType: "json",
            contentType: "application/json",
            data: JSON.stringify(comando),
            success: function(result) {
                if(result.ok){
                    localStorage.setItem("usuario", result.return.usuario1);//en la api del post del login aparece como usuario1                                        
                    window.location.replace("index.html");
                }
                else{
                    swal.fire(result.error);                                      
                }
            },
            error: function(error) {
                console.log(error);
            }
        });
    } 

});