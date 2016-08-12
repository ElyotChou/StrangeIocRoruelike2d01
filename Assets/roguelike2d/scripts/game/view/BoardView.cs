using strange.extensions.mediation.impl;
using UnityEngine;

namespace Assets.roguelike2d.game
{
    public class BoardView:View
    {
        [Inject]
        public IScreenUtil screenUtil { get; set; }
        
    }
}
