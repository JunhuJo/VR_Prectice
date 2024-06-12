using System.Collections;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class TempUI : MonoBehaviour
{
    [SerializeField] Button Btn_Temp;
    [SerializeField] Slider Slider_Temp;

    [SerializeField] GameObject pensGate;
    [SerializeField] Text OpenText;
    [SerializeField] float MoveSpeed = 2.0f;
    public bool open = false;
    public bool move = false;

    private void Update()
    {
        Open_Btn();
        StartCoroutine(MoveGate());
    }

    private void OnEnable()
    {
        if (Btn_Temp != null)
            Btn_Temp.onClick.AddListener(OnClick_TemporalBtn);

        if (Slider_Temp != null)
            Slider_Temp.onValueChanged.AddListener(OnValueChanged_Slider);
    }

    private void OnDisable()
    {
        if (Btn_Temp != null)
            Btn_Temp.onClick.RemoveListener(OnClick_TemporalBtn);

        if (Slider_Temp != null)
            Slider_Temp.onValueChanged.RemoveListener(OnValueChanged_Slider);
    }

    private void OnClick_TemporalBtn()
    {
        open = true;
    }

    void Open_Btn()
    {
        if(open)
        Slider_Temp.value += 0.1f;
    }

    private void OnValueChanged_Slider(float value)
    {
        if (Slider_Temp.value == 1)
        {
            OpenText.text = "¿Ï·á";
            move = true;
        }
    }

   
    IEnumerator MoveGate()
    {
        if (move)
        {
            pensGate.transform.Translate(Vector3.down * MoveSpeed * Time.deltaTime);
            yield return new WaitForSeconds(5.0f);
            pensGate.gameObject.SetActive(false);
        }
    }
}
