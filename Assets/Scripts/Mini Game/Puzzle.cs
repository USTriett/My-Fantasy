using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Puzzle : MiniGame
{
    [SerializeField]
    private GameDataSO data;

    [SerializeField]
    private OnWinningEventSO _onWinningEventSO;

    [SerializeField]
    private OnOutOfStateEventSO _onOutOfStateEventSO;

    private GameObject[] quads;
    private GameObject[] cubes;
    private List<int> posPool;

    private int numberOfCubes;

    private PuzzleInput _puzzleInput;

    private bool _isNotify = false;

    private PuzzleInput _holdPuzzleInput;

    private void Start()
    {
        Initialize("Puzzle");
        InitPuzzleInput();
        GetAllQuads();
        LoadData();
        InitPuzzle();
        SortPosition();
    }

    private void OnEnable()
    {
        _onWinningEventSO.AddAction(BlockTouchPuzzle);
        _onOutOfStateEventSO.AddOnOutOfStateAction(StopPlay);
    }

    private void StopPlay()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        _onWinningEventSO.RemoveAction(BlockTouchPuzzle);
        _onOutOfStateEventSO.RemoveOutOfStateAction(StopPlay);
    }

    private void Update()
    {
        if (IsWinning() && !_isNotify)
        {
            NotifyWinning();
        }
    }

    private void NotifyWinning()
    {
        Debug.Log("Win puzzle");
        _onWinningEventSO.Notify();
        _isNotify = true;
    }

    private bool IsWinning()
    {
        if (IsRightOrder())
        {
            return true;
        }
        return false;
    }

    private bool IsRightOrder()
    {
        for (int i = 1; i < quads.Length; i++)
        {
            PuzzleBlock block = quads[i].GetComponent<PuzzleBlock>();
            if (block.Position != i)
            {
                return false;
            }
        }
        return true;
    }

    private void InitPuzzleInput()
    {
        _puzzleInput = new PuzzleInput();

        _puzzleInput.PuzzleBlock.Touch.performed += OnTouch;

        _puzzleInput.Enable();
    }

    private void BlockTouchPuzzle()
    {
        _puzzleInput.PuzzleBlock.Touch.performed -= OnTouch;

        _puzzleInput.Disable();
    }

    private void OnTouch(InputAction.CallbackContext context)
    {
        Vector2 touchPosition = context.ReadValue<Vector2>();
        Ray ray = Camera.main.ScreenPointToRay(touchPosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider != null && hit.collider.gameObject.name == "Quad")
            {
                var puzzleBlock = hit.collider.gameObject.GetComponent<PuzzleBlock>();
                puzzleBlock.Move();
            }
        }
    }

    private void InitPuzzle()
    {
        posPool = new List<int>();
        for (int i = 0; i < cubes.Length; i++)
        {
            posPool.Add(i);
        }
    }

    private void SortPosition()
    {
        int loopTimes = 0;
        int[] newPosistion = new int[9];

        while (true)
        {
            List<int> temp = new(posPool);
            for (int i = 0; i < numberOfCubes - 1; i++)
            {
                int index = Random.Range(1, temp.Count);
                int pos = temp[index];
                temp.RemoveAt(index);
                newPosistion[i + 1] = pos;
            }
            int inversion = CalculateInversions(newPosistion);

            //Case the game cannot solve
            if (inversion % 2 != 0) { }
            //Case the game can solve
            else
            {
                ChangeAllQuadsPosition(newPosistion);
                Debug.Log("Can solve " + loopTimes++);

                break;
            }
        }

        PuzzleBlock.EmptyBlock = quads[0].transform;
        PuzzleBlock.BlockEmptyPosition = 0;
        AddPuzzleBlock(quads[0], 0, 0);
    }

    private void ChangeAllQuadsPosition(int[] newPosistion)
    {
        for (int i = 1; i < newPosistion.Length; i++)
        {
            ChangeQuadsPosition(i, newPosistion[i] / data.size, newPosistion[i] % data.size);
            AddPuzzleBlock(quads[i], i, newPosistion[i]);
        }
    }

    private int CalculateInversions(int[] newPosistion)
    {
        int inversion = 0;
        for (int i = 1; i < newPosistion.Length - 1; i++)
        {
            for (int j = i + 1; j < newPosistion.Length; j++)
            {
                if (newPosistion[i] > newPosistion[j])
                {
                    inversion += 1;
                }
            }
        }
        return inversion;
    }

    private void ChangeQuadsPosition(int i, int row, int col)
    {
        Vector3 currentPos = cubes[i].transform.localPosition;
        // Debug.Log("current " + currentPos);
        cubes[i].transform.localPosition = new Vector3(
            currentPos.x - col,
            currentPos.y + row,
            currentPos.z
        );
    }

    private void AddPuzzleBlock(GameObject gameObject, int originPos, int randPos)
    {
        var cpn = gameObject.AddComponent<PuzzleBlock>();
        cpn.Init(originPos, randPos);
    }

    private void GetAllQuads()
    {
        numberOfCubes = data.GetNumberOfBlock() + 1;
        quads = new GameObject[numberOfCubes];
        cubes = new GameObject[numberOfCubes];
        for (int i = 0; i < numberOfCubes; i++)
        {
            Transform child = transform.GetChild(i);
            cubes[i] = child.gameObject;
            Debug.Log(cubes[i].name);
            quads[i] = child.GetChild(0).gameObject;
        }
    }

    protected override void LoadData()
    {
        for (int i = 1; i <= data.GetNumberOfBlock(); i++)
        {
            quads[i].GetComponent<MeshRenderer>().material.mainTexture = data.GetImage(i - 1);
        }
    }
}
