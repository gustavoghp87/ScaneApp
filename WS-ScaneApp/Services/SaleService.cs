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
                        newSale.Total = model.Concepts.Sum(c => c.Quantity * c.SalePrice);
                        newSale.ClientId = model.ClientId;
                        newSale.Date = DateTime.Now;
                        foreach (var modelConcept in model.Concepts)
                        {
                            var newConcept = new Concept
                            {
                                Quantity = modelConcept.Quantity,
                                ProductId = modelConcept.ProductId,
                                SalePrice = modelConcept.SalePrice,
                                SaleName = modelConcept.SaleName,
                                Total = modelConcept.Total
                            };
                            context.Concepts.Add(newConcept);
                            context.SaveChanges();
                        }
                        context.Sales.Add(newSale);
                        context.SaveChanges();
                        transaction.Commit();
                        throw new Exception("Error in Add Sale");
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                    }
                }
            }
        }
    }
}
