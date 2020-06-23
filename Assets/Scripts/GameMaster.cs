using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{

    public Color[] colors = new Color[8];

    public Vector2[] correctPositions = new Vector2[8];

    public Text winText;

    public Button playAgainButton;

    //For test porpouses
    public bool isDemoMode = false;

    void Start()
    {
        DisableUi();
        FillGrid();
        TurnEmptyInvisible();
    }

    private void DisableUi()
    {
        winText.enabled = false;
        playAgainButton.enabled = false;
        playAgainButton.GetComponent<Image>().enabled = false;
        playAgainButton.GetComponentInChildren<Text>().enabled = false;
    }

    private void EnableUi()
    {
        winText.enabled = true;
        playAgainButton.enabled = true;
        playAgainButton.GetComponent<Image>().enabled = true;
        playAgainButton.GetComponentInChildren<Text>().enabled = true;
    }

    private void FillGrid()
    {
        GameObject[] gm = GameObject.FindGameObjectsWithTag("Player").ToList().OrderBy(x => Random.value).ToArray();

        for (int index = 0; index < gm.Length; index++)
        {
            gm[index].GetComponent<SpriteRenderer>().color = colors[index];
            gm[index].GetComponent<CellController>().correctPosition = correctPositions[index];
        }

    }

    public void OnClick()
    {

    }

    private void TurnEmptyInvisible()
    {
        GameObject.FindGameObjectWithTag("Placeholder").GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
    }

    public void CheckGameFinished()
    {
        GameObject[] gm = GameObject.FindGameObjectsWithTag("Player");

        if (gm.All(cell => cell.GetComponent<CellController>().isOnCorrectPosition))
        {
            EnableUi();
        }
    }

}
