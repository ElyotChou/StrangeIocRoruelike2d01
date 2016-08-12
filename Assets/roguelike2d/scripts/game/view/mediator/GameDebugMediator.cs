using strange.extensions.mediation.impl;

namespace Assets.roguelike2d.game
{
    public class GameDebugMediator:Mediator
    {
        [Inject]
        public GameDebugView view { get; set; }
        [Inject]
        public GameStartSignal gameStartSignal { get; set; }
        [Inject]
        public LevelStartSignal levelStartSignal { get; set; }
        public override void OnRegister()
        {
            view.gameStartSignal.AddListener(onGameStartClick);
            view.startLevelSignal.AddListener(onStartLevelClick);

            gameStartSignal.AddListener(onGameStarted);
        }
        public override void OnRemove()
        {
            gameStartSignal.RemoveListener(onGameStarted);
        }
        private void onGameStartClick()
        {
            gameStartSignal.Dispatch();
        }
        private void onStartLevelClick()
        {
            levelStartSignal.Dispatch();
        }
        private void onGameStarted()
        {
            view.SetState(GameDebugView.ScreenState.START_LEVEL);
        }

    }
}
