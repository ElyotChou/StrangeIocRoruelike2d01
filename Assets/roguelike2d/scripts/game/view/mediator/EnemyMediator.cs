using strange.extensions.mediation.impl;

namespace Assets.roguelike2d.game
{
    public class EnemyMediator:Mediator
    {
        [Inject]
        public EnemyView view { get; set; }
        public override void OnRegister()
        {
            view.Init();
        }
    }
}
