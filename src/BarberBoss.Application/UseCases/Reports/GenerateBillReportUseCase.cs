using BarberBoss.Domain.Bills;
using BarberBoss.Domain.Enums;
using BarberBoss.Domain.Reports;
using ClosedXML.Excel;

namespace BarberBoss.Application.UseCases.Reports
{
    internal class GenerateBillReportUseCase : IGenerateBillReportUseCase
    {
        private const string CURRENCY_SYMBOL = "R$";
        private readonly IBillReadOnlyRepository _repository;

        public GenerateBillReportUseCase(IBillReadOnlyRepository repository)
        {
            _repository = repository;
        }

        public async Task<byte[]> Execute(DateOnly month)
        {
            var bills = await _repository.GetByMonth(month);

            if(bills.Count == 0)
            {
                return [];
            }


            using var workbook = new XLWorkbook();
            workbook.Author = "Wagner Morais";
            workbook.Style.Font.FontSize = 12;
            workbook.Style.Font.FontName = "Times New Roman";

            var worksheet = workbook.Worksheets.Add(month.ToString("Y"));

            InsertHeader(worksheet);

            var raw = 2;

            foreach (var bill in bills)
            {
                worksheet.Cell($"A{raw}").Value = bill.Descricao;
                worksheet.Cell($"B{raw}").Value = bill.Data;
                worksheet.Cell($"C{raw}").Value = ConvertPaymentType(bill.TipoPagamento);
                worksheet.Cell($"D{raw}").Value = bill.Valor;
                worksheet.Cell($"D{raw}").Style.NumberFormat.Format= $"-{CURRENCY_SYMBOL} #,## 0.00";


                worksheet.Cell($"E{raw}").Value = bill.Descricao;


                raw++;
            }

            worksheet.Columns().AdjustToContents();


            var file = new MemoryStream();
            workbook.SaveAs(file);

            return file.ToArray();
        }

        private string ConvertPaymentType(TipoPagamento tipoPagamento)
        {
            return tipoPagamento switch
            {
                TipoPagamento.Dinheir0 => "Dinheiro",
                TipoPagamento.CartaoCredito => "Cartão de crédito",
                TipoPagamento.Pix => "Pix",
                TipoPagamento.CartaoDebito => "Cartão de débito",
                _ => string.Empty,
            };
        }

        private void InsertHeader(IXLWorksheet worksheet)
        {
            worksheet.Cell("A1").Value = ResourceReportMessages.DESCRIÇÃO;
            worksheet.Cell("B1").Value = ResourceReportMessages.DATA;
            worksheet.Cell("C1").Value = ResourceReportMessages.TIPOPAGAMENTO;
            worksheet.Cell("D1").Value = ResourceReportMessages.VALOR;
            worksheet.Cell("E1").Value = ResourceReportMessages.VALOR;


            worksheet.Cells("A1:E1").Style.Font.Bold = true;
            worksheet.Cells("A1:E1").Style.Fill.BackgroundColor = XLColor.FromHtml("#F5C2B6");
            worksheet.Cell("A1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            worksheet.Cell("B1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            worksheet.Cell("C1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            worksheet.Cell("D1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);
            worksheet.Cell("E1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
 


        }
    }
}
