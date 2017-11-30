using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerController : MonoBehaviour {

    private bool doMove = true;

    public float scrollspeed = 5f;
    public float panSpeed = 30f;
    public float panBorder = 10f;

    private float minY = 10f;
    private float maxY = 80f;
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            doMove = !doMove;
        }

        if (!doMove)
            return;
        if (Input.GetKey("w")|| Input.mousePosition.y >= Screen.height - panBorder)
        {
            transform.Translate(Vector3.forward*panSpeed*Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorder)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorder)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorder)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }



        float scroll =  Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.y -= scroll * 1000 * scrollspeed*Time.deltaTime;

        transform.position = pos;
    }
}
