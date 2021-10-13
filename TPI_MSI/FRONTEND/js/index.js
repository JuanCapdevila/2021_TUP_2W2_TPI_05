"use strict";

$( document ).ready(function() {

    var usu = localStorage.getItem("usuario");
    //swal.fire("Bienvenido " + usu);
            
    // $.ajax({
    //     url: "",
    //     type: "GET",                
    //     success: function(result) 
    //     {                    
    //         if(result.ok)
    //         {       
    //             cargarTabla(result.return);                        
    //         }
    //         else{
    //             swal.fire(result.error);
    //         }
    //     },
    //     error: function(error) {
    //         console.log(error);
    //     }
    // });


    $.ajax({
        url: "https://localhost:5001/Marca/ObtenerMarca",
        type: "GET",
        success: function(result) {
            if(result.ok)
            {
                cargarComboMarca(result.return);                    
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

    $.ajax({
        url: "https://localhost:5001/Rubro/ObtenerRubro",
        type: "GET",
        success: function(result) {
            if(result.ok)
            {
                cargarComboRubro(result.return);                    
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

    $.ajax({
        url: "https://localhost:5001/Empaquetado/ObtenerEmpaquetado",
        type: "GET",
        success: function(result) {
            if(result.ok)
            {
                cargarComboEmpaquetado(result.return);                    
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
    
});  

function cargarTabla(datos){
    
    for (let i = 0; i < datos.length; i++) 
    {
        let html = "<tr>"; 

        html += "<td>" + datos[i].Nombre + "</td>";
        html += "<td>" + datos[i].Descripción + "</td>";
        html += "<td>" + datos[i].Stock + "</td>";
        html += "<td>" + datos[i].Marca + "</td>";
        html += "<td>" + datos[i].Rubro + "</td>";

        html += "</tr>";  
        $("#cuerpoTabla").append(html);                               
    }         
    
}     

function cargarComboMarca(datos){
    let select = document.getElementById("cboMarca");
    for (let i = 0; i < datos.length; i++) {
        var option = document.createElement('option');
        option.text = datos[i].descripcion;
        select.add(option);
    }
    console.log(select.value);
}

function cargarComboRubro(datos){
    let select = document.getElementById("cboRubro");
    for (let i = 0; i < datos.length; i++) {
        var option = document.createElement('option');
        option.text = datos[i].descripcion;
        select.add(option);
    }
    console.log(select.value);
}

function cargarComboEmpaquetado(datos){
    let select = document.getElementById("cboEmpaquetado");
    for (let i = 0; i < datos.length; i++) {
        var option = document.createElement('option');
        option.text = datos[i].descripcion;
        select.add(option);
    }
    console.log(select.value);
}