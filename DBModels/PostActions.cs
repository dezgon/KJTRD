//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QUEJATERD.DBModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class PostActions
    {
        public long Id { get; set; }
        public long PostId { get; set; }
        public bool IsPositive { get; set; }
        public int ActionTypeId { get; set; }
        public long CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Nullable<long> DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletedAt { get; set; }
    
        public virtual PostActionTypes PostActionTypes { get; set; }
        public virtual Posts Posts { get; set; }
        public virtual Users Users { get; set; }
        public virtual Users Users1 { get; set; }
    }
}
