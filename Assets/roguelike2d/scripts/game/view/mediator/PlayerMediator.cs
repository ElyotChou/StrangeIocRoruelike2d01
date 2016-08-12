using strange.extensions.mediation.impl;
using UnityEngine;

namespace Assets.roguelike2d.game
{
    public class PlayerMediator:Mediator
    {
        [Inject]
        public PlayerView view { get; set; }
        [Inject]
        public GameInputSignal gameInputSignal { get; set; }
        [Inject]
        public PlayerBehaviourSignal playerBehaviourSignal { get; set; }

        public override void OnRegister()
        {
            gameInputSignal.AddListener(onGameInput);
            view.Init();
        }

        public override void OnRemove()
        {
            gameInputSignal.RemoveListener(onGameInput);
        }

        private void onGameInput(int input)
        {
            bool left = (input & GameInputEvent.MOVE_LEFT) > 0;
            bool right = (input & GameInputEvent.MOVE_RIGHT) > 0;
            bool up = (input & GameInputEvent.MOVE_UP) > 0;
            bool down = (input & GameInputEvent.MOVE_DOWN) > 0;

            if (left)
            {
                //TestLoadConfig.log.Trace("PlayerMediator onGameInput left");
                playerBehaviourSignal.Dispatch(view, GameInputEvent.MOVE_LEFT);
            }
            if (right)
            {
                //TestLoadConfig.log.Trace("PlayerMediator onGameInput right");
                playerBehaviourSignal.Dispatch(view, GameInputEvent.MOVE_RIGHT);
            }
            if (up)
            {
                //TestLoadConfig.log.Trace("PlayerMediator onGameInput up");
                playerBehaviourSignal.Dispatch(view, GameInputEvent.MOVE_UP);
            }
            if (down)
            {
                //TestLoadConfig.log.Trace("PlayerMediator onGameInput down");
                playerBehaviourSignal.Dispatch(view, GameInputEvent.MOVE_DOWN);
            }
        }
    }
}
