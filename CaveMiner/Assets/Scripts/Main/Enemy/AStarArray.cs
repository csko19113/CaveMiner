using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

namespace Cave.Main.Enemy
{
    public class node
    {
        public enum status
        {
            none,
            open,
            closed
        }
        public int type { get; set; }//Map�̃f�[�^�̎��
        public Vector3 pos { get; set; }//���g�̈ʒu
        public float cost { get; set; }//�ړ��R�X�g
        public float heurisitic { get; set; }//����R�X�g
        public float sumCost { get; set; }//�R�X�g�̘a
        public Vector3 parent { get; set; }//�e�m�[�h�̈ʒu
        public status isOpen { get; set; }//�K��ς݂̃t���O
    }

    //�eenemy�ɃA�^�b�`����
    public class AStarArray : MonoBehaviour
    {
        [SerializeField] private BoardData boardData;

        private bool endFlag = false;
        //�ȈՓI�ȃ}�b�v  1:�� 0:�� 5:�X�^�[�g 6:�S�[��

        /*
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
        */

        public int[,] Map;

        private Vector3 target;//ToDO:player������������position����,���I�ɕω�����̂ňړ������̓x�ɍX�V

        [SerializeField] List<node> nodes;
        [SerializeField] List<node> routeNodes;
        List<Vector3> routeList = new List<Vector3>();
        node StartNode = new node();
        node GoalNode = new node();
        //Map�̏���ǂݎ��A�œK�ȃ��[�g�̌���
        public void SearchRoad()
        {
            nodes = new List<node>();//�o�H�̒T���p���X�g
            routeNodes = new List<node>();//�m�[�h�̕ۊǗp���X�g
            target = GameObject.FindWithTag("Player").transform.position;//
            NodeSet(boardData.BoardWidth, boardData.BoardHeight);//�S�[���m�[�h�̐ݒ�A�S�Ẵm�[�h�̏���ݒ�
            SearchStart();//�ŏ��̃m�[�h��ݒ�
            Open(StartNode);
            OutputRoute();
        }
        //Map�̍X�V
        public void InputBoard()
        {
            Map = boardData.Board;
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


                    if (Node.type != 0) //�m�[�h����Q���̏ꍇ�͖���
                    {
                        //Instantiate(block, Node.pos, Quaternion.identity);
                        continue;
                    }


                    //                Node.pos = new Vector3(x, y, 0);
                    Node.isOpen = node.status.none;
                    routeNodes.Add(Node);

                    //Instantiate(road, Node.pos, Quaternion.identity);

                    /*
                    if (Node.type == 6)//�m�[�h���S�[���̎��S�[���m�[�h�Ƀf�[�^����
                    {
                        GoalNode = Node;
                        //Instantiate(goal, GoalNode.pos, Quaternion.identity);
                        Debug.Log("GoalNode��" + GoalNode.pos);
                    }
                    */
                    //goalNode���v���C���[�̈ʒu����ݒ�
                    if (Node.pos == target)//�m�[�h���S�[���̎��S�[���m�[�h�Ƀf�[�^����
                    {
                        GoalNode = Node;
                        Debug.Log("GoalNode��" + GoalNode.pos);
                    }
                }
            }
        }

        private void SearchStart()
        {
            //�X�^�[�g�m�[�h������
            //StartNode = routeNodes.First(n => n.type == 5);
            StartNode = routeNodes.First(n => n.pos == gameObject.transform.position);//

            StartNode.cost = 0;
            StartNode.isOpen = node.status.open;
            nodes.Add(StartNode);
            //Instantiate(start, StartNode.pos, Quaternion.identity);
            Debug.Log("StartNode��" + StartNode.pos);
        }

        private void Open(node centerNode)
        {
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if ((i != 0 || j != 0) && (i == 0 || j == 0))//�΂߂͎Q�Ƃ��Ȃ�
                    {
                        Vector3 pos = new Vector3(centerNode.pos.x + i, centerNode.pos.y + j, centerNode.pos.z);
                        //�Q�Ɛ�̃m�[�h�����łɎQ�ƍς݁AMap�͈͓̔��̃m�[�h�łȂ��ꍇ
                        if (nodes.Any(n => n.pos == pos) || !routeNodes.Any(n => n.pos == pos))
                        {
                            continue;
                        }
                        //�m�[�h�̐���A���X�g�ւ̕ۑ�
                        node node = routeNodes.Where(n => n.pos == pos).First();//�����ƈ�v����m�[�h�̎��o��
                                                                                //node node = routeNodes.FirstOrDefault(n => n.pos == pos);
                        node.cost = centerNode.cost++;
                        node.heurisitic = Math.Abs(GoalNode.pos.x - node.pos.x) + Math.Abs(GoalNode.pos.y - node.pos.y);//�K�؂ȃq���[���X�e�B�b�N�̐ݒ�
                        node.sumCost = node.cost + node.heurisitic;
                        node.parent = centerNode.pos;
                        node.isOpen = node.status.open;//�I�[�v���ς�
                                                       //�Ō�Ɍo�H�p�̃��X�g�ɑ��
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
            //node���X�g���̎��R�X�g���ŏ��̃m�[�h�ōĂю�����I�[�v��
            Open(newcenterNode);
        }
        private void GoalCheck(node node)
        {
            //�S�[���ɓ͂��ĂȂ��ꍇ�͏I��
            if (node.pos != GoalNode.pos) return;

            while (node.pos != StartNode.pos)//�e�m�[�h�̏o��
            {
                routeList.Add(node.pos);//�S�[�����珇�Ƀ��X�g�ɒǉ�
                node = nodes.First(n => n.pos == node.parent);//node��e�m�[�h�ɏ㏑��
            }
            endFlag = true;
        }
        private void OutputRoute()
        {
            routeList.Reverse();
            //routeList.ForEach(n => Debug.Log("=>" + n));
            float x = routeList[0].x - StartNode.pos.x;
            float y = routeList[0].y - StartNode.pos.y;
        }
    }
}