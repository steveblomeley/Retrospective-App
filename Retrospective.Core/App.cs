using MvvmCross;
using MvvmCross.ViewModels;
using Retrospective.Core.Data;

namespace Retrospective.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            base.Initialize();

            Mvx.RegisterType<IRepository, Repository>();
        }
    }
}