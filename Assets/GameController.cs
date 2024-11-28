using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private Color[] colorPalette;
    [SerializeField] float difficultyModifier;
    [SerializeField][Range(2, 5)] private int blockCount = 2;
    [SerializeField] private BlockSpawner blockSpawner;
    [SerializeField] private int correctCount = 0;
    [SerializeField] private int unCorrectCount = 0;

    private List<Block> blockList = new List<Block>();

    private Color currentColor;
    private Color otherOneColor;

    private int otherBlcokIndex;

    public Text corretCountText;
    public Text unCorretCountText;

    private void Awake()
    {
        blockList = blockSpawner.SpawnBlocks(blockCount);
        for(int i = 0; i < blockList.Count; ++i)
        {
            blockList[i].Setup(this);
        }
        SetColors();
    }

    private void SetColors()
    {
        difficultyModifier *= 0.92f;

        currentColor = colorPalette[Random.Range(0, colorPalette.Length)];

        float diff = (1.0f / 255.0f) * difficultyModifier;
        otherOneColor = new Color(currentColor.r - diff, currentColor.g - diff, currentColor.b - diff);

        otherBlcokIndex = Random.Range(0, blockList.Count);
        Debug.Log(otherBlcokIndex);

        for(int i = 0; i < blockList.Count; ++i)
        {
            if( i == otherBlcokIndex)
            {
                blockList[i].Color = otherOneColor;
            }
            else
            {
                blockList[i].Color = currentColor;
            }
        }
    }

    public void CheckBlock(Color color)
    {
        //색상이 다른 하나의 블록과 매개변수 color의 색상이 같으면
        //플레이어가 선택한 블록이 정답 블록 = 정답
        if (blockList[otherBlcokIndex].Color == color)
        {
            //색상 재 선택
            SetColors();
            correctCount++;
            corretCountText.text = "정답 : " + correctCount.ToString();
        }
        else
        {
            unCorrectCount++;
            unCorretCountText.text = "오답 : " + unCorrectCount.ToString();
        }
    }
}
