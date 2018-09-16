$(document).ready(function () {
    $("#ClienteAlterar_CPF").mask("000.000.000-00", {reverse: true});
    $("#ClienteAlterar_RG").mask("000.000.000.000-A", {reverse: true});

    $("#ClienteAlterar_Telefone").mask("(00) 0000-00009");
    $("#ClienteAlterar_Telefone").blur(function(event) {
	   if($(this).val().length == 15) { // Celular com 9 dígitos + 2 dígitos DDD e 4 da máscara
           $("#ClienteAlterar_Telefone").mask("(00) 00000-0009");
	   } else {
           $("#ClienteAlterar_Telefone").mask("(00) 0000-00009");
	   }
	});
	
    $(".tdCPF").mask("000.000.000-00", {reverse: true});
    $(".tdRG").mask("000.000.000.000-A", {reverse: true});
    $(".tdTelefone").mask("(00) 0000-00009");

    $("#clienteform").validate({
    	errorContainer: $("#errorbox"),
       	errorLabelContainer: $("ul", $("#errorbox")),
       	wrapper: "li",
       	rules: {
       		nome: {
       			required: true,
       		},
       		cpf: {
       			required: true
       		},
       		rg: {
       			required: true
       		},
       		email: {
       			required: true,
       			minlength: 3
       		},
       		telefone: {
       			required: false
       		}
    	},
    	messages: {
    		nome: {
    			required: "Preencha o campo nome.",
    		},
    		cpf: {
    			required: "Preencha o campo CPF."
    		},
    		rg: {
    			required: "Preencha o campo RG."
    		},
    		email: {
    			required: "Preencha o campo Email.",
    			minlength: "Preencha o campo Email com no mínimo 3 caracteres."
    		},
    		telefone: {
    			minlength: "Preencha o campo Telefone com no mínimo 10 caracteres."
    		}
    	}
    });
	$("#nome").focus();
});