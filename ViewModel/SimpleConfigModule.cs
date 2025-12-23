using Ninject.Modules;
using DAL;
using ModelLib;
using Ninject;

namespace ViewModel
{
    public class SimpleConfigModule : NinjectModule
    {
        public override void Load()
        {
            // Регистрация репозиториев
            Bind<IRepository<Wine>>().To<EntityRepository<Wine>>().InSingletonScope();
            Bind<IRepository<Wine>>().To<DapperRepository<Wine>>().InSingletonScope();

            // Регистрация бизнес-логики
            Bind<IWineBusinessService>().To<BusinessLogic>().InSingletonScope();

            // Регистрация основного сервиса
            Bind<IWineService>().To<WineService>().InSingletonScope();
        }
    }
}