using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{

    public float Movespeed = 10f;
    public float RotateSpeed = 75f;

    private float _vInput;
    private float _hInput;

    void Update()
    {
        _vInput = Input.GetAxis("Vertical") * Movespeed;
        _hInput = Input.GetAxis("Horizontal") * RotateSpeed;

        this.transform.Translate(Vector3.forward * _vInput * Time.deltaTime);
        this.transform.Rotate(Vector3.up * _hInput * Time.deltaTime);
 }
}
