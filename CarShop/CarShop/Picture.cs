//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarShop
{
    using System;
    using System.Collections.Generic;
    
    public partial class Picture
    {
        public int id { get; set; }
        public int GoodId { get; set; }
        public byte[] Image { get; set; }
    
        public virtual Good Good { get; set; }
    }
}
