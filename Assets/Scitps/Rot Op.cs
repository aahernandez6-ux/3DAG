using UnityEngine;

public class RotOp : MonoBehaviour
{
 

     [SerializeField] private float rotationSpeed = 200f;
    

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3 (0,1,0),  rotationSpeed * Time.deltaTime);
    }
}
