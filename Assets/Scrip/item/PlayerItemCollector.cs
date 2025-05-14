using UnityEngine;
using TMPro;

public class PlayerItemCollector : MonoBehaviour
{
    public TextMeshProUGUI scoreTextdiamond;
    public TextMeshProUGUI scoreTextcherry;

    private int scorediamond = 0;
    private int scorecherry = 0;

    private void Start()
    {
        UpdateScoreText();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Diamond"))
        {
            Destroy(other.gameObject);
            scorediamond += 50;
            UpdateScoreText();
        }
        else if (other.CompareTag("cherry"))
        {
            Destroy(other.gameObject);
            scorecherry += 1;
            UpdateScoreText();
        }
    }

    private void UpdateScoreText()
    {
        scoreTextdiamond.text = " " + scorediamond.ToString();
        scoreTextcherry.text = " " + scorecherry.ToString();
    }

    public int GetCherryCount()
    {
        return scorecherry;
    }

    public void UseCherry()
    {
        if (scorecherry > 0)
        {
            scorecherry--;
            UpdateScoreText();
        }
    }
}
