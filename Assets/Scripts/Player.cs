using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float x, z;
    float speed = 0.1f;

    Quaternion characterRot;
    float Xsensityvity = 3f, Ysensityvity = 3f;
    
    bool cursorLock = true;

    Rigidbody rb;


    // 弾
    [SerializeField]
    [Tooltip("弾の発射場所")]
    private GameObject firingPoint;

    [SerializeField]
    [Tooltip("弾")]
    private GameObject bullet;

    // [SerializeField]
    // [Tooltip("弾の速さ")]
    private float Speed = 45f;

    void Start()
    {
        characterRot = transform.localRotation;
        
        //Rigidbodyを取得
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // float xRot = Input.GetAxis("Mouse X") * Ysensityvity;
        // // float yRot = Input.GetAxis("Mouse Y") * Xsensityvity;

        // characterRot *= Quaternion.Euler(0, xRot, 0);
        // transform.localRotation = characterRot;
        
        // //もしスペースキーが押されたら
        // if (Input.GetKey(KeyCode.Space))
        // {
        //     // //Rigidbodyを停止
        //     rb.velocity = Vector3.zero;
        //     // Debug.Log("スペースキー");
            
        //     // 弾を発射する
        //     // LauncherShot();
        // }

        // カーソルの表示・非表示
        UpdateCursorLock();
    }

    private void FixedUpdate()
    {
        // x = 0;
        // z = 0;

        // x = Input.GetAxisRaw("Horizontal") * speed;
        // z = Input.GetAxisRaw("Vertical") * speed;

        // transform.position += transform.forward * z + transform.right * x;
        
        //もしスペースキーが押されたら
        if (Input.GetKey(KeyCode.Space))
        {
            // 弾を発射する
            LauncherShot();
        }
    }


    public void UpdateCursorLock()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            cursorLock = false;
        }
        else if(Input.GetMouseButton(0))
        {
            cursorLock = true;
        }


        if (cursorLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if(!cursorLock)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void LauncherShot()
    {
        // 弾を発射する場所を取得
        Vector3 bulletPosition = firingPoint.transform.position;
        // 上で取得した場所に、"bullet"のPrefabを出現させる
        GameObject newBall = Instantiate(bullet, bulletPosition, transform.rotation);
        // 出現させたボールのforward(z軸方向)
        Vector3 direction = newBall.transform.forward;
        // 弾の発射方向にnewBallのz方向(ローカル座標)を入れ、弾オブジェクトのrigidbodyに衝撃力を加える
        newBall.GetComponent<Rigidbody>().AddForce(direction * Speed, ForceMode.Impulse);
        // 出現させたボールの名前を"bullet"に変更
        newBall.name = bullet.name;
        // 出現させたボールを0.8秒後に消す
        Destroy(newBall, 0.8f);
    }
}
[System.Serializable]
public class AxleInfo {
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor; //駆動輪か?
    public bool steering; //ハンドル操作をしたときに角度が変わるか？
}