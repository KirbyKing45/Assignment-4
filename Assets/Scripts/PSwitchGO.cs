using JetBrains.Annotations;
using UnityEngine;

public class PSwitchGO : MonoBehaviour
{

    public BreakableBlock BB;
    public CoinPickup MyCoin;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isTimerRunning = false;
        currentTime = 10.0f;
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
                SwitchBlocksAndConis();
            }
        }
      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Mario"))
        {
            SwitchBlocksAndConis();
            isTimerRunning = true;
        }
    }

    public class SwitchTimer : MonoBehaviour
    {
        private bool isTimerRunning = false;
        private float timeDuration = 10f;
        private float currentTime = 0.0f;


        
    }
    private void SwitchBlocksAndConis()
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
