using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;

namespace Assets.roguelike2d.game
{
    public class GameDebugView:View
    {
        internal enum ScreenState
        {
            IDLE,
            START_LEVEL,
            END_GAME,
            LEVEL_IN_PROGRESS,
        }
        private ScreenState state = ScreenState.IDLE;
        [Inject]
        public IScreenUtil screenUtil { get; set; }

        internal Signal gameStartSignal = new Signal();
        internal Signal startLevelSignal = new Signal();
        protected void OnGUI()
        {
            switch (state)
            {
                case ScreenState.IDLE:
                    if (GUI.Button(screenUtil.GetScreenRect(.4f, .45f, .2f, .1f), "Start Game"))
                    {
                        gameStartSignal.Dispatch();
                    }
                    break;
                case ScreenState.START_LEVEL:
                    if (GUI.Button(screenUtil.GetScreenRect(.4f, .45f, .2f, .05f), "Start Level "))
                    {
                        startLevelSignal.Dispatch();
                    }
                    break;
            }
        }

        internal void SetState(ScreenState state)
        {
            this.state = state;
        }
    }
}
