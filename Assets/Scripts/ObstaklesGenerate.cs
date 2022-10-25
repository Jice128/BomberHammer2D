using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
// guthub rep https://github.com/Jice128/BomberHammer2D.git

public class ObstaklesGenerate : MonoBehaviour
{
   // [SerializeField]
 //   public GameObject[] obstacles;
 
    // float[,] TotalGrid;

    [SerializeField]
    private int numberOfObstaklesTopLine;   //�� 0 �� 16  ��������. ����� 17 ������� ������� 0
    [SerializeField]
    private int numberOfObstaklesMidLN;
    [SerializeField]
    private int numberOfObstaklesDownLN;
    // 40   5  8
    [SerializeField]
    private int numberOfCoinsFireBoosters;
    [SerializeField]
    private int numberOfCoinsBombBoosters;
    public Tilemap tile_mapForGenerate;
    public Tile DestructableBOXTile;
    public GameObject Coin;
    public GameObject BombBooster;
    private List<Vector3Int> CoordinatesForCoinsGenerate = new List<Vector3Int>();
    //   public RuleTile



    void Start() 
    {

       // Vector3Int someVector = new Vector3Int(-8, 0, 0); // ������� ���� � 0.1
         // GenerateBoxes(someVector);
        GenerateStartBoxes();



    }

    void GenerateStartBoxes()
    {
        ObstaklesGenerateFunctionTopLine(numberOfObstaklesTopLine);
        ObstaklesGenerateFunctionMidLn(numberOfObstaklesMidLN);
        ObstaklesGenerateFunctionDownLn(numberOfObstaklesDownLN);
        ObstaklesGenerateFunctionBetweenLn();
        CoinsGenerateFunction();




    }
   /* void GenerateBoxes(Vector3Int cellBox)   //������ ������ �������� ��������� ���� �� ����� �����
    {
        //  Tile tileToGenerate = tile_mapForGenerate.GetTile<Tile>(cellBox);
     //   tile_mapForGenerate.SetTile(cellBox, Coin);

        if (tile_mapForGenerate.GetTile(cellBox))
        {
            Debug.Log("tile is exist here");
            tile_mapForGenerate.SetTile(new Vector3Int((cellBox.x + 1), cellBox.y, cellBox.z), DestructableBOXTile);
        }

    }*/

    /*void GenetareBoxes_New()
    {
      
        gridForObstaclesTopLine = new int[17, 2]  { { -8, 3 } ,   //������� ���
                                             { -7, 3 } ,
                                             { -6, 3 } ,
                                             { -5, 3 },
                                             { -4, 3 },
                                             { -3, 3 },
                                             { -2, 3 },
                                             { -1, 3 },
                                             {  0, 3 },
                                             {  1, 3 },
                                             {  2, 3 },
                                             {  3, 3 },
                                             {  4, 3 },
                                             {  5, 3 },
                                             {  6, 3 },
                                             {  7, 3 },
                                             {  8, 3 },
                                         };

        

          gridForObstaclesMidLine = new float[14, 2] { {-10f,3f } ,  // ����� ������
                                                     {-6f,3f } ,
                                                     {-2f,3f } ,
                                                     { 2f,3f } ,
                                                     {-8,1f } ,
                                                     {-5f,1f } ,
                                                     { 0f,1f } ,
                                                     {-10f,-1f } ,
                                                     {-6f,-1f } ,
                                                     { -2f,-1f } ,
                                                     { 2f,-1f } ,
                                                     { -8f,-3f } ,
                                                     { -4f,-3f } ,
                                                     { -0f,-3f } ,
    };
        gridForObstaclesDownLine = new float[11, 2] { {-9f, -4f } ,
                                                  { -8f, -4f},
                                                  { -7f, -4f},
                                                  { -6f, -4f},
                                                  { -5f, -4f},
                                                  { -4f, -4f},
                                                  { -3f, -4f},
                                                  { -2f, -4f},
                                                  { -1f, -4f},
                                                  { 0f, -4f},
                                                  { 1f, -4f},
        };

       
        // ObstaklesGenerateFunctionMidLn(numberOfObstaklesTopLineMidLN);
        //  ObstaklesGenerateFunctionDownLn(numberOfObstaklesTopLineDownLN);

        /* ����� ������� 2 �������. ���� ������ "����" �.� ���� ������ ����� �������
         ������ ������ ������ (��� ������)� �������������� ��������  - ������ ��� �������� ������ �� �������, ���� ����� ����� 0 (�.� 
        ������� ���� � ����� ��������, �� ��� ��������� "�����" � ���� �� ������� �����������
        ��� ��� ����� ���� ���, ���� �� � �������� �����, ������� ����� ������ � ������������ � ���� ������, � �
        ������������� ����� ����� ����� ��������

         ���� ��� �������� ���� �����, ���� ���������� ����������� � ����� �������� ���� ��� � ����� ������ �����
    } */


    void Update()
    {

    }

    void ObstaklesGenerateFunctionTopLine(int numberOfBoxes)
    {
        List<int> CoordinatesForTopLineX = new List<int>() { -8, -7, -6, -5, -4, -3, -2, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8 };
        List<int> CoordinatesForTopLineY = new List<int>() { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 };
        //������������ ���������� ������ 17

        int RandomX;

        for (int i = 0; i <= numberOfBoxes; i++)
        {

            RandomX = Random.Range(0, CoordinatesForTopLineX.Count);
            Vector3Int positionToGenerate = new Vector3Int(CoordinatesForTopLineX[RandomX], CoordinatesForTopLineY[RandomX], 0);
            tile_mapForGenerate.SetTile(positionToGenerate, DestructableBOXTile);
            CoordinatesForCoinsGenerate.Add(positionToGenerate);
            CoordinatesForTopLineX.RemoveAt(RandomX);
            CoordinatesForTopLineY.RemoveAt(RandomX);

        }


    }



    void ObstaklesGenerateFunctionMidLn(int numberOfBoxes)
    {
        List<int> CoordinatesForMidLineX = new List<int>() { -8, -7, -6, -5, -4, -3, -2, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, -7, -6, -5, -4, -3, -2, -1, 0, 1, 2, 3, 4, 5, 6, 7 };
        List<int> CoordinatesForMidLineY = new List<int>() { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
        //�������� 32 �����

        int RandomXMid;
     
     
        for (int i = 1; i <= numberOfBoxes; i++)
        {

            RandomXMid = Random.Range(0, CoordinatesForMidLineX.Count);
            Vector3Int positionToGenerate = new Vector3Int(CoordinatesForMidLineX[RandomXMid], CoordinatesForMidLineY[RandomXMid], 0);
            tile_mapForGenerate.SetTile(positionToGenerate, DestructableBOXTile);
            CoordinatesForCoinsGenerate.Add(positionToGenerate);
         //  Debug.Log("������ ���������� ����� " + positionToGenerate);
         //  Debug.Log("������ ��������� ������ " +  (CoordinatesForCoinsGenerate[CoordinatesForCoinsGenerate.Count -1]));
            CoordinatesForMidLineX.RemoveAt(RandomXMid);
            CoordinatesForMidLineY.RemoveAt(RandomXMid);

        }


            if (tile_mapForGenerate.GetTile(new Vector3Int(-8, 1, 0)) || tile_mapForGenerate.GetTile(new Vector3Int(-7,-1,0)))
            {  // ��������  ��� �� ����� �� ��������� ������ ������� ��� ������.
            int RandomVariant = Random.Range(0, 10);
            if (RandomVariant < 5)
                tile_mapForGenerate.SetTile(new Vector3Int(-8, 1, 0), null);
               else {
                tile_mapForGenerate.SetTile(new Vector3Int(-7, -1, 0), null);
                tile_mapForGenerate.SetTile(new Vector3Int(-6, -1, 0), null);
               }
         
            }

        if (tile_mapForGenerate.GetTile(new Vector3Int(8,1,0)) || tile_mapForGenerate.GetTile(new Vector3Int(7,-1,0)))

        { //��� �� ������ ����� �� ��� "������ � ������" 
            int RandomVarian = Random.Range(0, 10);
            if (RandomVarian < 5)
                tile_mapForGenerate.SetTile(new Vector3Int(8, 1, 0), null);
            else
            {
                tile_mapForGenerate.SetTile(new Vector3Int(7, -1, 0), null);
                tile_mapForGenerate.SetTile(new Vector3Int(6, -1, 0), null);
            }


        }

    }
    void ObstaklesGenerateFunctionDownLn(int numberOfBoxes)
    {
        List<int> CoordinatesForDownLineX = new List<int>() { -8, -7, -6, -5, -4, -3, -2, -1,  0,  1,  2,  3,  4,  5,  6,  7,  8, -8, -7, -6, -5, -4, -3, -2, -1, 0,   1,  2,  3,  4, 5,   6,  7,  8 };
        List<int> CoordinatesForDownLineY = new List<int>() { -3, -3, -3, -3, -3, -3, -3, -3, -3, -3, -3, -3, -3, -3, -3, -3, -3, -5, -5, -5, -5, -5, -5, -5, -5, -5, -5, -5, -5, -5, -5, -5, -5, -5 };
        //�������� 34 �����

      
        int RandomXDown;
        for (int i = 0; i <= numberOfBoxes; i++)
        {
            RandomXDown = Random.Range(0, CoordinatesForDownLineX.Count);
            Vector3Int positionToGenerate = new Vector3Int(CoordinatesForDownLineX[RandomXDown], CoordinatesForDownLineY[RandomXDown], 0);
            tile_mapForGenerate.SetTile(positionToGenerate, DestructableBOXTile);
            CoordinatesForCoinsGenerate.Add(positionToGenerate);
            CoordinatesForDownLineX.RemoveAt(RandomXDown);
            CoordinatesForDownLineY.RemoveAt(RandomXDown);
            
        }

    }

    void ObstaklesGenerateFunctionBetweenLn()
    {
       int  numberOfBoxes = 10;
        List<int> CoordinatesForBetwLineX = new List<int>() { -6, -2, 2, 6, -4, 0, 4, -6, -2,  2,  6, -8, -4,  0,  4,  8};
        List<int> CoordinatesForBetwLineY = new List<int>() {  2, -2, 2, 2,  0, 0, 0, -2, -2, -2, -2, -4, -4, -4, -4, -4};
        //�������� 16 ������ ����� ����

        int RandomXBetw;
        for (int i = 0; i <= numberOfBoxes; i++)
        {
            RandomXBetw = Random.Range(0, CoordinatesForBetwLineX.Count);
            Vector3Int positionToGenerate = new Vector3Int(CoordinatesForBetwLineX[RandomXBetw], CoordinatesForBetwLineY[RandomXBetw], 0);
            tile_mapForGenerate.SetTile(positionToGenerate, DestructableBOXTile);
            CoordinatesForCoinsGenerate.Add(positionToGenerate);
            CoordinatesForBetwLineX.RemoveAt(RandomXBetw);
            CoordinatesForBetwLineY.RemoveAt(RandomXBetw);
        }


    }

    void CoinsGenerateFunction()
    {
    
        int RandomCoinsIndex;
        // ������� "����������� �������" ��� ������������� �������,  ����� ���� � ������� �������� �������� � ������� ������, �� ��� �� � ���� ������ ������.
        CoordinatesForCoinsGenerate.Remove(new Vector3Int(-6, -1, 0));
        CoordinatesForCoinsGenerate.Remove(new Vector3Int(-8, 1, 0));
        CoordinatesForCoinsGenerate.Remove(new Vector3Int( 8, 1, 0));
        CoordinatesForCoinsGenerate.Remove(new Vector3Int(7, -1, 0));
        CoordinatesForCoinsGenerate.Remove(new Vector3Int(-7, -1, 0));
        CoordinatesForCoinsGenerate.Remove(new Vector3Int(6, -1, 0));
      
        for (int i = 1; i <= numberOfCoinsFireBoosters; i++)
        {    // ���������� ������� ������� ��� ���������� ����
            RandomCoinsIndex = Random.Range(0, CoordinatesForCoinsGenerate.Count);
            Vector3Int CoinPositionToGenerate = CoordinatesForCoinsGenerate[RandomCoinsIndex];
            Instantiate(Coin, CoinPositionToGenerate, Quaternion.identity);
            CoordinatesForCoinsGenerate.RemoveAt(RandomCoinsIndex);
        }

        for (int i = 1; i <= numberOfCoinsBombBoosters; i++)  // ���������� ������� ��� ���������� ���������� ����
        {
            RandomCoinsIndex = Random.Range(0, CoordinatesForCoinsGenerate.Count);
            Vector3Int CoinPositionToGenerate = CoordinatesForCoinsGenerate[RandomCoinsIndex];
            Instantiate(BombBooster, CoinPositionToGenerate, Quaternion.identity);
            CoordinatesForCoinsGenerate.RemoveAt(RandomCoinsIndex);
        }






    }

}
