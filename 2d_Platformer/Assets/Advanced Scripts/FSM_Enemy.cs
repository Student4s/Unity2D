using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM_Enemy : MonoBehaviour
{ 
    public GameObject _hero;
    public float _speed = 0.5f;
    public float _atackSpeed = 4f;
    public GameObject _rayPoint;
    public float _visionRadius = 6f;
    
    private float _atackRadius = 2f;

    public string _currentState;
    
    void Start()
    {
        _currentState = "Find";
    }
    
    void Update()
    {
        StateMachine();
        RotateToHero();
        Adv_player_contr.Atack +=ChangeState;
    }

    public void StateMachine()
    {
        switch (_currentState)
        {
            case("Find"):
                Find();
                break;
            case("MoveToHero"):
                MoveToHero();
                break;
            case("Atack"):
                Atack();
                break;
        }
    }
    
    public void Find()
    {
        transform.position = Vector2.MoveTowards(transform.position, _hero.transform.position, _speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, _hero.transform.position) <= _visionRadius)
        {
            _currentState = "MoveToHero";
        }
    }
    
    public void MoveToHero()
    {
        Debug.DrawRay(gameObject.transform.position, -transform.right*10, Color.yellow);
        RaycastHit2D _hit= Physics2D.Raycast(_rayPoint.transform.position, -transform.right);

        if (!_hit.collider.CompareTag("Portal"))
        {
            transform.position = Vector2.MoveTowards(transform.position, _hero.transform.position, _speed * Time.deltaTime);
        }
        else
        {
            Debug.Log(_hit.collider);
        }
        
        if (Vector2.Distance(transform.position, _hero.transform.position) <= _atackRadius)
        {
            _currentState = "Atack";
        }
        
        if (Vector2.Distance(transform.position, _hero.transform.position) >= _visionRadius)
        {
            _currentState = "Find";
        }

    }
    public void Atack()
    {
        _speed =_atackSpeed;
        transform.position = Vector2.MoveTowards(transform.position, _hero.transform.position, _speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, _hero.transform.position) >= _visionRadius)
        {
            _currentState = "Find";
        }
    }
    
    void RotateToHero()
    {

        Vector2 difference = _hero.transform.position - transform.position;
        float rotate = Mathf.Atan2(difference.x, difference.y) * Mathf.Rad2Deg;
        transform.rotation= Quaternion.Euler(0f,0f,-rotate + 270 );
    }

    void ChangeState()
    {
        _currentState = "Atack";
    }
}
