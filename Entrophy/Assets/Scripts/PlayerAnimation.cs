using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        _playerAnim = GetComponentInChildren<Animator>();
    }

    public void Scale(bool state)
    {
        _playerAnim.SetBool("Scale", state);
    }
}
