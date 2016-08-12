
using strange.extensions.signal.impl;

namespace Assets.roguelike2d.game
{
    //游戏输入
    public class GameInputSignal : Signal<int> { }

    //游戏开始
    public class GameStartSignal : Signal { }
    //关卡开始
    public class LevelStartSignal : Signal { }
    //主角行为
    public class PlayerBehaviourSignal : Signal<PlayerView,int> { }

}
