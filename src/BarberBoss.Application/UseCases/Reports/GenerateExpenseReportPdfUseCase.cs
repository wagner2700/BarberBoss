
using BarberBoss.Application.UseCases.Reports.Fonts;
using BarberBoss.Domain.Bills;
using PdfSharp.Fonts;

namespace BarberBoss.Application.UseCases.Reports
{
    public class GenerateExpenseReportPdfUseCase : IGenerateExpenseReportPdfUseCase
    {
        private const string CURRECY_SYMBOL = "R$";
        private readonly IBillReadOnlyRepository _repository;

        public GenerateExpenseReportPdfUseCase(IBillReadOnlyRepository repository)
        {
            _repository = repository;

            GlobalFontSettings.FontResolver = new BillReportFontResolver();
        }



        public async Task<byte[]> Execute(DateOnly date)
        {
            var bilss = await _repository.GetByMonth(date);

            if(bilss.Count == 0)
            {
                return [];
            }

            return [];
        }
    }
}
