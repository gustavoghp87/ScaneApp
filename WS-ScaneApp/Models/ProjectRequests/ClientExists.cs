using System;
using System.ComponentModel.DataAnnotations;

namespace WS_ScaneApp.Models.ProjectRequests
{
    public class ClientExists : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            Int64 clientId = (Int64)value;
            using (var context = new ScaneAppContext())
            {
                if (context.Clients.Find(clientId) == null) return false;
            }
            return true;
        }
    }
}
