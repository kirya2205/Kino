//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KinoVideoProkat_K.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Rent
    {
        public int IdRent { get; set; }
        public Nullable<System.DateTime> DateStart { get; set; }
        public Nullable<System.DateTime> DateStop { get; set; }
        public string Worker { get; set; }
        public string PhoneWorker { get; set; }
        public Nullable<decimal> Summa { get; set; }
        public Nullable<decimal> Tax { get; set; }
        public Nullable<int> IdCinema { get; set; }
        public Nullable<int> IdFilm { get; set; }
    
        public virtual Cinema Cinema { get; set; }
        public virtual Film Film { get; set; }
    }
}
