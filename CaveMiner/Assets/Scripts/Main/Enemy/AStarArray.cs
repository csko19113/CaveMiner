using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class node
{
    public enum status
    {
        none,
        open,
        closed
    }
    public int type { get; set; }//Mapのデータの種類
    public Vector3 pos { get; set; }//自身の位置
    public float cost { get; set; }//移動コスト
    public float heurisitic { get; set; }//推定コスト
    public float sumCost { get; set; }//コストの和
    public Vector3 parent { get; set; }//親ノードの位置
    public status isOpen { get; set; }//訪問済みのフラグ
}

public class AStarArray : MonoBehaviour
{
    private int mapWidth = 8;
    private int mapHeight = 8;

    private bool endFlag = false;
    //簡易的なマップ  1:壁 0:道 5:スタート 6:ゴール
    public int[,] Map = new int[8, 8] {
    {1,1,1,1,1,1,0,6 },
    {0,0,0,0,0,0,0,0 },
    {0,0,1,1,0,1,1,0 },
    {0,0,0,0,1,0,0,0 },
    {0,0,0,0,1,0,1,0 },
    {1,1,1,0,0,0,0,1 },
    {0,0,0,0,0,0,1,0 },
    {5,0,0,0,0,0,0,0 }
    };

    public GameObject start;
    public GameObject goal;
    public GameObject road;
    public GameObject block;

    [SerializeField] List<node> nodes;
    [SerializeField] List<node> routeNodes;
    List<Vector3> routeList = new List<Vector3>();
    node StartNode = new node();
    node GoalNode = new node();
    private void Start()
    {
        nodes = new List<node>();//経路の探索用リスト
        routeNodes = new List<node>();//ノードの保管用リスト
        NodeSet(mapWidth, mapHeight);//ゴールノードの設定、全てのノードの情報を設定
        SearchStart();//最初のノードを設定
        Open(StartNode);
        OutputRoute();
    }

    private void NodeSet(int mapWidth, int mapHeight)
    {
        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                node Node = new node();
                Node.type = Map[x, y];
                Node.pos = new Vector3(x, y, 0);
                if (Node.type == 1) //ノードが壁の場合は無視
                {
                    Instantiate(block, Node.pos, Quaternion.identity);
                    continue;
                }

//                Node.pos = new Vector3(x, y, 0);
                Node.isOpen = node.status.none;
                routeNodes.Add(Node);
                Instantiate(road, Node.pos, Quaternion.identity);

                if(Node.type == 6)//ノードがゴールの時ゴールノードにデータを代入
                {
                    GoalNode = Node;
                    Instantiate(goal, GoalNode.pos, Quaternion.identity);
                    Debug.Log("GoalNodeは" + GoalNode.pos);
                }
            }
        }
    }

    private void SearchStart()
    {
        //スタートノードを検索
        StartNode = routeNodes.First(n => n.type == 5);
        StartNode.cost = 0;
        StartNode.isOpen = node.status.open;
        nodes.Add(StartNode);
        Instantiate(start, StartNode.pos, Quaternion.identity);
        Debug.Log("StartNodeは" + StartNode.pos);
    }

    private void Open(node centerNode)
    {
        for(int i = -1; i <= 1; i++)
        {
            for(int j = -1; j <= 1; j++)
            {
                if((i != 0 || j != 0) && (i ==0 || j == 0))//斜めは参照しない
                {
                    Vector3 pos = new Vector3(centerNode.pos.x + i,centerNode.pos.y + j,centerNode.pos.z);
                    //参照先のノードがすでに参照済み、Mapの範囲内のノードでない場合
                    if (nodes.Any(n => n.pos == pos) || !routeNodes.Any(n => n.pos == pos))
                    {
                        continue;
                    }
                    //ノードの制作、リストへの保存
                    node node = routeNodes.Where(n => n.pos == pos).First();//条件と一致するノードの取り出し
                    //node node = routeNodes.FirstOrDefault(n => n.pos == pos);
                    node.cost = centerNode.cost++;
                    node.heurisitic = Math.Abs(GoalNode.pos.x - node.pos.x) + Math.Abs(GoalNode.pos.y - node.pos.y);//適切なヒューリスティックの設定
                    node.sumCost = node.cost + node.heurisitic;
                    node.parent = centerNode.pos;
                    node.isOpen = node.status.open;//オープン済み
                    //最後に経路用のリストに代入
                    nodes.Add(node);

                    GoalCheck(node);
                    if (endFlag)
                    {
                        return;
                    }
                    
                }
            }
        }
        node newcenterNode = nodes.Where(n => n.isOpen == node.status.open).OrderBy(n => n.sumCost).FirstOrDefault();
        newcenterNode.isOpen = node.status.closed;
        //nodeリスト内の実コストが最小のノードで再び周りをオープン
        Open(newcenterNode);
    }
    private void GoalCheck(node node)
    {
        //ゴールに届いてない場合は終了
        if (node.pos != GoalNode.pos) return;

        while(node.pos != StartNode.pos)//親ノードの出力
        {
            routeList.Add(node.pos);//ゴールから順にリストに追加
            node = nodes.First(n => n.pos == node.parent);//nodeを親ノードに上書き
        }
        endFlag = true;
    }
    private void OutputRoute()
    {
        routeList.Reverse();
        routeList.ForEach(n => Debug.Log("=>" + n));
    }
}
