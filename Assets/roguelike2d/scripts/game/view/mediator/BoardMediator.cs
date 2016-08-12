using strange.extensions.mediation.impl;

namespace Assets.roguelike2d.game
{
    public class BoardMediator:Mediator
    {
        [Inject]
        public BoardView view { get; set; }

    }
}
