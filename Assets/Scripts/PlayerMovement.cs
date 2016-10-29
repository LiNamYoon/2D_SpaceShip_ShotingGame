using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
    public float _speed;
    public float Limit_x;
    public float Limit_y;

    


    void Start ()
	{
	
	}
		
	void Update () 
	{
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.Translate(Vector2.up * v * _speed * Time.deltaTime);
        transform.Translate(Vector2.right * h * _speed * Time.deltaTime);

        if (transform.position.x > Limit_x)
        {
            transform.position = new Vector2(Limit_x, transform.position.y);
        }
        if (transform.position.x < -Limit_x)
        {
            transform.position = new Vector2(-Limit_x, transform.position.y);
        }
        if (transform.position.y > Limit_y)
        {
            transform.position = new Vector2(transform.position.x, Limit_y);
        }
        if (transform.position.y < -Limit_y)
        {
            transform.position = new Vector2(transform.position.x, -Limit_y);
        }
    }

	void SetReference()
	{
		
	}
}


