using strange.extensions.mediation.impl;

namespace Assets.roguelike2d.game
{
    public class ObstacleMediator:Mediator
    {
        [Inject]
        public ObstacleView view { get; set; }
        public override void OnRegister()
        {
            view.Init();
        }
    }
}
