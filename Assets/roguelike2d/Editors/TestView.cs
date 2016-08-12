
using Assets.roguelike2d.game;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;

namespace Assets.roguelike2d
{
    public class TestView:View
    {
        [Inject]
        public LevelStartSignal createBoard { get; set; }
        [Inject]
        public GameStartSignal gameStartSignal { get; set; }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                TestLoadConfig.log.Debug("###############TestView##############");
                //gameStartSignal.Dispatch();
                //createBoard.Dispatch();
            }
        }



    }
}
