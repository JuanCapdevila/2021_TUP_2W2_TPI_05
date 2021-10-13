"use strict";

$( document ).ready(function() {

    //AJAX para obtener el pais de origen
    $.ajax({
        url: "",
        type: "GET",
        success: function(result) {
            if(result.ok)
            {
                cargarComboPais(result.return);                    
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

    //AJAX para obtener las marcas
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

    //AJAX para obtener los rubros
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

    //AJAX para obtener los empaquetados
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

    function cargarComboPais(datos){
        let select = document.getElementById("cboPaisOrigen");
        for (let i = 0; i < datos.length; i++) {
            var option = document.createElement('option');
            option.text = datos[i].pais_origen;
            select.add(option);
        }
        console.log(select.value);
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
    
    $("#btnRegistrar").click(function(event){
        event.preventDefault();
        const nombre = $("#txtNombre").val();
        const desc = $("#txtDescripcion").val();
        const pais = $("#cboPaisOrigen option:selected").index(); 
        const rubro = $("#cboRubro option:selected").index(); 
        const marca = $("#cboMarca option:selected").index(); 
        const empaq = $("#cboEmpaquetado option:selected").index(); 
        const peso = $("#inputPeso").val();
        const unid = $("#inputUnidadMedida").val();
        const fragil = $("#chkFragil:checked").val();
        const stock = $("#cboStock option:selected").index(); 

        if(!validar(nombre, desc, pais, rubro, marca, empaq, peso, unid, stock)){
            swal.fire("Por favor ingrese datos válidos");
            return false;
        }
        else{            
            realizarAlta(nombre, desc, pais, rubro, marca, empaq, peso, unid, fragil, stock);            
        }
        
    });

    function validar(nombre, desc, pais, rubro, marca, empaq, peso, unid, stock){
        
        //Validacion nombre
        if (nombre == "" || /\d/.test(nombre)){
            return false;
        }
                   
        //Validacion descripcion
        if (desc === ""){            
            return false;         
        }

        //Validacion pais
        if(pais == 0){            
            return false;
        }  
        
        //Validacion rubro
        if(rubro == 0){            
            return false;
        }

        //Validacion marca
        if(marca == 0){            
            return false;
        }

        //Validacion empaq
        if(empaq == 0){            
            return false;
        }

        //Validacion peso
        if (peso === "" || peso == 0){
            return false;
        }

        //Validacion unid
        if (unid === "" || /\d/.test(unid)){
            return false;
        }

        //Validacion stock
        if(stock == 0){            
            return true;
        }
        
        return true;
    }

    //Funcion para realizar el login
    function realizarAlta(nombre, desc, pais, rubro, marca, empaq, peso, unid, fragil, stock){
        const comando = {};  
        //"falta copiar acá el body desde el swagger para mayor exactitud"
        
        $.ajax({
            url: "",
            type: "POST",
            dataType: "json",
            contentType: "application/json",
            data: JSON.stringify(comando),
            success: function(result) {
                if(result.ok){
                    swal.fire("Registro exitoso");
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