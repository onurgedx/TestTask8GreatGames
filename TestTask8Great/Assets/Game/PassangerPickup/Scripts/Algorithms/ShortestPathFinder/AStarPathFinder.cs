using Common.CellSys; 
using System.Collections.Generic;
using UnityEngine;
namespace PassengerPickup.Algorithms.PathFinder
{
    public class AStarPathFinder : IPathFinder
    { 
        public class Node
        {
            public CellPosition CellPosition;
            public int gCost;
            public int hCost;
            public int fCost;
            public Node NodeFromCame;
            public Node(CellPosition a_cellPosition)
            {
                CellPosition = a_cellPosition;
            }

            public void CalculateFCost()
            {
                fCost = gCost + hCost;
            }
        }

        private CellSystem _cellSystem;


        public AStarPathFinder(CellSystem a_cellSystem)
        {
            _cellSystem = a_cellSystem;
        }


        public Path FindPath(CellPosition a_startCellPosition, CellPosition a_destinationCellPosition)
        {

            if (_cellSystem.CellDictionary.TryGetValue(a_destinationCellPosition, out Cell a_cell))
            {
                if (!a_cell.CanOccupy())
                {
                    return null;
                }
                Node startNode;
                Node endNode;

                List<Node> allNodes = new List<Node>();
                List<Node> openList = new List<Node>();
                List<Node> closedList = new List<Node>();
                int xOffsett = _cellSystem.CellLayout.Axis1CellCount / 2;
                int yOffsett = _cellSystem.CellLayout.Axis2CellCount / 2;
                for (int i = 0; i < _cellSystem.CellLayout.Axis1CellCount; i++)
                {
                    for (int k = 0; k < _cellSystem.CellLayout.Axis2CellCount; k++)
                    {
                        CellPosition cellPos = new CellPosition(i - xOffsett, k - yOffsett);
                        Node node = new Node(cellPos);
                        node.gCost = int.MaxValue;
                        node.CalculateFCost();
                        node.NodeFromCame = null;
                        allNodes.Add(node);
                    }
                }

                startNode = GetNode(allNodes, a_startCellPosition);
                endNode = GetNode(allNodes, a_destinationCellPosition);
                startNode.gCost = 0;
                startNode.hCost = CalculateDistanceCost(startNode, endNode);
                startNode.CalculateFCost();
                openList.Add(startNode);

                while (openList.Count > 0)
                {
                    Node currentNode = GetLowestFCostNode(openList);
                    if (currentNode == endNode)
                    {
                        return CalculatePath(endNode);
                    }
                    openList.Remove(currentNode);
                    closedList.Add(currentNode);

                    List<Node> neighbourList = GetNeighbours(allNodes, currentNode );
                    foreach (Node neighbourNode in neighbourList)
                    {
                        if (closedList.Contains(neighbourNode)) continue;

                        int tentativeGCost = currentNode.gCost + CalculateDistanceCost(currentNode, neighbourNode);
                        if (tentativeGCost < neighbourNode.gCost)
                        {
                            neighbourNode.NodeFromCame = currentNode;
                            neighbourNode.gCost = tentativeGCost;
                            neighbourNode.hCost = CalculateDistanceCost(neighbourNode, endNode);
                            neighbourNode.CalculateFCost();

                            if (!openList.Contains(neighbourNode))
                            {
                                openList.Add(neighbourNode);
                            }
                        }
                    }
                }
                return null;
            }
            return null;
        }


        /// <summary>
        /// Returns Path acoording to end node where came from
        /// </summary>
        /// <param name="a_endNode"></param>
        /// <returns></returns>
        private Path CalculatePath(Node a_endNode)
        {
            List<CellPosition> pathList = new List<CellPosition>();
            Node currentNode = a_endNode;
            pathList.Add(currentNode.CellPosition);
            while (currentNode.NodeFromCame != null)
            {
                pathList.Add(currentNode.NodeFromCame.CellPosition);
                currentNode = currentNode.NodeFromCame;
            }
            pathList.Reverse();
            Path path = new Path(pathList);
            return path;
        }


        /// <summary>
        /// Return a List has given node's neighbour
        /// </summary>
        /// <param name="a_allNodeList"></param>
        /// <param name="a_currentNode"></param>
        /// <param name="a_occupier"></param>
        /// <returns></returns>
        private List<Node> GetNeighbours(List<Node> a_allNodeList, Node a_currentNode )
        {
            List<Node> nodeList = new();
            TryAddNeighbour(a_allNodeList, a_currentNode.CellPosition + CellPosition.Left , nodeList);
            TryAddNeighbour(a_allNodeList, a_currentNode.CellPosition + CellPosition.Right , nodeList);
            TryAddNeighbour(a_allNodeList, a_currentNode.CellPosition + CellPosition.Forward,  nodeList);
            TryAddNeighbour(a_allNodeList, a_currentNode.CellPosition + CellPosition.Back,  nodeList);
            return nodeList;
        }


        /// <summary>
        /// Try add a node to <paramref name="a_nodeList"/>  if it is propper to be occupied
        /// </summary>
        /// <param name="a_allNodeList"></param>
        /// <param name="a_neighbourCellPosition"></param>
        /// <param name="a_occupier"></param>
        /// <param name="a_nodeList"></param>
        private void TryAddNeighbour(List<Node> a_allNodeList, CellPosition a_neighbourCellPosition , List<Node> a_nodeList)
        {
            if (_cellSystem.IsCellPropperToOccupy(a_neighbourCellPosition ))
            {
                a_nodeList.Add(GetNode(a_allNodeList, a_neighbourCellPosition));
            }
        }


        /// <summary>
        /// Returns distance between two given nodes
        /// </summary>
        /// <param name="a_node1"></param>
        /// <param name="a_node2"></param>
        /// <returns></returns>
        private int CalculateDistanceCost(Node a_node1, Node a_node2)
        {
            CellPosition diffCellPosition = (a_node1.CellPosition - a_node2.CellPosition);
            return Mathf.Abs(diffCellPosition.XPosition) + Mathf.Abs(diffCellPosition.YPosition);
        }


        /// <summary>
        /// Returns a node which has lowestFCost value in <paramref name="a_nodeList"/> list
        /// </summary>
        /// <param name="a_nodeList"></param>
        /// <returns></returns>
        private Node GetLowestFCostNode(List<Node> a_nodeList)
        {
            Node lowestFCostNode = a_nodeList[0];
            for (int i = 0; i < a_nodeList.Count; i++)
            {
                if (a_nodeList[i].fCost < lowestFCostNode.fCost)
                {
                    lowestFCostNode = a_nodeList[i];
                }
            }
            return lowestFCostNode;
        }


        /// <summary>
        /// Returns a node in <paramref name="a_nodeList"/> list according to <paramref name="a_cellPosition"/>
        /// </summary>
        /// <param name="a_nodeList"></param>
        /// <param name="a_cellPosition"></param>
        /// <returns></returns>
        private Node GetNode(List<Node> a_nodeList, CellPosition a_cellPosition)
        {
            foreach (Node node in a_nodeList)
            {
                if (node.CellPosition == a_cellPosition)
                {
                    return node;
                }
            }
            return null;
        }

    }
}