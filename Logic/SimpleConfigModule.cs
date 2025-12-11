using DAL;
using ModelLib;
using Ninject.Modules;
using аис_лаба_1;

namespace BL
{
    public class SimpleConfigModule : NinjectModule
    {
        public override void Load()
        {
            //Bind<IRepository<Wine>>().To<EntityRepository<Wine>>().InSingletonScope();
            Bind<IRepository<Wine>>().To<DapperRepository>().InSingletonScope();
            Bind<IWineService>().To<WineService>().InSingletonScope();
            Bind<IWineBusinessService>().To<BusinessLogic>().InSingletonScope();

        }
    }
}
