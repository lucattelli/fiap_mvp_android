$(document).ready(function () {
    $("#loginform").validate({
       	errorContainer: $("#errorbox"),
       	errorLabelContainer: $("ul", $("#errorbox")),
       	wrapper: "li",
       	rules: {
       		email: {
       			required: true,
       			email: true
       		},
       		senha: {
       			required: true
       		}      		
       	},
       	messages : {
       		email: {
       			required: "Preencha o campo email.",
       			email: "Preencha o campo email no formato \"abc@xyz.com.\""
       		},
       		senha : {
       			required: "Preencha o campo senha."
       		}
       	}
       	
    
    });
    
    $("#email").focus();
});