using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{

    public GameObject Bullet;
    public float BulletSpeed = 10f;
    private bool _isShooting;
    
    public float DistToGround = 0.1f;
    public LayerMask GroundLayer;
    private CapsuleCollider _col;

    public float Movespeed = 10f;
    public float RotateSpeed = 75f;

    private float _vInput;
    private float _hInput;

    private Rigidbody _rb;

    public float JumpVelocity = 5f;
    private bool _isJumping;

    

    void Start(){
        _rb = GetComponent<Rigidbody>();

        _col = GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        _vInput = Input.GetAxis("Vertical") * Movespeed;
        _hInput = Input.GetAxis("Horizontal") * RotateSpeed;

        _isJumping |= Input.GetKeyDown(KeyCode.Space);

        _isShooting |= Input.GetKeyDown(KeyCode.E);
 }

    void FixedUpdate(){
        Vector3 rotation = Vector3.up * _hInput;

        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);

        _rb.MovePosition(this.transform.position + this.transform.forward * _vInput * Time.fixedDeltaTime);

        _rb.MoveRotation(_rb.rotation * angleRot);

        if(IsGrounded() && _isJumping){
            _rb.AddForce(Vector3.up * JumpVelocity, ForceMode.Impulse);
        } _isJumping = false;

        if(_isShooting){
            GameObject newBullet = Instantiate(Bullet, this.transform.position + new Vector3(1, 0, 0), this.transform.rotation);
            Rigidbody BulletRB = newBullet.GetComponent<Rigidbody>();
            BulletRB.velocity = this.transform.forward * BulletSpeed;
        } _isShooting = false;
    } 

    private bool IsGrounded(){
        Vector3 capsuleBottom = new Vector3(_col.bounds.center.x, _col.bounds.min.y, _col.bounds.center.z);
        bool ground = Physics.CheckCapsule(_col.bounds.center, capsuleBottom, DistToGround, GroundLayer, QueryTriggerInteraction.Ignore);

        return ground;
    }
}
