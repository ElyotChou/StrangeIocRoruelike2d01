using strange.extensions.mediation.impl;
using UnityEngine;

namespace Assets.roguelike2d.game
{
    public class EnemyView:View
    {
        internal void Init()
        {
            GetComponent<BoxCollider2D>().size = new Vector2(0.9f, 0.9f);
        }
    }
}
