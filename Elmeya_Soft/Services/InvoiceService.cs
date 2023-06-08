using Elmeya_Soft.IService;
using Elmeya_Soft.Models;
using Elmeya_Soft.ViewModels;
using EntityFrameWorkDemo;
using Microsoft.EntityFrameworkCore;

namespace Elmeya_Soft.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly ApplicationContext _applicationContext;

        public InvoiceService(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public Invoice AddInvoice(AddInvoiceViewModel invoice)
        {
            var invoiceDetails = new InvoiceDetails
            {
                CategoryId = invoice.DetailsId,
                TypeId = invoice.TypeId,
                Quantity = invoice.Quantity

            };
            var Invoice = new Invoice
            {
                ClientId = invoice.ClientId,
                Date = invoice.Date,
                invoiceDetails = new List<InvoiceDetails>() { invoiceDetails }
            };
            _applicationContext.Invoices.Add(Invoice);
            _applicationContext.SaveChanges();
            return Invoice;
        }

        public async Task<List<Invoice>> GetInvoices()
        {
            var invoices = await _applicationContext
                .Invoices
                .Include(i=>i.Client)
                .ToListAsync();
            return invoices;
        }
        public Invoice GetInvoiceById(int Id)
        {
            var invoice = _applicationContext
                .Invoices.Where(i=>i.Id == Id)
                .Include(i => i.Client)
                .Include(i=>i.invoiceDetails)
                .ThenInclude(i=>i.Category)
                .FirstOrDefault();
            return invoice;
        }

        public Invoice UpdateInvoice(int invoiceId, Invoice invoice)
        {
            _applicationContext.Invoices.Update(invoice);
            _applicationContext.SaveChanges();
            return invoice;
        }
    }
}
