//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Auktionshus_WPF.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class PurchaseOffer
    {
        public int Id { get; set; }
        public string Amount { get; set; }
        public Nullable<int> AccountId { get; set; }
        public Nullable<int> SalesOfferId { get; set; }
    
        public virtual Account Account { get; set; }
        public virtual SalesOffer SalesOffer { get; set; }
    }
}
