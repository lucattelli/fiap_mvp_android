$(document).ready(function () {
    $("#clienteform").validate({
    	errorContainer: $("#errorbox"),
       	errorLabelContainer: $("ul", $("#errorbox")),
       	wrapper: "li",
       	rules: {
       		nome: {
       			required: true,
       		},
       		cpf: {
       			required: true,
       			digits: true
       		},
       		rg: {
       			required: true,
       			digits: true
       		},
       		email: {
       			required: true,
       			minlength: 3
       		},
       		telefone: {
       			required: false,
       			digits:true
       		}
    	},
    	messages: {
    		nome: {
    			required: "Preencha o campo nome.",
    		},
    		cpf: {
    			required: "Preencha o campo CPF.",
    			digits: "Preencha o campo CPF no formato \"99999\".",
				minlength: "Preencha o campo RG com no mínimo 3 caracteres."
    		},
    		rg: {
    			required: "Preencha o campo RG.",
    			minlength: "Preencha o campo RG com no mínimo 3 caracteres."
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