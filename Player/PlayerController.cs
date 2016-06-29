using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    Vector2 MousePos;
    Vector2 DemappedMousePos;

    public TileWorld World;
    new Camera camera;

    void Start()
    {
        camera = GetComponent<Camera>();
    }
    // Update is called once per frame
    void Update () {
        MousePos = Input.mousePosition;
        DemappedMousePos.x = camera.ScreenToWorldPoint(MousePos).x;
        DemappedMousePos.y = camera.ScreenToWorldPoint(MousePos).y;

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            TilePlaceRemove.SetTile(World, new TileAir(), DemappedMousePos);
        }

        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            TilePlaceRemove.SetTile(World, new TileGold(), DemappedMousePos);
        }
    }
}
