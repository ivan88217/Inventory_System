using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory_System.Models;

namespace Inventory_System.Data
{
    public class DbInitializer
    {
        public static void Initialize(InventoryContext context)
        {
            context.Database.EnsureCreated();
            if (context.Products.Any())
            {
                return;
            }

            //類別資料
            var categories = new Category[]
            {
                new Category
                {
                    Name="A4"
                },
                new Category
                {
                    Name="A3"
                },
                new Category
                {
                    Name="Ink"
                },
                new Category
                {
                    Name="Printer"
                },
                new Category
                {
                    Name="Scanner"
                },
                new Category
                {
                    Name="Notebook"
                }
            };
            foreach(Category c in categories)
            {
                context.Categories.Add(c);
            }
            context.SaveChanges();

            //廠商資料
            var ManuFactors = new ManuFactor[]
            {
                new ManuFactor
                {
                    Name="HP"
                },
                new ManuFactor
                {
                    Name="Epson"
                },
                new ManuFactor
                {
                    Name="DoubleA"
                },
                new ManuFactor
                {
                    Name="Acer"
                },
                new ManuFactor
                {
                    Name="Asus"
                }
            };
            foreach (ManuFactor m in ManuFactors)
            {
                context.ManuFactors.Add(m);
            }
            context.SaveChanges();

            //倉庫資料
            var WareHouses = new WareHouse[]
            {
                new WareHouse
                {
                    Name="Taipei",Location="中正區"
                },
                new WareHouse
                {
                    Name="Taichung",Location="南屯區"
                },
                new WareHouse
                {
                    Name="Tainan",Location="南區"
                },
                new WareHouse
                {
                    Name="Kaosuong",Location="林鳳營"
                },
                new WareHouse
                {
                    Name="New Taipei",Location="板橋區"
                }
            };
            foreach(WareHouse w in WareHouses)
            {
                context.WareHouses.Add(w);
            }
            context.SaveChanges();

            //批號資料
            var BatchNum = new BatchNumber[]
            {
                new BatchNumber
                {
                    BatchNum="1060305",In_Date=DateTime.Parse("2017-03-05"),Expired_Date=DateTime.Parse("2020-03-05")
                },
                new BatchNumber
                {
                    BatchNum="1060306",In_Date=DateTime.Parse("2017-03-06"),Expired_Date=DateTime.Parse("2020-03-06")
                },
                new BatchNumber
                {
                    BatchNum="1060307",In_Date=DateTime.Parse("2017-03-07"),Expired_Date=DateTime.Parse("2020-03-07")
                },
                new BatchNumber
                {
                    BatchNum="1060308",In_Date=DateTime.Parse("2017-03-08"),Expired_Date=DateTime.Parse("2020-03-08")
                },
                new BatchNumber
                {
                    BatchNum="1060309",In_Date=DateTime.Parse("2017-03-09"),Expired_Date=DateTime.Parse("2020-03-09")
                },
                new BatchNumber
                {
                    BatchNum="1060310",In_Date=DateTime.Parse("2017-03-10"),Expired_Date=DateTime.Parse("2020-03-10")
                }
            };
            foreach(BatchNumber b in BatchNum)
            {
                context.BatchNumbers.Add(b);
            }
            context.SaveChanges();

            //產品資料
            var Products = new Product[]
            {
                new Product
                {
                    Name="Epson_Printer",CategoryID=4,BatchNumberID=1060310,ManuFactorID=2,WareHouseID=1,PartNumber=0040020310
                },
                new Product
                {
                    Name="HP_Printer",CategoryID=4,BatchNumberID=1060305,ManuFactorID=1,WareHouseID=5,PartNumber=0040010305
                },
                new Product
                {
                    Name="Epson_Ink",CategoryID=3,BatchNumberID=1060308,ManuFactorID=2,WareHouseID=2,PartNumber=0030020308
                },
                new Product
                {
                    Name="Epson_Scanner",CategoryID=5,BatchNumberID=1060307,ManuFactorID=2,WareHouseID=3,PartNumber=0050020307
                },
                new Product
                {
                    Name="DoubleA_A4",CategoryID=1,BatchNumberID=1060307,ManuFactorID=3,WareHouseID=1,PartNumber=0010030307
                },
                new Product
                {
                    Name="DoubleA_A3",CategoryID=2,BatchNumberID=1060306,ManuFactorID=3,WareHouseID=1,PartNumber=0020030306
                },
                new Product
                {
                    Name="Acer_NB",CategoryID=5,BatchNumberID=1060308,ManuFactorID=4,WareHouseID=5,PartNumber=0050040308
                },
                new Product
                {
                    Name="Asus_NB",CategoryID=5,BatchNumberID=1060309,ManuFactorID=5,WareHouseID=4,PartNumber=0050050309
                }
            };
            foreach(Product p in Products)
            {
                context.Products.Add(p);
            }
            context.SaveChanges();
        }
    }
}
