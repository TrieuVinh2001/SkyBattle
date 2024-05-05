using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : BaseCharacterMovement
{
    [SerializeField] private GameObject shipModel;
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        CharacterMoving(Vector3.zero);
    }

    public override void CharacterMoving(Vector3 destination)
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                Vector3 touchPosition = touch.position;
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, 100));
                shipModel.transform.position = new Vector3(worldPosition.x, worldPosition.y, shipModel.transform.position.z);
            }
        }
    }
}
