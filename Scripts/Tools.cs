using UnityEngine;

public class Tools
{
    public static bool TimeDelay(ref float delay,ref float timeC)
    {
        if(timeC > delay)
        {
            timeC = 0;
            return true;
        }
        timeC += Time.deltaTime;
        return false;
    }
    public static int GetRoundedValue(float v)
    {
        if(v - (int)v >= 0.5f)
        {
            return (int)v + 1;
        }
        else
        {
            return (int)v;
        }
    }
    public static int GetTileValueViaPos(Vector2 pos,Grid grid)
    {
        int x = GetRoundedValue(pos.x);
        int y = GetRoundedValue(pos.y);
        return ((grid.tilesCount * y) + x);
    }
}
