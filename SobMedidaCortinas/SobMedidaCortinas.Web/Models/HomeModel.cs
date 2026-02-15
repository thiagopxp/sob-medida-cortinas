using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SobMedidaCortinas.Web.Models
{
    public class HomeModel
    {
        public HomeModel()
        {
            Cortinas = getCortinas();
            Persianas = getPersianas();
            Ideias = getIdeias();
        }

        public List<ProductModel> Cortinas { get; set; }
        public List<ProductModel> Persianas { get; set; }
        public List<ProductModel> Ideias { get; set; }

        private List<ProductModel> getCortinas()
        {
            List<ProductModel> cortinas = new List<ProductModel>();
            cortinas.Add(new ProductModel("cortina-sistema-wave", "Cortinas Sistema Wave", "O destaque fica para a linha Wave que combina o design no Trilho Suiço ou Tubo Trilho, com uma cortina em ondas suaves e uniformes devido a fita Wave costurada na cortina, se torna uma linda cortina. Podendo ser acionada com cordão ou manual."));
            cortinas.Add(new ProductModel("cortina-voil-com-xale", "Cortinas de voil", "Um dos modelos de cortinas mais comuns de tipos de cortina são as cortinas de voal. Ela é caracterizada por seu material leve (geralmente em poliester) que é utilizado para faze-los. Eles perfeitamente adequam-se à decoração de casas nas localidades de clima quente. Uma das principais vantagens da utilização destas cortinas é que eles podem ser facilmente lavadas e requerem pouca manutenção, em termos de tempo, esforço e custo. Ao mesmo tempo, elas podem ser facilmente pendurado nos trilhos e janelas. Elas dão uma qualidade artística para a sua casa, além de um toque de classe e elegância."));
            cortinas.Add(new ProductModel("cortina-alca-bastao", "Cortina com Alça Bastão", "Cortinas com Alça dispensam ilhóses e argolas. Elas possuem um ótimo acabamento e podem ser feitas com tecidos leves ou grossos. As alças podem ser feitas com o próprio tecido, finas ou grossas, bom para ambientes que não precisam abrir e fechar a toda hora."));
            cortinas.Add(new ProductModel("cortina-blackout", "Cortina de Black-out", "As cortinas black-out inibem a entrada de parte do calor do sol no ambiente. Ao mesmo tempo, no inverno, cortinas blackout inibem a saída do calor de dentro da residência. Além disto, estes tipos de cortinas dão um conforto acústico, absorvendo parte do som. Black-out com trilho é recomendado para quem gostaria de deixar o quarto completamento escuro, sem deixar passar nenhuma luz cobrindo todo o vão da janela. Outros modelos deixam a luz passar aos ilhós, viés e franzidos."));
            cortinas.Add(new ProductModel("cortina-prega-femea", "Cortina Prega Fêmea", "Cortinas com prega fêmea são formadas de duas dobras, em sentidos opostos, que se encontram no lado da frente do tecido."));
            cortinas.Add(new ProductModel("cortina-trilho-suico", "Cortina com Trilho Suiço", "O trilho suico (ou trilho suisso) substitui o antigo trilho de alumínio com os rodízios de bolinhas amareladas. Eles são bem mais práticos tanto para colocação quanto para lavagem. Muitos clientes preferem os trilhos suícos porque eles não emperram ao abrir e fechar."));
            cortinas.Add(new ProductModel("cortina-ilhos", "Cortina de Ilhós no Varão", "Cortinas com Ilhós ou Argolas no Varão são leves, modernas e descontraídas. Deixará qualquer ambiente muito mais aconchegante, são práticas e requerem pouca manutenção."));
            cortinas.Add(new ProductModel("cortina-argola", "Cortina de Argolas no Varão", "Cortinas com Ilhós ou Argolas no Varão são leves, modernas e descontraídas. Deixará qualquer ambiente muito mais aconchegante, são práticas e requerem pouca manutenção."));
            cortinas.Add(new ProductModel("cortina-prega-americana", "Cortina Prega Americana", "Cortinas com prega americana possuem dobras triplas no arremate superior da cortina (chamado cós), que produz um franzido virado para o teto. Pode ser para trilho ou varão."));

            return cortinas;
        }

        private List<ProductModel> getPersianas()
        {
            List<ProductModel> persianas = new List<ProductModel>();
            persianas.Add(new ProductModel("persiana-rolo", "Persianas Rolô", "As persianas Rolô proporcionam ao seu ambiente leveza, praticidade e harmonia. Podem ser feitas com tecidos translúcidos ou blackout. Quanto ao acabamento, podem ser colocadas na sanca ou cortineiro ou com acabamento da própria persiana."));
            persianas.Add(new ProductModel("persiana-romana", "Persianas Romana", "As persianas Romana proporcionam ao seu ambiente leveza, praticidade e harmonia. Podem ser feitas com tecidos translúcidos ou blackout. Quanto ao acabamento, podem ser colocadas na sanca ou cortineiro ou com acabamento da própria persiana."));
            persianas.Add(new ProductModel("persiana-madeira", "Persianas de madeira", ""));

            return persianas;
        }

        private List<ProductModel> getIdeias()
        {
            List<ProductModel> ideias = new List<ProductModel>();
            ideias.Add(new ProductModel("ideia-cortina-em-voil-pregas-femeas", "Cortina em voil com pregas fêmeas", ""));
            ideias.Add(new ProductModel("ideia-cortina-para-loft", "Cortina para loft", ""));
            ideias.Add(new ProductModel("ideia-cortina-varao-pregas-americanas", "Cortina com varão e pregas americanas", ""));
            ideias.Add(new ProductModel("ideia-paineis-de-linho", "Painéis de linho", ""));
            ideias.Add(new ProductModel("ideia-quarto-bebe", "Quarto de bebê - Bandô", ""));
            ideias.Add(new ProductModel("ideia-persiana-de-teto", "Persiana de teto", ""));

            return ideias;
        }
    }
}