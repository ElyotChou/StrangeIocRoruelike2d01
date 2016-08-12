
using System.Collections.Generic;
using UnityEngine;

namespace Assets.roguelike2d.game
{
    public class GameModel:IGameModel
    {
        public void Reset()
        {
            level = 1;
            rows = 10;
            cols = 10;
            minCountWall = 2;
            maxCountWall = 8;
            if (listPosition == null)
            {
                listPosition = new List<Vector2>();
            }
            else
            {
                listPosition.Clear();
            }
            SetPositionList();
        }

        private void SetPositionList()
        {
            for (int x = 2; x < cols - 2; x++)
            {
                for (int y = 2; y < rows - 2; y++)
                {
                    listPosition.Add(new Vector2(x + 0.5f, y + 0.5f));
                }
            }
        }

        #region implement IGameModel
        public int level { get; set; }
        public int rows { get; private set; }
        public int cols { get; private set; }
        public int minCountWall { get; private set; }
        public int maxCountWall { get; private set; }
        public List<Vector2> listPosition { get; set; }
        public GameObject spriteModel { get; set; }
        #endregion
    }
}
