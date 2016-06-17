using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ImageManager_Scr : MonoBehaviour {

    public GameObject[] m_PhotoCache;
    public GameObject m_black;
    Image m_black_Image;
    GameObject m_CurrentGameObject, m_ChangeToGameObject;
    public Transform Parent;
    public bool m_actlOck = false;
    int step = 0;
    // Use this for initialization
    void Awake()
    {
        m_black_Image = m_black.GetComponent<Image>();
        foreach (GameObject a in m_PhotoCache)
        {
            a.SetActive(false);
            /*
            a.transform.parent = m_parent;
            a.transform.localPosition = new Vector3(0, 0, 0);
            a.transform.localScale = new Vector3(1, 1, 1);

            */
        }
        m_PhotoCache[0].SetActive(true);


    }
    void Start()
    {

        m_black_Image.color = new Color(1, 1, 1, 0);
        /*
        for (int i = 0; i < m_PhotoCache.Length; i++)
        {
            m_PhotoCache[i].transform.SetParent(Parent);
            m_PhotoCache[i].transform.localPosition = new Vector3(0, 0, 0);
            m_PhotoCache[i].transform.localScale = new Vector3(1, 1, 1);
        }
        */
    }
    // Update is called once per frame
    void Update()
    {
        switch (step)
        {
            case 0:
                break;
            case 1:
                if (SlowDownUp(ref m_black_Image, Time.deltaTime, true))
                {
                    if (m_CurrentGameObject != null)
                    {
                        m_CurrentGameObject.SetActive(false);
                    }
                    m_CurrentGameObject = m_ChangeToGameObject;
                    Debug.Log("轉換圖片"+m_ChangeToGameObject);
                    m_CurrentGameObject.SetActive(true);
                    step = 2;
                }
                else
                {
                    m_actlOck = true;
                }
                break;
            case 2:
                if (SlowDownUp(ref m_black_Image, Time.deltaTime, false))
                {
                    step = 0;
                    m_actlOck = false;
                }
                break;
            default:
                break;

        }
    }
    public void ShowImage(string image)
    {
        if (m_actlOck == false)
        {
            foreach (GameObject gggg in m_PhotoCache)
            {
                if (gggg.name == image)
                {
                    if (m_CurrentGameObject != null)
                    {
                        m_CurrentGameObject.SetActive(false);
                    }
                    m_CurrentGameObject = gggg;
                    m_CurrentGameObject.SetActive(true);
                }
            }
        }
    }
    public void ImageChang(string imageName)
    {
        if (m_actlOck == false)
        {
            step = 1;
            foreach (GameObject gggg in m_PhotoCache)
            {
                if (gggg.name == imageName)
                {
                    m_ChangeToGameObject = gggg;
                }
            }
        }
    }
    bool SlowDownUp(ref Image image, float a, bool Enter)//ture代表出現,回傳直ture表示已完成
    {
        if (Enter)
        {
            if (image.color.a < 1 & image.color.a + a < 1)
            {
                image.color = new Color(1, 1, 1, image.color.a + a);
                return false;
            }
            else
            {
                image.color = new Color(1, 1, 1, 1);
                return true;
            }
        }
        else
        {
            if (image.color.a > 0 & image.color.a - a > 0)
            {
                image.color = new Color(1, 1, 1, image.color.a - a);
                return false;
            }
            else
            {
                image.color = new Color(1, 1, 1, 0);
                return true;
            }
        }

    }
    /*
    bool NearToValue(ref float begin, float end, float a)//新值以begin參考傳出,ture表示已等於終點值
    {
        if (begin != end)
        {
            if (begin - end > 0 & begin - a > end)
            {
                begin -= a;
                return false;
            }
            else if (begin - end < 0 & begin + a < end)
            {
                begin += a;
                return false;
            }
            else
            {
                begin = end;
            }
        }
        return true;
    }
    */
}
