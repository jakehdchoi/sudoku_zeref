using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Vector3 _startPos;
    [SerializeField] private float _offsetX, _offsetY;
    [SerializeField] private SubGrid _subGridPrefab;
    [SerializeField] private TMP_Text _levelText;

    private bool hasGameFinished;
    private Cell[,] cells;
    private Cell selectedCell;

    private const int GRID_SIZE = 9;
    private const int SUBGRID_SIZE = 3;

    private void Start()
    {
        hasGameFinished = false;
        cells = new Cell[GRID_SIZE, GRID_SIZE];
        selectedCell = null;
        SpawnCells();
    }

    private void SpawnCells()
    {
        int[,] puzzleGrid = Generator.GeneratePuzzle(Generator.DifficultyLevel.EASY);

        for (int i = 0; i < GRID_SIZE; i++)
        {
            Vector3 spawnPos = _startPos + i % 3 * _offsetX * Vector3.right + i / 3 * _offsetY * Vector3.up;
            SubGrid subGrid = Instantiate(_subGridPrefab, spawnPos, Quaternion.identity);
            List<Cell> subGridCells = subGrid.cells;
            int startRow = (i / 3) * 3;
            int startCol = (i % 3) * 3;
            for (int j = 0; j < GRID_SIZE; j++)
            {
                subGridCells[j].Row = startRow + j / 3;
                subGridCells[j].Col = startCol + j % 3;
                int cellValue = puzzleGrid[subGridCells[j].Row, subGridCells[j].Col];
                subGridCells[j].Init(cellValue);
                cells[subGridCells[j].Row, subGridCells[j].Col] = subGridCells[j];
            }
        }
    }

}
