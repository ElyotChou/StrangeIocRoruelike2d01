
namespace Assets.roguelike2d
{
    public static class YTools
    {
        public static int enumLength<parameters>()
        {
            return System.Enum.GetNames(typeof(parameters)).Length;
        }
    }

}
