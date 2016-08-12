using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using strange.extensions.mediation.impl;

namespace Assets.roguelike2d.game
{
    public class ExitMediator:Mediator
    {
        [Inject]
        public ExitView view { get; set; }
    }
}
