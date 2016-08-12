
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;

namespace Assets.roguelike2d.game
{
    public class PlayerView:View
    {
        private int _facing = 1;
        private bool _isAction = false;
        internal void Init()
        {
            GetComponent<BoxCollider2D>().size = new Vector2(0.9f, 0.9f);
        }

        internal bool IsAction
        {
            get
            {
                return _isAction;  
            }
            set
            {
                _isAction = value;
            }
        }

        internal int Facing
        {
            get
            {
                return _facing;
            }
            set
            {
                _facing = value;
            }
        }

    }
}
