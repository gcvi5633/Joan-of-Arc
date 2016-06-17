using UnityEngine;

using UnityEngine.SceneManagement;
public class GameManager_Scr : MonoBehaviour
{
    public GameObject m_ImageManagerBox;
    public TextAsset m_GameProcessScript;
    public TextBoxManager m_TextBoxManager;
    public int sceneNumber;

    string[] m_GameProcessScript_Line;
    int m_CurrentLine =0;
    int m_Status = 0;
    int m_currentLine =0;
    float m_TotalTime = 0;
    float m_TimeOfWiting = 0;
    ImageManager_Scr m_ImageManager;
    
    //int u= 0;
    //bool yy = false;
    void Start()
    {
        m_ImageManager = m_ImageManagerBox.GetComponent<ImageManager_Scr>();
        m_GameProcessScript_Line= m_GameProcessScript.text.Split('\n');
        //m_ImageManager.ShowImage("001");
        //Debug.Log(GameProcessScript_Line[1].IndexOf("Wweqewewae"));
        //m_ImageManager.ShowImage("001");
        //Debug.Log(m_GameProcessScript_Line[2].Substring(3, m_GameProcessScript_Line[2].Length-3));
    }
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_ImageManager.ImageChang("002");
        }
        */
        //Debug.Log(m_Status);
        if (m_CurrentLine>= m_GameProcessScript_Line.Length)
        {
            return;
        }
        switch (m_Status)
        {
            case 0:
                if (m_GameProcessScript_Line[m_CurrentLine].IndexOf("@!") == 0)
                {
                    if (m_GameProcessScript_Line[m_CurrentLine].IndexOf("w") == 2)
                    {
                        m_Status = 1;
                        m_TimeOfWiting = int.Parse(m_GameProcessScript_Line[m_CurrentLine].Substring(3, 6)) / 1000f;
                    }
                    else if (m_GameProcessScript_Line[m_CurrentLine].IndexOf("p") == 2)
                    {
                        m_Status = 2;
                    }
                    else if (m_GameProcessScript_Line[m_CurrentLine].IndexOf("t") == 2)
                    {
                        m_Status = 4;
                    }
                    else if (m_GameProcessScript_Line[m_CurrentLine].IndexOf("s") == 2)
                    {
                        m_Status = 6;
                    }
                }
                else
                {
                    m_CurrentLine++;
                }
                break;
            case 1://w,等待時間
                if ((m_TotalTime += Time.deltaTime) > m_TimeOfWiting)
                {
                    //Debug.Log("hhhhhh");
                    m_TotalTime = 0;
                    m_Status = 0;
                    m_CurrentLine++;
                }
                break;
            case 2://p,切換圖片
                m_ImageManager.ImageChang(m_GameProcessScript_Line[m_CurrentLine].Substring(3, 3));
                m_Status = 3;
                break;
            case 3:
                if (!m_ImageManager.m_actlOck)
                {
                    m_CurrentLine++;
                    m_Status = 0;
                }
                
                break;
            case 4://t,文字
                string[] cha = m_GameProcessScript_Line[m_CurrentLine].Split('#');
                m_TextBoxManager.textLines = cha;
                m_TextBoxManager.currentLine = 1;
                m_TextBoxManager.endAtLine = cha.Length -1;
                m_TextBoxManager.EnableTextBox();
                m_Status = 5;
                break;
            case 5:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    m_TextBoxManager.NextLine();
                }
                if (!m_TextBoxManager.isActive)
                {
                    m_Status = 0;
                    m_CurrentLine++;
                }
                break;

            case 6:

                ChangeScene(sceneNumber);


                break;
        }
        

        
        /*
        if (!yy & u == 200)
        {
            m_ImageManager.ImageChang("002");
            yy = true;
        }
        u++;
        Debug.Log(u);
        Debug.Log(Time.deltaTime);
        */
    }
    void ChangeScene(int a)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}