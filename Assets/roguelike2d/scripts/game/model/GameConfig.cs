using System.Collections.Generic;
using UnityEngine;

namespace Assets.roguelike2d
{
    public class GameConfig:IGameConfig
    {
        [PostConstruct]
        public void PostConstruct()
        {
            TestLoadConfig.log.Trace("GameConfig PostConstruct");
            Sprite[] sprites = Resources.LoadAll<Sprite>("Scavengers_SpriteSheet");
            TestAssert.That(sprites != null, lev.Error, "GameModel Reset");

            dictSprites = new Dictionary<string, Sprite>();
            foreach (Sprite sprite in sprites)
            {
                dictSprites.Add(sprite.name, sprite);
                TestLoadConfig.log.DebugFormat("name: {0}", sprite.name);
            }

            smoothing = 0.5f;
        }

        #region implement IGameConfig
        public Dictionary<string, Sprite> dictSprites { get; private set; }
        public float smoothing { get; private set; }

        #endregion

    }
}
