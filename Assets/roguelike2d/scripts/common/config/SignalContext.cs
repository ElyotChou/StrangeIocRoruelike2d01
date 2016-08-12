using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.impl;
using UnityEngine;

namespace Assets.roguelike2d
{
    public class SignalContext:MVCSContext
    {
        public SignalContext(MonoBehaviour contextView):base(contextView)
        {
        }

        protected override void addCoreComponents()
        {
            base.addCoreComponents();
            injectionBinder.Unbind<ICommandBinder>();
            injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
            TestLoadConfig.log.Trace("SignalContext addCoreComponents");
        }

        public override void Launch()
        {
            base.Launch();
            StartSignal startSignal = (StartSignal) injectionBinder.GetInstance<StartSignal>();
            startSignal.Dispatch();
            TestLoadConfig.log.Trace("SignalContext Launch");
        }

        protected override void mapBindings()
        {
            base.mapBindings();
            implicitBinder.ScanForAnnotatedClasses(new string[] {"Assets.roguelike2d"});
            TestLoadConfig.log.Trace("SignalContext mapBindings");
        }
    }
}
