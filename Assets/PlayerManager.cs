using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Tốc độ di chuyển của nhân vật
    public float speed =5f;
    // xmax, xmin mặt định dựa vào độ vị trí khung main camera
    float xmax =12f, xmin=-12f;
    float ymax =5f, ymin=-5f;
    // Khoảng cách z, chỉ dùng trong 3D
    float distance;
    // Độ rộng của nhân vật
    float padding =0.75f;
    float paddingy =1f;

    void Start()
    {
       Camera camera = Camera.main;
       Debug.Log(camera.transform.position.x +" .... "+ camera.transform.position.y);

       distance = camera.transform.position.z - transform.position.z;
       // Chuyển Viewport thành Worldpoint, 0,0 và 1,1 vì Viewport chỉ có 0 và 1
       xmin = camera.ViewportToWorldPoint(new Vector3(0,0,distance)).x+padding;
       xmax = camera.ViewportToWorldPoint(new Vector3(1,0,distance)).x-padding;
       ymin = camera.ViewportToWorldPoint(new Vector3(0,0,distance)).y+paddingy;
       ymax = camera.ViewportToWorldPoint(new Vector3(0,1,distance)).y-paddingy;
       Debug.Log(xmin+" -- "+xmax+" : "+ymin+" -- "+ymax);
       
       // Xét nhân vật tại vị trí xmin, ymin cho tất cả màn hình
       transform.position= new Vector3(xmin,ymin,0) ;
    }

    void Update()
    {

        if(Input.GetKey(KeyCode.LeftArrow)){
            //Di chuyển qua trái vô cực
            //transform.position += new Vector3(-speed*Time.deltaTime,0,0);
            //Di chuyển qua trái, với vị trí chỉ nằm trong xmin và xmax
            transform.position = new Vector3(Mathf.Clamp(transform.position.x - speed*Time.deltaTime,xmin,xmax),transform.position.y,transform.position.z);
        }else if(Input.GetKey(KeyCode.RightArrow)){
            //transform.position += new Vector3(speed*Time.deltaTime,0,0);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x + speed*Time.deltaTime,xmin,xmax),transform.position.y,transform.position.z);
        }
    }
}

