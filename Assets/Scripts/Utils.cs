using UnityEngine;

public class Utils
{
    public static void ChangeSize(float scaleFactor, GameObject go)
    {
        if (scaleFactor <= 0) return;

        Vector2 currentScale = go.transform.localScale;
        Vector2 newScale = new Vector2(currentScale.x * scaleFactor, currentScale.y * scaleFactor);
        go.transform.localScale = newScale;
    }

    public static int CountTags(string tag)
    {
        var gameObjects = GameObject.FindGameObjectsWithTag(tag);
        return gameObjects.Length;
    }
}