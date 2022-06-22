using UnityEngine;
using UnityEngine.InputSystem;

public class Player1 : MonoBehaviour
{
    private float inputX;
    [SerializeField]private float tiltAngle = 180.0f;
    // Start is called before the first frame update0
    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        inputX = movementVector.x;
    }
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0, 0, inputX * tiltAngle * Time.deltaTime);
    }
}
