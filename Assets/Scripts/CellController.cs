using System;
using UnityEngine;

public class CellController : MonoBehaviour
{

    private GameObject emptyCell;

    public bool isOnCorrectPosition;

    public Vector2 correctPosition;

    private bool isDemoMode;

    void Start()
    {
        emptyCell = GameObject.FindGameObjectWithTag("Placeholder");

        isDemoMode = FindObjectOfType<GameMaster>().isDemoMode;
        if (isDemoMode)
        {
            isOnCorrectPosition = true;
        }
    }

    private void OnMouseDown()
    {
        if (CanMove())
        {
            Move();
        }
    }

    private bool CanMove()
    {
        Vector2 emptyPosition = emptyCell.transform.localPosition;
        Vector2 clickedPosition = transform.localPosition;

        float horizontalDistance = Mathf.Abs(emptyPosition.x - clickedPosition.x);
        float verticalDistance = Mathf.Abs(emptyPosition.y - clickedPosition.y);

        if (horizontalDistance >= 2f || verticalDistance >= 2f)
        {
            return false;
        }

        bool canMoveHorizontal = horizontalDistance == 1F;
        bool canMoveVertical = verticalDistance == 1F;

        if (canMoveHorizontal && canMoveVertical)
        {
            return false;
        }
        
        if (canMoveHorizontal || canMoveVertical)
        {
            return true;
        }

        return false;
    }

    private void Move()
    {
        Vector2 currentPosition = transform.position;

        transform.position = Vector2.Lerp(transform.position, emptyCell.transform.position, 10f);
        emptyCell.transform.position = Vector2.Lerp(emptyCell.transform.position, currentPosition, 10f);

        Vector2 currentLocalPosition = transform.localPosition;

        isOnCorrectPosition = currentLocalPosition == correctPosition;

        if (isDemoMode)
        {
            isOnCorrectPosition = true;
        }

        FindObjectOfType<GameMaster>().CheckGameFinished();
    }

}
