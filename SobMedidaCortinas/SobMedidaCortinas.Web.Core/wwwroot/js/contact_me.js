$(function() {

    $("#contactForm input,#contactForm textarea").jqBootstrapValidation({
        preventSubmit: true,
        submitError: function($form, event, errors) {
            // additional error messages or events
        },
        submitSuccess: function($form, event) {
            event.preventDefault(); // prevent default submit behaviour
            // get values from FORM
            var name = $("input#name").val();
            var firstName = name; // For Success/Failure Message
            // Check for white space in name for Success/Fail message
            if (firstName.indexOf(' ') >= 0) {
                firstName = name.split(' ').slice(0, -1).join(' ');
            }

	        var submitLabel = $("#contactFormSubmit").html();

	        $("#contactFormSubmit").prop("disabled", "disabled");
	        $("#contactFormSubmit").html("Enviando...");

            $.ajax({
                url: "/contato/index",
                type: "POST",
                data: $("#contactForm").serialize(),
                cache: false,
                success: function() {
                    
                	$("#contactForm").hide();
                	$("#contactFormResult").removeClass("hide").show('slow');

                	$('html, body').animate({
                		scrollTop: $("#contato").offset().top + 50
                	}, 500);

                    ////clear all fields
                    //$('#contactForm').trigger("reset");
                },
                error: function (response) {

                	var errorMessage = "<strong>Desculpe " + firstName + ", parece que o site teve algum problema e sua mensagem não foi enviada. Por favor contate-nos por telefone ou tente mais tarde.";

                    if (!!response && response.responseText == "invalidCaptcha") {
                        errorMessage = "Por favor indique se você é um robô.";
                    } else if (!!response && response.responseText == "emailFailed") {
                        errorMessage = "Por favor, verifique o seu endereço de e-mail está correto e tente novamente";
                    }
                    
                	// Fail message
                	$('#success').html("<div class='alert alert-danger'>");
                	$('#success > .alert-danger').html("<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;")
                        .append("</button>");
                    $('#success > .alert-danger').append(errorMessage);
                    $('#success > .alert-danger').append('</div>');

                	////clear all fields
                    //$('#contactForm').trigger("reset");
                }
            }).always(function() {
            	$("#contactFormSubmit").html(submitLabel);
            	$("#contactFormSubmit").prop("disabled", "");
            });
        },
        filter: function() {
            return $(this).is(":visible");
        },
    });

    $("a[data-toggle=\"tab\"]").click(function(e) {
        e.preventDefault();
        $(this).tab("show");
    });
});


/*When clicking on Full hide fail/success boxes */
$('#name').focus(function() {
    $('#success').html('');
});
