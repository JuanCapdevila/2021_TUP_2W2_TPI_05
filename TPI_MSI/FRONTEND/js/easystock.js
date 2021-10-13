"use strict";

$( document ).ready(function() {

    $("#btnIngresar").click(function(){
          
        if (validar()){
            location.replace("index.html");  
            console.log("Pasaron las validaciones");              
        }      
        
    });

    function validar(){
        
        //Validacion Email
        var expr = /^[a-zA-Z0-9_\.\-]+@[a-zA-Z0-9\-]+\.[a-zA-Z0-9\-\.]+$/;
        var email = $("#inputemail");
        if (email.val() == "" || !expr.test(email.val())){
            swal.fire("Por favor, introduzca un correo válido. Gracias");
            return false;
        }
                   
        //Validacion Contraseña
        var pass = $("#inputpass");
        if (pass.val() === ""){
            console.log("asda");
            swal.fire("Por favor, introduzca una contraseña válida. Gracias");           
            //contra.focus();
            return false;         
        }

        //Validacion roles
        var rol = $("#cboRol option:selected").index(); 
        if(rol == 0){
            swal.fire("Por favor seleccione un rol. Gracias.");
            return false;
        }       
        
        return true;
    }

    

});