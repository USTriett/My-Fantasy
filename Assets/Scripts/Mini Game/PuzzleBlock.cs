using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PuzzleBlock : MonoBehaviour
{
    private int _currentPosition;
    private int _originalPosition;

    [SerializeField]
    private static int _blockEmptyPosition;
    private static Transform _emptyBlock;

    public static Transform EmptyBlock
    {
        set => _emptyBlock = value;
    }

    public static int BlockEmptyPosition
    {
        set => _blockEmptyPosition = value;
    }

    public int Position => _currentPosition;

    private static Vector2 ParsePosition(int position)
    {
        return new Vector2(position / 3, position % 3);
    }

    public void Move()
    {
        // Debug.Log("Block " + _currentPosition + " Move");
        Debug.Log(
            "Block "
                + ParsePosition(_currentPosition)
                + " , Empty: "
                + ParsePosition(_blockEmptyPosition)
        );
        if (CanMove())
        {
            // Debug.Log("Move");
            MoveToEmpty();
        }
    }

    private void MoveToEmpty()
    {
        //Move real
        (_emptyBlock.position, transform.position) = (transform.position, _emptyBlock.position);

        //update matrix postion
        UpdatePostion();
    }

    private void UpdatePostion()
    {
        (_blockEmptyPosition, _currentPosition) = (_currentPosition, _blockEmptyPosition);
        _emptyBlock.gameObject.GetComponent<PuzzleBlock>()._currentPosition = _blockEmptyPosition;

        Debug.Log("Block empty pos after change: " + _blockEmptyPosition);
    }

    public bool CanMove()
    {
        Vector2 emptyBlockPosition = ParsePosition(_blockEmptyPosition);
        Vector2 currentPostion = ParsePosition(_currentPosition);
        if (emptyBlockPosition == currentPostion)
            return false;
        int[] check = { -1, 1 };

        for (int i = 0; i < 2; i++)
        {
            if (
                emptyBlockPosition.x + check[i] == currentPostion.x
                    && emptyBlockPosition.y == currentPostion.y
                || emptyBlockPosition.y + check[i] == currentPostion.y
                    && emptyBlockPosition.x == currentPostion.x
            )
            {
                return true;
            }
        }
        return false;
    }

    public void Init(int originalPosition, int currentPosition)
    {
        _originalPosition = originalPosition;
        _currentPosition = currentPosition;
    }
}
