using System;
using System.Linq;
using WS_ScaneApp.Models;
using WS_ScaneApp.Models.ProjectRequests;

namespace WS_ScaneApp.Services
{
    public class SaleService : ISaleService
    {
        public void AddSale(SaleRequest model)
        {
            using (var context = new ScaneAppContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var newSale = new Sale();
                        newSale.ClientId = model.ClientId;
                        var client = context.Clients.Where(x => x.Id == model.ClientId).FirstOrDefault();
                        newSale.Client = client;
                        newSale.Total = model.Concepts.Sum(c => c.Quantity * c.SalePrice);
                        newSale.Date = DateTime.Now;
                        context.Sales.Add(newSale);
                        context.SaveChanges();

                        var newSaleId = context.Sales
                            .Where(x => x.Date == newSale.Date && x.ClientId == newSale.ClientId).FirstOrDefault().Id + 1;

                        // context.SaveChanges();
                        foreach (var modelConcept in model.Concepts)
                        {
                            var newConcept = new Concept
                            {
                                SaleId = newSaleId,
                                Sale = newSale,
                                ProductId = modelConcept.ProductId,
                                SaleName = modelConcept.SaleName,
                                SalePrice = modelConcept.SalePrice,
                                Quantity = modelConcept.Quantity,
                                Total = (long)(modelConcept.Quantity * modelConcept.SalePrice)
                            };
                            context.Concepts.Add(newConcept);
                            // context.SaveChanges();
                        }
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        transaction.Rollback();
                        throw new Exception("Error in Add Sale");
                    }
                }
            }
        }
    }
}
