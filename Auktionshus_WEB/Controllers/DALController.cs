using Auktionshus_WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Auktionshus_WEB.Controllers
{
    public class DALController
    {
        public DALController()
        {

        }

        public PurchaseOffer GetLastBid (SalesOffer so) 
        {
            if(so.PurchaseOffers != null)
            {
                PurchaseOffer po = (PurchaseOffer)so.PurchaseOffers.OrderByDescending(i => i.Amount).FirstOrDefault();
                return po;
            }
            return null;
        }
    }
}