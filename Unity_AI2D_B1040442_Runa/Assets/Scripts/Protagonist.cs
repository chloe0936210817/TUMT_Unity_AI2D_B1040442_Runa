using UnityEngine;

public class Protagonist : MonoBehaviour
{
    public int speed = 50;
    public float jump = 2.5f;
    public string protagonistName = "主角";
    public bool pass = false;

    private Rigidbody2D r2d;
    private Transform tra;

    //開始事件
    private void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        tra = GetComponent<Transform>();
    }

    //更新事件
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) tra.eulerAngles = new Vector3(0, 0, 0);
    }

    //固定更新事件
    private void FixedUpdate()
    {
        r2d . AddForce(new Vector2(speed*Input.GetAxis("Horizontal"), 0));
    }
}
