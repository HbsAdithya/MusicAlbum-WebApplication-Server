using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebApplication1
{
    /// <summary>
    /// Summary description for SupplierWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SupplierWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        public double getPrice(int Id, int qun)
        {
            SupplierADBDataSetTableAdapters.AlbumPriceTableAdapter adp =
                 new SupplierADBDataSetTableAdapters.AlbumPriceTableAdapter();

            int avai_qty = (int)adp.getQuantity(Id);
            if (avai_qty >= qun) {
                double price = (double)adp.getPrice((short?)Id);
                return price;
            }
            return 0;

        }


        public void upadteQuantity (int Id, int qun)
        {
            SupplierADBDataSetTableAdapters.AlbumPriceTableAdapter adp =
                 new SupplierADBDataSetTableAdapters.AlbumPriceTableAdapter();

            int avai_qty = (int)adp.getQuantity(Id);
            int new_qty = avai_qty - qun;
            adp.updateQuantity((short?)new_qty, Id);

        }

        public void placeOrder(int Id, int Quantity, String Customer, String address)
        {
            SupplierADBDataSetTableAdapters.AlbumPriceTableAdapter adp =
                 new SupplierADBDataSetTableAdapters.AlbumPriceTableAdapter();

            adp.Insert( Customer, DateTime.Now, address);

        }
    }
}
