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
    
    public partial class Posts
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Posts()
        {
            this.PostActions = new HashSet<PostActions>();
            this.PostFiles = new HashSet<PostFiles>();
        }
    
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsVisible { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public long CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
        public Nullable<long> UpdatedBy { get; set; }
        public Nullable<System.DateTime> DeletedAt { get; set; }
        public Nullable<long> DeletedBy { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PostActions> PostActions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PostFiles> PostFiles { get; set; }
        public virtual Users Users { get; set; }
        public virtual Users Users1 { get; set; }
        public virtual Users Users2 { get; set; }
    }
}
