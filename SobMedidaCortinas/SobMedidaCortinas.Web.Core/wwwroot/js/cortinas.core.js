// jQuery for page scrolling feature - requires jQuery Easing plugin
$(function () {
	$('a.page-scroll').bind('click', function (event) {
		var $anchor = $(this);
		$('html, body').stop().animate({
			scrollTop: $($anchor.attr('href')).offset().top
		}, 1500, 'easeInOutExpo');
		event.preventDefault();
	});
});

// Highlight the top nav as scrolling occurs
$('body')
	.scrollspy({
		target: '.navbar-fixed-top'
	});

// Closes the Responsive Menu on Menu Item Click
$('.navbar-collapse ul li a:not(.dropdown-toggle)').click(function () {
	$('.navbar-toggle:visible').click();
});

//LINK HANDLERS
$(function () {

	//Google Analytics
	$('body').on('click', 'a[data-ga]', function () {
		var title = $(this).attr("href").replace(/#/g, ""),
			gaLabel = $(this).data('ga');

		if (ga) {
			ga('send', 'pageview', gaLabel || title);
		}
	});
});

//Glosario
$(function () {

	var items = [
		{
			label: "Argolas",
			description: "São anéis de plástico, madeira ou metal que sustentam cortinas no varões."
		},
		{
			label: "Bandô",
			description:
				"Ornamento de tecido fixado na parte superior da cortina com a finalidade de esconder os trilhos ou enfeitar a cortina."
		},
		{
			label: "Barra",
			description: "É a dobra de costura na parte inferior que dá acabamento à cortina. Também pode ser chamada de bainha."
		},
		{
			label: "Blackout ou Blecaute",
			description:
				"Cortina encorpada de material grosso que impede a luz de entrar no ambiente, feita de PVC ou de uma mistura desse material com tecido."
		},
		{
			label: "Braçadeira",
			description:
				"Faixa ou cordão com a funcionalidade de amarrar a cortina nas laterais deixando às aberta. Mesmo que abraçadeira."
		},
		{
			label: "Chumbinho",
			description:
				"Vareta metálica revestida de tecido, que fica oculta na barra. Seu objetivo é impedir que a peça se torne esvoaçante demais fazendo peso."
		},
		{
			label: "Cós",
			description: "Barra na parte superior da cortina"
		},
		{
			label: "Entretela",
			description: "Tecido bem estruturado que dá firmeza ao cós (usada em colarinhos)."
		},
		{
			label: "Forro",
			description:
				"É um acessório opcional, que protege o tecido principal da luz do sol e reduz sua transparência. Confeccionado em tecido neutro e liso. Isto ajuda a reforçar o isolamento acústico e térmico."
		},
		{
			label: "Franzidor",
			description: "Aviamento que ajuda a franzir a cortina de maneira uniforme. Geralmente quando costurado ao cós."
		},
		{
			label: "Gancho para braçadeira",
			description: "Suporte aparafusado na parede para encaixe da braçadeira."
		},
		{
			label: "Ilhoses",
			description:
				"Aros de plástico, madeira ou metal fixados em torno de aberturas no cós, através dos quais pode-se pendurar a cortina no varão."
		},
		{
			label: "Painel",
			description:
				"Cortina formada por painéis – como uma lona, em geral de tecido encorpado, que correm horizontalmente no trilho."
		},
		{
			label: "Ponteira",
			description: "Acessório que ornamenta e arremata as extremidades do varão."
		},
		{
			label: "Prega americana",
			description:
				"Dobra tripla no arremate superior da cortina (o cós), que produz um franzido virado para o teto que produz um efeito diferente do franzido e pode cobrir o trilho."
		},
		{
			label: "Prega fêmea",
			description: "Formada de duas dobras, em sentidos opostos, que se encontram no lado da frente do tecido."
		},
		{
			label: "Prega macho",
			description: "Formada de duas dobras, em sentidos opostos, que se aproximam no avesso do tecido."
		},
		{
			label: "Prega paulista ou wave",
			description: "Dobras que produzem um efeito de ondulação intercaladas nos dois sentidos."
		},
		{
			label: "Rodízio",
			description: "Acessório com rodinhas que é costurado ao tecido. Isto possibilita à cortina correr em trilhos."
		},
		{
			label: "Sanca",
			description: "Estrutura de madeira, metal, gesso ou plástico, fixada no teto, para esconder o varão ou trilho."
		},
		{
			label: "Terminal",
			description: "Peça encaixada no trilho para travar a saída dos rodízios."
		},
		{
			label: "Tiras",
			description:
				"Servem para pendurar a cortina no varão ou dar suporte às argolas. Quase sempre feitas do mesmo tecido da cortina, também conhecidas como passantes ou alças."
		},
		{
			label: "Trilho",
			description:
				"Estrutura para pendurar e segurar a cortina. Permite que a cortina deslize com o auxílio de rodízios. Pode ser duplo ou triplo, para instalação conjunta de blecaute ou forro. Os modelos alumínio mais antigos ou trilho suiço em metal branco para rodízios de plástico, mais fortes e difícil de entortarem e atualmente mais usado."
		},
		{
			label: "Varão",
			description:
				"Bastão de metal, madeira ou plástico que sustenta a cortina. Geralmente apoiado em suportes de teto ou parede."
		},
		{
			label: "Xale",
			description: "Tecido com caimento lateral, sobreposto à cortina, para efeito decorativo."
		}
	];

	for (var i = 0; i < items.length; i++) {
		$("#grossario").append("<li><b>" + items[i].label + "</b>: " + items[i].description + "</li>");
	}

});