using UnityEngine;

public class Protagonist : MonoBehaviour
{
    #region
    public int speed = 50;
    public float jump = 2.5f;
    public string protagonistName = "主角";
    public bool pass = false;
    public bool isGround = false;
    #endregion
    private Rigidbody2D r2d;
    //private Transform tra;

    //開始事件
    private void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        //tra = GetComponent<Transform>();
    }

    //更新事件
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) Turn(0);
        if (Input.GetKeyDown(KeyCode.A)) Turn(180);
    }

    //固定更新事件
    private void FixedUpdate()
    {
        Walk();
        Jump();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGround = true;
        Debug.Log("碰到東西:" + collision.gameObject);
    }

    //走路
    private void Walk()
    {
        r2d . AddForce(new Vector2(speed*Input.GetAxis("Horizontal"), 0));
    }

    //跳躍
    private void Jump()
    {
            if (Input.GetKeyDown(KeyCode.Space) && isGround==true)
        {
                isGround = false;
                r2d.AddForce(new Vector2(0,jump));
            
        }
    }

    //右轉
    private void TurnRight()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
    }
    private void TurnLeft()
    {
        transform.eulerAngles = new Vector3(0, 180, 0);
    }

    //轉彎
    private void Turn(int direction)
    {
        transform.eulerAngles = new Vector3(0, direction, 0);
    }

}
