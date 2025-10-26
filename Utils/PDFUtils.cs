using GerarPDF.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace GerarPDF.Utils
{
    public class PDFUtils
    {
        public static void GerarPDF(List<UsuarioModel> usuarios)
        {
            Document doc = new Document(PageSize.A4);
            //criando e estipulando o tipo da folha usada

            doc.SetMargins(40, 40, 40, 80);
            //estibulando o espaçamento das margens que queremos
            doc.AddCreationDate();//adicionando as configuracoes

            //caminho onde sera criado o pdf + nome desejado
            //OBS: o nome sempre deve ser terminado com .pdf
            string caminho = @"C:\Users\gabri\Downloads\" + "Usuarios.pdf";

            
            //criando o arquivo pdf embranco, passando como parametro a variavel
            //doc criada acima e a variavel caminho
            //tambem criada acima.
            PdfWriter writer = PdfWriter.GetInstance(doc, new
            FileStream(caminho, FileMode.Create));

            doc.Open();

            //criando uma string vazia
            string dados = "";

            foreach (var usuario in usuarios)
            {
                Paragraph paragrafo = new Paragraph(dados,
                new Font(Font.NORMAL, 14));

                //estipulando o alinhamneto
                paragrafo.Alignment = Element.ALIGN_JUSTIFIED;
                //Alinhamento Justificado

                //adicioando texto
                paragrafo.Add($"ID: {usuario.Id}\n" +
                $"Nome: {usuario.Nome}\n" +
                $"Email: {usuario.Email}\n\n");
                //acidionado paragrafo ao documento

                doc.Add(paragrafo);
            }

            //fechando documento para que seja salva as alteraçoes.
            doc.Close();
        }
    }
}
