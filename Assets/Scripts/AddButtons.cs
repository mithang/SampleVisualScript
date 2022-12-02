using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Dùng chức năng để tạo ra các button trong board
public class AddButtons : MonoBehaviour {

    //C1:
    //[SerializeField]
    //private GameObject Button;

    //C2: Nếu dùng public thì không cần "private và SerializeField"
    public GameObject Button;
    public Transform panel;

    void Awake()
    {
        for(int i = 0; i < 8; i++)
        {
            //Tạo 8 cái button và gán vào panel
            GameObject btn = Instantiate(Button);
            btn.name = "" + i;
            btn.transform.SetParent(panel,false);//false: dùng transform của cha, true giữ transform của nó
            
        }
    }

}
