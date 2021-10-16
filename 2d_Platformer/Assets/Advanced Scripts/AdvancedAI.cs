using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedAI : MonoBehaviour
{
    public GameObject _hero;
    public float _speed = 0.5f;
    public float _atackSpeed = 4f;
    public GameObject _rayPoint;
    public float _visionRadius = 6f;

    [SerializeField]private bool _inVision = false;
    private float _atackRadius = 2f;


    void Start()
    {
        Adv_player_contr.Atack += Atack;
    }

    void Update()
    {
        RotateToHero();
        IsInVision();
        Move();
    }
    void IsInVision()//проверка попадаем ли мы в зону видимости персонажа
    {

        Debug.DrawRay(gameObject.transform.position, -transform.right*10, Color.yellow);
        RaycastHit2D _hit= Physics2D.Raycast(_rayPoint.transform.position, -transform.right);

            if ((_hit.collider.CompareTag("Portal") && Vector2.Distance(transform.position, _hero.transform.position) <= _visionRadius))
            {
                _inVision = true;
                Debug.Log("In Character Vision");
            }
            else
            {
                _inVision = false;
                Debug.Log(_hit.collider);
            }
 
    }

    void Move()
    {
        if (!_inVision)//передвигаемся если вне поля зрения игрока
        {
            transform.position = Vector2.MoveTowards(transform.position, _hero.transform.position, _speed * Time.deltaTime);
        }

        if (Vector2.Distance(transform.position, _hero.transform.position) <= _atackRadius)
        {
            Atack();//Запуск атаки на игрока, если мы в малом радиусе от него
        }
    }

    void Atack()
    {
        _speed =_atackSpeed;
        _rayPoint.transform.localPosition = new Vector2(0, 0);//По сути мы прячем точку запуска луча в самого врага. Так что теперь луч всегда будет попадать в его коллайдер
    }

    void RotateToHero()
    {

        Vector2 difference = _hero.transform.position - transform.position;
        float rotate = Mathf.Atan2(difference.x, difference.y) * Mathf.Rad2Deg;
        transform.rotation= Quaternion.Euler(0f,0f,-rotate + 270 );
    }
    
}
