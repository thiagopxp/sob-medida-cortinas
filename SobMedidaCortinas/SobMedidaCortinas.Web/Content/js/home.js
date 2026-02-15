//MODAL - CORTINAS 
$(function () {
    setTimeout(function () {

        //var cortinas = [
        //	{
        //		id: 'cortina-sistema-wave',
        //		name: 'Cortinas Sistema Wave',
        //		description:
        //			'O destaque fica para a linha Wave que combina o design no Trilho Suiço ou Tubo Trilho, com uma cortina em ondas suaves e uniformes devido a fita Wave costurada na cortina, se torna uma linda cortina. Podendo ser acionada com cordão ou manual.'
        //	},
        //	{
        //		id: 'cortina-voil-com-xale',
        //		name: 'Cortinas de voil',
        //		description:
        //			'Um dos modelos de cortinas mais comuns de tipos de cortina são as cortinas de voal. Ela é caracterizada por seu material leve (geralmente em poliester) que é utilizado para faze-los. Eles perfeitamente adequam-se à decoração de casas nas localidades de clima quente. Uma das principais vantagens da utilização destas cortinas é que eles podem ser facilmente lavadas e requerem pouca manutenção, em termos de tempo, esforço e custo. Ao mesmo tempo, elas podem ser facilmente pendurado nos trilhos e janelas. Elas dão uma qualidade artística para a sua casa, além de um toque de classe e elegância.'
        //	},
        //	{
        //		id: 'cortina-alca-bastao',
        //		name: 'Cortina com Alça Bastão',
        //		description:
        //			'Cortinas com Alça dispensam ilhóses e argolas. Elas possuem um ótimo acabamento e podem ser feitas com tecidos leves ou grossos. As alças podem ser feitas com o próprio tecido, finas ou grossas, bom para ambientes que não precisam abrir e fechar a toda hora.'
        //	},
        //	{
        //		id: 'cortina-blackout',
        //		name: 'Cortina de Black-out',
        //		description:
        //			'As cortinas black-out inibem a entrada de parte do calor do sol no ambiente. Ao mesmo tempo, no inverno, cortinas blackout inibem a saída do calor de dentro da residência. Além disto, estes tipos de cortinas dão um conforto acústico, absorvendo parte do som. Black-out com trilho é recomendado para quem gostaria de deixar o quarto completamento escuro, sem deixar passar nenhuma luz cobrindo todo o vão da janela. Outros modelos deixam a luz passar aos ilhós, viés e franzidos.'
        //	},
        //	{
        //		id: 'cortina-prega-femea',
        //		name: 'Cortina Prega Fêmea',
        //		description:
        //			'Cortinas com prega fêmea são formadas de duas dobras, em sentidos opostos, que se encontram no lado da frente do tecido.'
        //	},
        //	{
        //		id: 'cortina-trilho-suico',
        //		name: 'Cortina com Trilho Suiço',
        //		description:
        //			'O trilho suico (ou trilho suisso) substitui o antigo trilho de alumínio com os rodízios de bolinhas amareladas. Eles são bem mais práticos tanto para colocação quanto para lavagem. Muitos clientes preferem os trilhos suícos porque eles não emperram ao abrir e fechar.'
        //	},
        //	{
        //		id: 'cortina-ilhos',
        //		name: 'Cortina de Ilhós no Varão',
        //		description:
        //			'Cortinas com Ilhós ou Argolas no Varão são leves, modernas e descontraídas. Deixará qualquer ambiente muito mais aconchegante, são práticas e requerem pouca manutenção.'
        //	},
        //	{
        //		id: 'cortina-argola',
        //		name: 'Cortina de Argolas no Varão',
        //		description:
        //			'Cortinas com Ilhós ou Argolas no Varão são leves, modernas e descontraídas. Deixará qualquer ambiente muito mais aconchegante, são práticas e requerem pouca manutenção.'
        //	},
        //	{
        //		id: 'cortina-prega-americana',
        //		name: 'Cortina Prega Americana',
        //		description:
        //			'Cortinas com prega americana possuem dobras triplas no arremate superior da cortina (chamado cós), que produz um franzido virado para o teto. Pode ser para trilho ou varão.'
        //	}
        //];

        //var persianas = [
        //	{
        //		id: 'persiana-rolo',
        //		name: 'Persianas Rolô',
        //		description:
        //			'As persianas Rolô proporcionam ao seu ambiente leveza, praticidade e harmonia. Podem ser feitas com tecidos translúcidos ou blackout. Quanto ao acabamento, podem ser colocadas na sanca ou cortineiro ou com acabamento da própria persiana.'
        //	},
        //	{
        //		id: 'persiana-romana',
        //		name: 'Persianas Romana',
        //		description:
        //			'As persianas Romana proporcionam ao seu ambiente leveza, praticidade e harmonia. Podem ser feitas com tecidos translúcidos ou blackout. Quanto ao acabamento, podem ser colocadas na sanca ou cortineiro ou com acabamento da própria persiana.'
        //	},
        //	{
        //		id: 'persiana-madeira',
        //		name: 'Persianas de madeira',
        //		description: ''
        //	}
        //];

        //var ideias = [
        //	{
        //		id: 'ideia-cortina-em-voil-pregas-femeas',
        //		name: 'Cortina em voil com pregas fêmeas',
        //		description: ''
        //	},
        //	{
        //		id: 'ideia-cortina-para-loft',
        //		name: 'Cortina para loft',
        //		description: ''
        //	},
        //	{
        //		id: 'ideia-cortina-varao-pregas-americanas',
        //		name: 'Cortina com varão e pregas americanas',
        //		description: ''
        //	},
        //	{
        //		id: 'ideia-paineis-de-linho',
        //		name: 'Painéis de linho',
        //		description: ''
        //	},
        //	{
        //		id: 'ideia-quarto-bebe',
        //		name: 'Quarto de bebê - Bandô',
        //		description: ''
        //	},
        //	{
        //		id: 'ideia-persiana-de-teto',
        //		name: 'Persiana de teto',
        //		description: ''
        //	},
        //];

        var modalTemplate =
            '<div class="portfolio-modal modal" id="<%=id%>" tabindex="-1" role="dialog" aria-hidden="true">' +
            '<div class="modal-content">' +
            '<div class="close-modal" data-dismiss="modal"><div class="lr"><div class="rl"></div></div></div>' +
            '<div class="container">' +
            '<div class="row">' +
            '<div class="col-lg-8 col-lg-offset-2">' +
            '<div class="modal-body" itemscope itemtype="http://schema.org/Product">' +
            '<h2 itemprop="name"><%=name%></h2>' +
            '<div class="img-wrapper">' +
            '<img class="img-responsive img-centered" data-src="/Content/img/cortinas/<%=id%>.jpg" alt="" itemprop="image">' +
            '<div class="spinner"><i class="fa fa-refresh fa-spin fa-3x fa-fw"></i><span class="sr-only">Loading...</span></div>' +
            '</div>' +
            '<p itemprop="description"><%=description%></p>' +
            '<button type="button" class="btn btn-primary" data-dismiss="modal"><i class="fa fa-times"></i> Voltar</button>' +
            '</div></div></div></div></div></div>';

        var portfolioItemTemplate = '<div class="col-md-4 col-sm-6 portfolio-item" itemscope itemtype="http://schema.org/Product">' +
            '<a href="#<%=id%>" class="portfolio-link" data-ga="" data-toggle="modal">' +
            '<div class="portfolio-hover"><div class="portfolio-hover-content"><i class="fa fa-plus fa-3x"></i></div></div>' +
            '<img src="/Content/img/cortinas/<%=id%>-tb.jpg" class="img-responsive" alt=<%=name%> itemprop="image">' +
            '</a>' +
            '<div class="portfolio-caption"><a href="/<%=controller%>/<%=id%>" title="<%=name%>" <h4 itemprop="name"><%=name%></h4></a></div>' +
            '</div>';

        //cortinas
        var cortinas = window.home.cortinas
        for (var i = 0; i < cortinas.length; i++) {
            var portfolioItemTmp = _.template(portfolioItemTemplate),
                modalTmp = _.template(modalTemplate);

            cortinas[i].controller = "Cortinas"
            $("#cortinas-container").append(portfolioItemTmp(cortinas[i]));
            $("#modals-container").append(modalTmp(cortinas[i]));
        }

        //persianas
        var persianas = window.home.persianas
        for (var i = 0; i < persianas.length; i++) {
            var portfolioItemTmp = _.template(portfolioItemTemplate),
                modalTmp = _.template(modalTemplate);

            persianas[i].controller = "Persianas"
            $("#persianas-container").append(portfolioItemTmp(persianas[i]));
            $("#modals-container").append(modalTmp(persianas[i]));
        }

        //ideias
        var ideias = window.home.ideias
        for (var i = 0; i < ideias.length; i++) {
            var portfolioItemTmp = _.template(portfolioItemTemplate),
                modalTmp = _.template(modalTemplate);

            ideias[i].controller = "Ideias"
            $("#ideias-container").append(portfolioItemTmp(ideias[i]));
            $("#modals-container").append(modalTmp(ideias[i]));
        }


        //Modal loader/opener
        $('.portfolio-modal').on('shown.bs.modal', function () {
            var $img = $("img[data-src]", this),
                src = $img.data("src");

            $img.prop('src', src);
        });


    }, 0);

});
