using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HPBar_scr : MonoBehaviour {
    public Image m_HPImage;
    public float m_HP, m_LowHP, m_HighHP;
    
    // Use this for initialization
    void Start () {
        
	}
	// Update is called once per frame
	void Update () {
        m_HP = Mathf.Clamp(m_HP, 0, 100);
        m_HPImage.rectTransform.anchoredPosition = new Vector2((m_HighHP - m_LowHP )/ 100 * m_HP+m_LowHP, m_HPImage.rectTransform.anchoredPosition.y);
    }
}
