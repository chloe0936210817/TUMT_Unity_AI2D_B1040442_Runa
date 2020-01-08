using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NPC : MonoBehaviour
{
    #region 欄位
    //定義列舉
    public enum state
    {
        //一般,尚未完成,完成
        normal,notComplete,complete
    }
    //使用列舉
    public state _state;

    [Header("對話")]
    public string sayStart = "你好啊冒險者，可以幫我找丟失的20個金幣嗎?";
    public string sayNotComplete = "不不不，我丟的金幣可沒這麼少。";
    public string sayComplete = "你真是偉大的冒險者，太感謝了。";
    [Header("對話速度")]
    public float speed = 1.5f;
    [Header("任務相關")]
    public bool complete;
    public int countPlayer;
    public int countFinish = 10;
    [Header("介面")]
    public GameObject objCanvas;
    public Text textSay;
    #endregion

    //2D觸發事件
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name =="主角")
        {
            Say();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "主角")
        {
            SayClose();
        }
    }

    //對話:打字效果
    private void Say()
    {
        objCanvas.SetActive(true);
        StopAllCoroutines();

        if (countPlayer >= countFinish) _state = state.complete;

        switch (_state)
        {
            case state.normal:
                StartCoroutine(ShowDialog(sayStart));
                _state = state.notComplete;
                break;
            case state.notComplete:
                StartCoroutine(ShowDialog(sayNotComplete));
                break;
            case state.complete:
                StartCoroutine(ShowDialog(sayComplete));
                break;
        }
    }

    private IEnumerator ShowDialog(string say)
    {
        textSay.text = "";

        for (int i = 0; i < say .Length; i++)
        {
            textSay.text += say[i].ToString();
            yield return new WaitForSeconds(speed);
        }
    }

    //關閉對話
    private void SayClose()
    {
        StopAllCoroutines();
        objCanvas.SetActive(false);
    }

    public void PlayerGet()
    {
        countPlayer++;
    }
}
