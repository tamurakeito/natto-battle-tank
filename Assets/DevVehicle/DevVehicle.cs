using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevVehicle : MonoBehaviour
{
    public GameObject Wheel;
    public GameObject Vehicle;
    float speed = 1.0f;
    float x,z = 0;

    private void FixedUpdate()
    {
        x = Input.GetAxisRaw("Horizontal") * 0.5f;
        z = Input.GetAxisRaw("Vertical") * speed;
        Vector3 direction = Wheel.transform.forward;    //  Z軸方向取得

        // 前後方向のアクセル
        Vehicle.GetComponent<Rigidbody>().AddForce(direction * z, ForceMode.Impulse);

        // 回転の制御
        Vehicle.GetComponent<Rigidbody>().AddTorque(x * Vector3.up * Mathf.PI, ForceMode.Impulse);
    }
}
