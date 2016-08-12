
using strange.extensions.mediation.impl;

namespace Assets.roguelike2d
{
    public class TestMediator:Mediator
    {
        [Inject]
        public TestView view { get; set; }
    }
}
