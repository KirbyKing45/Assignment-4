using JetBrains.Annotations;
using UnityEngine;

public class PSwitchGO : MonoBehaviour
{
    private Animator animator;
    public BreakableBlock BB;
    public CoinPickup MyCoin;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isTimerRunning = false;
        currentTime = 10.0f;
        animator = GetComponent<Animator>();
        animator.Play("PSwitchNotPressed");
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimerRunning)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0.0f)
            {
                isTimerRunning = false;
                SwitchBlocksAndCoins();
                animator.Play("PSwitchNotPressed");
                currentTime = 10.0f;
            }
        }
      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.CompareTag("Mario"))
        {
            if (!isTimerRunning)
            {
                SwitchBlocksAndCoins();
                isTimerRunning = true;
                animator.Play("PSwitchPressed");

            }
        }
    }
    public class SwitchTimer : MonoBehaviour
    {
        private bool isTimerRunning = false;
        private float timeDuration = 10f;
        private float currentTime = 0.0f;


        
    }
    private void SwitchBlocksAndCoins()
    {
        CoinPickup[] coinPickupObjects = FindObjectsByType<CoinPickup>();
        BreakableBlock[] blockObjects = FindObjectsByType<BreakableBlock>();
        foreach (CoinPickup Coin in coinPickupObjects)
        {
            Vector3 Position = Coin.transform.position;
            Destroy(Coin.gameObject);

            
            Instantiate(BB, Position, Quaternion.identity);
        }

        foreach (BreakableBlock Block in blockObjects)
        {
            Vector3 Position = Block.transform.position;
            Destroy(Block.gameObject);


            Instantiate(MyCoin, Position, Quaternion.identity);
        }

       
    }


    float currentTime;
    bool isTimerRunning;
}
