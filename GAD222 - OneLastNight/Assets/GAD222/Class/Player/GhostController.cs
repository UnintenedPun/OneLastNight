using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions; // Needed for InputAction

public class GhostController : MonoBehaviour
{
    // Adjustable movement speed in the Inspector
    [SerializeField]
    private float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Collider2D pCollider;
    private Vector2 movementInput;

    // value to keep track of interacting
    private float interactValue = 0f;

    // bool to ensure we are over a character
    private bool canInteract = false;

    // bool to check is we are talking
    public bool isTalking = false;

    void Awake()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
        pCollider = GetComponent<Collider2D>();

        // Safety check to ensure the Rigidbody2D exists
        if (rb == null)
        {
            Debug.LogError("GhostController requires a Rigidbody2D component to work!");
            enabled = false; // Disable the script if no Rigidbody2D is found
        }

        // Saftey check to ensure the 2D Collider exists
        if (pCollider == null)
        {
            Debug.LogError("GhostController requires a 2D Collider component to work!");
            enabled = false; // Disable the script if no 2D Collider is found
        }
    }

    // This method is automatically called by the Player Input component 
    // when the 'Move' action is performed, if Behavior is set to 'Send Messages'
    // or manually hooked up in the 'Unity Events' behavior.
    public void OnMove(InputAction.CallbackContext context)
    {
        // Read the value of the 2D Vector input.
        // It returns a Vector2 with values between -1 and 1 for X and Y.
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        //call this when we want to interact with an object
        // Returns value between 1 and 0 - 1 being button pressed and 0 button release
        interactValue = context.ReadValue<float>();

        if (interactValue == 1f && canInteract == true && isTalking == false)
        {
            // Do Something
        }

        if (interactValue == 0f && isTalking == false)
        {
            // if button up do nothing
        }
    }

    // Physics movement should be handled in FixedUpdate for consistency
    private void FixedUpdate()
    {
        // Calculate the movement vector
        Vector2 velocity = movementInput * moveSpeed;

        // Apply the velocity to the Rigidbody2D for physics-based movement
        rb.linearVelocity = velocity;

        // Optional: Add code for rotation/sprite flipping based on X direction here
    }

    public void StartTalking()
    {
        if (isTalking == false)
        {
            isTalking = true;
        }
    }
}