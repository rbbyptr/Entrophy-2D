using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _dashSpeed = 50f;
    [SerializeField] private bool _cooldown = true;
    private Rigidbody2D _rb;
    private PlayerAnimation _playerAnim;
    private SpriteRenderer _playerSprite;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerAnim = GetComponent<PlayerAnimation>();
        _playerSprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Skill();
    }

    private void Movement()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");
        Vector2 move = new Vector2(xInput, yInput);
        
        Dash(xInput, yInput);
        _rb.velocity = move * _speed;
    }

    private void Dash(float x, float y)
    {
        if (Input.GetKeyDown(KeyCode.Space) && ( x == 1 || x == -1 ))
        {
            _speed = _dashSpeed;
            StartCoroutine(SpeedResetRoutine());
        }
        else if (Input.GetKeyDown(KeyCode.Space) && ( y == 1 || y == -1 ))
        {
            _speed = _dashSpeed;
            StartCoroutine(SpeedResetRoutine());
        }
    }

    private void Skill()
    {
        if (Input.GetKeyDown(KeyCode.E) && _cooldown == true)
        {
            Debug.Log("get");
            // _playerSprite.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            _playerAnim.Scale(true);
            StartCoroutine(ResetScaleRoutine());
        }
    }

    IEnumerator SpeedResetRoutine()
    {
        yield return new WaitForSeconds(0.01f);
        _speed = 5f;
    }

    IEnumerator ResetScaleRoutine()
    {
        yield return new WaitForSeconds(5f);
        _playerAnim.Scale(false);
        _playerSprite.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        _cooldown = false;
        StartCoroutine(ResetCooldown()); 
    }

    IEnumerator ResetCooldown()
    {
        yield return new WaitForSeconds(5f);
        _cooldown = true;
    }
}
