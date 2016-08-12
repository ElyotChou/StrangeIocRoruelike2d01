using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using strange.extensions.context.impl;

namespace Assets.roguelike2d.game
{
    public class GameRoot:ContextView
    {
        void Awake()
        {
            context = new GameContext(this);
        }
    }
}
