using UnityEngine;

public class FixCursorTexture : MonoBehaviour
{
    void Start()
    {
        // Hide the default cursor if causing issues
        Cursor.visible = true;
        
        // Reset to default cursor to avoid texture errors
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
