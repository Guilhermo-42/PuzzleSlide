using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{

    public Color[] colors = new Color[8];

    public Text winText;

    void Start()
    {
        winText.enabled = false;
        FillGrid();
        TurnEmptyInvisible();
    }

    private void FillGrid()
    {
        GameObject[] gm = GameObject.FindGameObjectsWithTag("Player").ToList().OrderBy(x => Random.value).ToArray();

        for (int index = 0; index < gm.Length; index++)
        {
            gm[index].GetComponent<SpriteRenderer>().color = colors[index];
            gm[index].GetComponent<CellController>().correctPosition = index;
        }

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
            winText.enabled = true;
        }
    }

}
