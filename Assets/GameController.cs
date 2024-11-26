using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Color[] colorPalette;
    [SerializeField] float difficultyModifier;
    [SerializeField][Range(2, 5)] private int blockCount = 2;
    [SerializeField] private BlockSpawner blockSpawner;

    private List<Block> blockList = new List<Block>();

    private Color currentColor;
    private Color otherOneColor;

    private int otherBlcokIndex;

    private void Awake()
    {
        blockList = blockSpawner.SpawnBlocks(blockCount);
    }

    private void Start()
    {
        SetColors();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetColors();
        }
    }

    private void SetColors()
    {
        Color currentColor = colorPalette[Random.Range(0, colorPalette.Length)];
        for(int i = 0; i < blockList.Count; ++i)
        {
            blockList[i].Color = currentColor;
        }
    }
}
