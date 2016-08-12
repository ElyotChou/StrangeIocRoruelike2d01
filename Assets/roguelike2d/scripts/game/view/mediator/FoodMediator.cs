using strange.extensions.mediation.impl;

namespace Assets.roguelike2d.game
{
    public class FoodMediator:Mediator
    {
        [Inject]
        public FoodView view { get; set; }
        public override void OnRegister()
        {
            view.Init();
        }
    }
}
