//using System;
//using DAL;
//using ModelLib;
//using Ninject.Modules;
//using аис_лаба_1;

//namespace BL
//{
//    public class SimpleConfigModule : NinjectModule
//    {
//        public override void Load()
//        {
//            Console.WriteLine("SimpleConfigModule.Load() начат");

//            try
//            {
//                Console.WriteLine("Регистрирую DapperRepository...");
//                Bind<IRepository<Wine>>().To<DapperRepository>().InSingletonScope();
//                Console.WriteLine("DapperRepository зарегистрирован");

//                Console.WriteLine("Регистрирую WineService...");
//                Bind<IWineService>().To<WineService>().InSingletonScope();
//                Console.WriteLine("WineService зарегистрирован");

//                Console.WriteLine("Регистрирую BusinessLogic...");
//                Bind<IWineBusinessService>().To<BusinessLogic>().InSingletonScope();
//                Console.WriteLine("BusinessLogic зарегистрирован");
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Ошибка в SimpleConfigModule: {ex}");
//                throw;
//            }

//            Console.WriteLine("SimpleConfigModule.Load() завершен");
//        }
//    }
//    }
