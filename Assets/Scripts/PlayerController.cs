using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float breathHoldTime = 5f; // Time in seconds that the player can hold their breath
    private float breathTimer = 0f;
    private bool isInhaling = true;
    private bool isHolding = false;
    private Animator animator;

    public float currentOxygen = 0f;
    public float maxOxygen = 100f;

    public UIManager uiManager;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        HandleBreathing();
        CheckInput();
    }

    public void CheckInput()
    {
        if (uiManager.isGame && Input.GetKey(KeyCode.Escape))
        {
            uiManager.isGame = true;
            uiManager.OpenInGameSettings();
        }
    }

    private void HandleBreathing()
    {
        if (isHolding)
        {
            if (breathTimer < breathHoldTime)
            {
                breathTimer += Time.deltaTime;
            }
            else
            {
                isHolding = false;
                breathTimer = 0f;
                if (currentOxygen > 50f) // If 
                {
                    animator.SetTrigger("Exhale");
                }
                else
                {
                    animator.SetTrigger("Inhale");
                }
            }
        }
        else
        {
            if (isInhaling && currentOxygen <= maxOxygen)
            {
                // Logic for breathing in
                animator.SetTrigger("Inhale");
            }
            else
            {
                currentOxygen = maxOxygen;
                // Logic for breathing out
                animator.SetTrigger("Exhale");
            }
            isInhaling = !isInhaling; // Toggle the breathing direction
        }
    }

    public void OnDiaphragmControlStart()
    {
        // Player starts controlling the diaphragm
        isHolding = true;
        breathTimer = 0;
        animator.SetTrigger("HoldBreath");
    }

    public void OnDiaphragmControlEnd()
    {
        // Player releases the diaphragm
        if (isHolding)
        {
            isHolding = false;
            breathTimer = 0;
            animator.SetTrigger("Exhale");
        }
    }
}
