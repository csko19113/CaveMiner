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

    public class AStar : MonoBehaviour
    {
        [SerializeField] private BoardData boardData;

        private bool endFlag = false;

        public int[,] Map;

        public int xDir { get; private set; }
        public int yDir { get; private set; }
        private Vector3 target;

        [SerializeField] List<node> nodes;
        [SerializeField] List<node> routeNodes;
        [SerializeField] List<Vector3> routeList;
        node StartNode = new node();
        node GoalNode = new node();

        //Map�̏���ǂݎ��A�œK�ȃ��[�g�̌���
        public void SearchRoad()
        {
            Map = boardData.Board;//Map�̍X�V
            routeList = new List<Vector3>();//�ŒZ�o�H�̍��W��ۑ����郊�X�g
            nodes = new List<node>();//�o�H�̒T���p���X�g
            routeNodes = new List<node>();//�m�[�h�̕ۊǗp���X�g
            target = GameObject.FindWithTag("Player").transform.position;//
            NodeSet(boardData.BoardWidth, boardData.BoardHeight);//�S�[���m�[�h�̐ݒ�A�S�Ẵm�[�h�̏���ݒ�
            SearchStart();//�ŏ��̃m�[�h��ݒ�
            Open(StartNode);
            OutputRoute();
        }
        private void NodeSet(int mapWidth, int mapHeight)
        {
            //���g������ʒu�̃m�[�h���Z�b�g
            node selfNode = new node();
            selfNode.type = 0;
            selfNode.pos = gameObject.transform.position;
            selfNode.isOpen = node.status.none;
            routeNodes.Add(selfNode);

            for (int x = 0; x < mapWidth; x++)
            {
                for (int y = 0; y < mapHeight; y++)
                {
                    node Node = new node();
                    Node.type = Map[x, y];
                    Node.pos = new Vector3(x, y, 0);


                    if (Node.type == 1 || Node.type == 3) //�m�[�h����Q���̏ꍇ�͖���
                    {
                        Node.isOpen = node.status.none;
                        routeNodes.Add(Node);


                        //goalNode���v���C���[�̈ʒu����ݒ�
                        if (Node.pos == target)//�m�[�h���S�[���̎��S�[���m�[�h�Ƀf�[�^����
                        {
                            GoalNode = Node;
                        }
                    }
                }
            }
        }

        private void SearchStart()
        {
            //�X�^�[�g�m�[�h������
            StartNode = routeNodes.First(n => n.pos == gameObject.transform.position);

            StartNode.cost = 0;
            StartNode.isOpen = node.status.open;
            nodes.Add(StartNode);
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
            //���ݒn����S�[���܂ł��ǂ蒅���Ȃ���
            if (newcenterNode == null)
            {
                return;
            }

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
            if (routeList.Count == 0)
            {
                return;
            }
            routeList.Reverse();
            xDir = (int)(routeList[0].x - StartNode.pos.x);
            yDir = (int)(routeList[0].y - StartNode.pos.y);
            routeList.Clear();
            endFlag = false;
        }
    }
}