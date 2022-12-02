using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Lấy các button hiện có và xử lý
public class GameController : MonoBehaviour {
    
    //Khai báo biến xử lý
    private bool firstGuess, secondGuess;
    private int firstIndex, secordIndex, TotalGuess, NoOfGuess, CorrectGues;
    private List<Button> btnList = new List<Button>();
    private string firstName, secondName;

    //Khai báo biến UI
    public List<Sprite> GameSprite = new List<Sprite>();
    public Sprite background;
    //Load các hình ảnh để dùng, tuỳ vào level mà nạp vào List<Sprite>
    public Sprite[] sourceSprites;

    //Hàm khởi tạo trước khi start, Hàm này cho phép thấy dữ liệu khi chạy game
    void Awake()
    {
        //Load tất cả các file ảnh nằm trong Resources, thư mục Resources cần tự tạo
        sourceSprites = Resources.LoadAll<Sprite>("Sprites/Imgs");

    }

    void Start () {

        GetButtons();
        AddListener();
        AddSprites();
        //Số lần đoán đúng để kết thúc game
        TotalGuess = btnList.Count / 2;
        Shuffle(GameSprite);
        NoOfGuess = 0;
    }
	
    //Gán danh sách ảnh vào danh sách list
    void AddSprites()
    {
        int index = 0;
        int size = btnList.Count;
        for(int i = 0; i < size; i++)
        {
            if (i == size / 2)
            {
                index = 0;
            }
            GameSprite.Add(sourceSprites[index]);
            index++;
        }
    }

    void GetButtons()
    {
        //Sau khi chạy Script AddButton thì tất cả button đã được nạp vào Panel và có thể lấy được
        //Lấy hết các button hiện có thêm vào LIST
        GameObject[] obj = GameObject.FindGameObjectsWithTag("TagButtonPizzle");
        for (int i = 0; i < obj.Length; i++)
        {
            btnList.Add(obj[i].GetComponent<Button>());
            //Thêm background che các đối tượng bên trong
            btnList[i].image.sprite = background;
            
        }
    }

	void AddListener()
    {
        foreach (Button btn in btnList)
        {
            btn.onClick.AddListener(()=>PickPuzzle());
        }       
    }

    void PickPuzzle()
    {
        //Kiểm tra đang click ô bao nhiêu trả về index
        string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        //Trả về name đã set trong AddButton.cs
        Debug.Log("Button: " + name);
        if (!firstGuess)
        {
            firstGuess = true;
            firstIndex = int.Parse(name);
            firstName = GameSprite[firstIndex].name;
            //Hiển thị hình khi click vào
            btnList[firstIndex].image.sprite = GameSprite[firstIndex];
            Debug.Log("1st index: "+firstIndex+" 1st name= "+firstName);
        }
        else if(!secondGuess)
        {
            secondGuess = true;
            secordIndex = int.Parse(name);
            secondName = GameSprite[secordIndex].name;
            btnList[secordIndex].image.sprite = GameSprite[secordIndex];
            Debug.Log("2st index: " + secordIndex + " 2st name= " + secondName);
            NoOfGuess++;
            //Chờ đợi khoảng 1s để xử, vì hiện tại khi click chưa kiệp xử lí button click lần 2
            StartCoroutine(CheckIfPuzzleMatched());
            //C2: Có thể stop khi thực hiện chờ đợi
            //StartCoroutine("CheckIfPuzzleMatched");

        }

    }


    IEnumerator CheckIfPuzzleMatched()
    {
        yield return new WaitForSeconds(1);
        if (firstName == secondName && firstIndex != secordIndex)
        {
            Debug.Log("Hai ảnh giống nhau");
            btnList[firstIndex].interactable = false;
            btnList[secordIndex].interactable = false;

            btnList[firstIndex].image.color = new Color(0,0,0,0);
            btnList[secordIndex].image.color = new Color(0, 0, 0, 0);

            CorrectGues++;
            CheckIfFinshed();
        }
        else
        {
            Debug.Log("Hai ảnh khác nhau");
            btnList[firstIndex].image.sprite = background;
            btnList[secordIndex].image.sprite = background;
         
        }
        firstGuess = secondGuess = false;
    }

    void CheckIfFinshed()
    {
        Debug.Log(CorrectGues + " " + TotalGuess);
        if(CorrectGues == TotalGuess)
        {
            Debug.Log("Win with "+NoOfGuess);
        }
    }


    //Sắp xếp ngẫu nhiên các button
    void Shuffle(List<Sprite> list)
    {
        Sprite temp;
        for(int i = 0; i < list.Count; i++)
        {
            temp = list[i];
            int random = UnityEngine.Random.Range(i, list.Count);
            list[i] = list[random];
            list[random] = temp;
        }
    }

}   

