"use strict";

$( document ).ready(function() {

    $("#btnIngresar").click(function(){

        if (validar()){
            location.replace("index.html");  
            console.log("es falso e igual entra");              
        }      
        
    });

    function validar(){
        
        //Validacion Email
        var expr = /^[a-zA-Z0-9_\.\-]+@[a-zA-Z0-9\-]+\.[a-zA-Z0-9\-\.]+$/;
        var email = $("#inputemail");
        if (email.val() == "" || !expr.test(email.val())){
            swal("Por favor, introduzca un correo válido. Gracias");
            return false;
        }
                   
        //Validacion Contraseña
        var pass = $("#inputpass");
        if (pass.val() === ""){
            console.log("asda");
            swal("Por favor, introduzca una contraseña válida. Gracias");           
            //contra.focus();
            return false;         
        }

        var rol = $("#cboRol option:selected").index(); 
        if(rol == 0){
            swal("Por favor selecciones una rol. Gracias.");
            return false;
        }
        
        
        console.log("esto entra");
        return true;
    }

    

});