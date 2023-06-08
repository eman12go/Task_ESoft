using Elmeya_Soft.Models;
using Elmeya_Soft.ViewModels;

namespace Elmeya_Soft.IService
{
    public interface IInvoiceService
    {
        Invoice AddInvoice(AddInvoiceViewModel invoice);
        Task<List<Invoice>> GetInvoices();
        Invoice UpdateInvoice(int invoiceId, Invoice invoice);
        Invoice GetInvoiceById(int Id);
    }
}
