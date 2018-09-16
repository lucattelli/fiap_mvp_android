$(document).ready(function () {
    $("#produtoform").validate({
    	errorContainer: $("#errorbox"),
       	errorLabelContainer: $("ul", $("#errorbox")),
       	wrapper: "li",
       	rules: {
       		nome: {
       			required: true,
       		},
       		pesomedio: {
       			required: true,
       		},
       		pesominimo: {
       			//required: true,
       			//digits: true
       		},
       		pesomaximo: {
       			//required: true,
       			//minlength: 3
       		}
    	},
    	messages: {
    		nome: {
    			required: "Preencha o campo nome.",
    		},
    		pesomedio: {
    			required: "Preencha o campo peso médio.",
    			//digits: "Preencha o campo CPF no formato \"99999\".",
				//minlength: "Preencha o campo RG com no mínimo 3 caracteres."
    		},
    		pesominimo: {
    			//required: "Preencha o campo RG.",
    			//minlength: "Preencha o campo RG com no mínimo 3 caracteres."
    		},
    		pesomaximo: {
    			//required: "Preencha o campo Email.",
    			//minlength: "Preencha o campo Email com no mínimo 3 caracteres."
    		}
    	}
    });
	$("#nome").focus();
});