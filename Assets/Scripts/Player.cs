using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float x, z;
    float speed = 1.0f;

    public GameObject Vehicle;

    bool cursorLock = true;

    // 弾
    [SerializeField]
    [Tooltip("弾の発射場所")]
    private GameObject firingPoint;

    [SerializeField]
    [Tooltip("弾")]
    private GameObject bullet;

    // [SerializeField]
    // [Tooltip("弾の速さ")]
    private float speed_bullet = 45f;

    // Update is called once per frame
    void Update()
    {
        // カーソルの表示・非表示
        // UpdateCursorLock();
    }

    private void FixedUpdate()
    {
        x = Input.GetAxisRaw("Horizontal") * 0.5f;
        z = Input.GetAxisRaw("Vertical") * speed;
        Vector3 direction = Vehicle.transform.forward;    //  Z軸方向取得

        // 前後方向のアクセル
        Vehicle.GetComponent<Rigidbody>().AddForce(direction * z, ForceMode.Impulse);

        // 回転の制御
        Vehicle.GetComponent<Rigidbody>().AddTorque(x * Vector3.up * Mathf.PI, ForceMode.Impulse);

        
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
        newBall.GetComponent<Rigidbody>().AddForce(direction * speed_bullet, ForceMode.Impulse);
        // 出現させたボールの名前を"bullet"に変更
        newBall.name = bullet.name;
        // 出現させたボールを0.8秒後に消す
        Destroy(newBall, 0.8f);
    }
}