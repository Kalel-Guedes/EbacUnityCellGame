using UnityEngine;
using Core.Singleton;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using DG.Tweening;

public class Player : Singleton<Player>
{
    public Vector2 pastPosition;
    public float velocity = 1f;
    public float speed;
    public string compareTag = "Enemy";
    public string endTag = "EndLine";
    public GameObject endScreen;
    private float _currentSpeed;
    public Vector3 _startPosition;
    public bool invencible = false;
    private bool _canRun;
    public TextMeshProUGUI uiTextPowerUp;
    public Animator animator;
    public string animation = "Run";
    public string animationDeath = "Death";
    void Start()
    {
        /*_canRun = true;*/
        endScreen.SetActive(false);

        _startPosition = transform.position;
        ResetSpeed();
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == compareTag)
        {
            if (!invencible) EndGame();
        }
        else if (collision.transform.tag == endTag)
        {
            WinGame();
        }
    }

    void Update()
    {
        Animation();
        if (!_canRun)
        {
            return;
        }
        if (Input.GetMouseButton(0))
        {
            Move(Input.mousePosition.x - pastPosition.x);
        }

        pastPosition = Input.mousePosition;

        transform.Translate(transform.forward * _currentSpeed * Time.deltaTime);        

        //transform.Translate(transform.forward * speed * Time.deltaTime);
    }

    public void Animation()
    {
        if (_canRun) animator.SetBool(animation, true);
        else animator.SetBool(animation, false);
    }
    public void Move(float speed)
    {
        transform.position += Vector3.right * Time.deltaTime * speed * velocity;
    }
    public void StartRun()
    {
        _canRun = true;
    }
    public void EndGame()
    {
        _canRun = false;
        endScreen.SetActive(true);
        animator.SetTrigger(animationDeath);
    }
    public void WinGame()
    {
        _canRun = false;
        endScreen.SetActive(true);
    }


    public void SetPowerUpText(string s)
    {
        uiTextPowerUp.text = s;
    }
    public void PowerUpSpeedUp(float f)
    {
        _currentSpeed = f;
    }
    public void ResetSpeed()
    {
        _currentSpeed = speed;
    }
    public void SetInvencible(bool b = true)
    {
        invencible = b;
    }
    public void ChangeHeight(float amount, float duration, float animationDuration, Ease ease)
    {
        /*var p = transform.position;
        p.y = _startPosition.y + amount;
        transform.position = p;*/
        transform.DOMoveY(_startPosition.y + amount, animationDuration).SetEase(ease);//.OnComplete(ResetHeight);a        
        Invoke(nameof(ResetHeight), duration);
    }
    public void ResetHeight()
    {
        /*var p = transform.position;
        p.y = _startPosition.y;
        transform.position = p;*/
        transform.DOMoveY(_startPosition.y, .1f);
    }






}
