using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop
{
    public partial class Good
    {
        public byte[] GoodImage
        {
            get
            {
                if (MainWindow.carShopEntities.Pictures.Where(i => i.GoodId == this.Id).FirstOrDefault() != null)
                {
                    return MainWindow.carShopEntities.Pictures.Where(i => i.GoodId == this.Id).FirstOrDefault().Image;
                }
                else return null;
            }
        }
    }
}
