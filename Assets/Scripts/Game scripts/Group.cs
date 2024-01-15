using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Group : MonoBehaviour
{
   bool isValidGridPos()
   {
        foreach (Transform child in transform)
        {
            Vector2 vec = Playfield.roundVec2(child.position);

            if (!Playfield.insideBorder(vec))
                return false;

            if (Playfield.grid[(int)vec.x, (int)vec.y] != null &&
                Playfield.grid[(int)vec.x, (int)vec.y].parent != transform)
                return false;
        }
        return true;
   }

    void updateGrid()
    {
        for (int y = 0; y < Playfield.height;  y++)
            for (int x = 0; x < Playfield.width; x++)
                if (Playfield.grid[x, y] != null)
                    if (Playfield.grid[x, y].parent == transform)
                        Playfield.grid[x, y] = null;
        foreach (Transform child in transform)
        {
            Vector2 v = Playfield.roundVec2(child.position);
            Playfield.grid[(int)v.x, (int)v.y] = child;
        }
    }
}
