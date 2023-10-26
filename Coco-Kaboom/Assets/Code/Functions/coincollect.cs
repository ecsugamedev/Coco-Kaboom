using UnityEngine;
using UnityEngine.UI;


public class coincollect : MonoBehaviour
{
    public Text coinText;
    public int coinCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = ""+coinCount.ToString();
    }
}
