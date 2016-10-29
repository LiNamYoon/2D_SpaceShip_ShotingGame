using UnityEngine;
using System.Collections;

public class CObjectExit : MonoBehaviour 
{
    
	
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag.Equals("Space"))
        {
            Destroy(gameObject);
        }
        
    }
}


