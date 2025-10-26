using GerarPDF.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace GerarPDF.Utils
{
    public class PDFUtils
    {
        public static byte[] GerarPDF(List<UsuarioModel> usuarios)
        {
            using (var ms = new MemoryStream())
            {
                Document doc = new Document(PageSize.A4);
                //criando e estipulando o tipo da folha usada

                doc.SetMargins(40, 40, 40, 80);
                //estipulando o espaçamento das margens que queremos
                doc.AddCreationDate();//adicionando as configuracoes
                PdfWriter.GetInstance(doc, ms);

                doc.Open();

                // Fonte
                var fonteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
                var fonteTexto = FontFactory.GetFont(FontFactory.HELVETICA, 12);

                // Título
                doc.Add(new Paragraph("Relatório de Usuários", fonteTitulo));
                doc.Add(new Paragraph(" ")); // Espaço

                // Cria uma tabela com 2 colunas
                PdfPTable tabela = new PdfPTable(2);

                // Cabeçalho das colunas
                tabela.AddCell(new PdfPCell(new Phrase("Campo", fonteTexto)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                tabela.AddCell(new PdfPCell(new Phrase("Valor", fonteTexto)) { BackgroundColor = BaseColor.LIGHT_GRAY });

                foreach (var usuario in usuarios)
                {
                    tabela.WidthPercentage = 100;
                    tabela.SpacingBefore = 10f;
                    tabela.SpacingAfter = 10f;

                    // Adiciona propriedades do usuário
                    tabela.AddCell("Id");
                    tabela.AddCell(usuario.Id.ToString());
                    tabela.AddCell("Nome");
                    tabela.AddCell(usuario.Nome);
                    tabela.AddCell("Email");
                    tabela.AddCell(usuario.Email);
                }

                // Adiciona tabela ao documento
                doc.Add(tabela);

                //fechando documento para que seja salva as alteraçoes.
                doc.Close();

                return ms.ToArray();
            }
        }
    }
}
