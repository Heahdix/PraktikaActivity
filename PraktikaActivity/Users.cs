//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PraktikaActivity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Users()
        {
            this.Activities = new HashSet<Activities>();
        }
    
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string CountryCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }
        public int GenderId { get; set; }
        public int RoleId { get; set; }
        public Nullable<int> DirectionID { get; set; }
    
        public virtual Countries Countries { get; set; }
        public virtual Directions Directions { get; set; }
        public virtual Genders Genders { get; set; }
        public virtual Roles Roles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Activities> Activities { get; set; }
    }
}