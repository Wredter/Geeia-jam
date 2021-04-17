using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End_drag : MonoBehaviour
{

public GameObject destination; 

public GameObject epicGodnoscWin;

private float startX, startY;
private bool isMoving, przedragowane;

private Vector3 restorePos;

    // Start is called before the first frame update
    void Start()
    {
        restorePos = this.transform.localPosition;
        przedragowane = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(przedragowane == false)
        {
            if(isMoving)
            {
                Vector3 mousePos;
                mousePos = Input.mousePosition;
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);

                this.gameObject.transform.localPosition = new Vector3(mousePos.x - startX, mousePos.y - startY, this.gameObject.transform.localPosition.z);
            }
        }
        
    }

    private void OnMouseDown()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startX = mousePos.x - this.transform.localPosition.x;
            startY = mousePos.y - this.transform.localPosition.y;
            isMoving = true; 
        }
    }

    private void OnMouseUp()
    {
        isMoving = false; 

        if(Mathf.Abs(this.transform.localPosition.x - destination.transform.localPosition.x) <= 0.5f &&
            Mathf.Abs(this.transform.localPosition.y - destination.transform.localPosition.y) <= 0.5f)
        {
            this.transform.position = new Vector3(destination.transform.position.x, destination.transform.position.y, destination.transform.position.z);
            przedragowane = true;

            if(this.gameObject.name == epicGodnoscWin.name)
            {
                Debug.Log("Superancko ocaliłeś zioma coś tam");
            }
            else{
                Debug.Log("Superancko Żubrex ocalony profit");
            }

        }
        else{
            this.transform.localPosition = new Vector3(restorePos.x, restorePos.y, restorePos.z);
        }

    }

}
