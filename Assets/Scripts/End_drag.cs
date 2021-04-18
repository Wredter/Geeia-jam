using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End_drag : MonoBehaviour
{

public GameObject destination; 
public GameObject epicGodnoscWin;

public GameObject WINepic;
public GameObject WINzubrex;

public AudioSource dropSound;

private float startX, startY;
private bool isMoving, przedragowane;
public string Goodend;
public string BadEnd;
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
        if(WINzubrex.active)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                print("triger");
                SceneManager.LoadScene(BadEnd, LoadSceneMode.Single);
            }
        }
        if(WINepic.active)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                print("triger");
                SceneManager.LoadScene(Goodend, LoadSceneMode.Single);
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
            BG_change.canContinue = true;
            dropSound.Play(1);

            if(SceneManager.GetActiveScene().name == "Ending"){
                if(this.gameObject.name == epicGodnoscWin.name)
            {
                Debug.Log("Superancko ocaliłeś zioma coś tam");
                WINepic.gameObject.SetActive(true);
                destination.gameObject.SetActive(false);
            }
            else{
                Debug.Log("Superancko Żubrex ocalony profit");
                WINzubrex.gameObject.SetActive(true);
                destination.gameObject.SetActive(false);
            }
            }

        }
        else{
            this.transform.localPosition = new Vector3(restorePos.x, restorePos.y, restorePos.z);
        }

    }

}
