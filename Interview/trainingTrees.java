import java.awt.List;
import java.util.Queue;
import java.util.Random;
import java.util.LinkedList;

public class trainingTrees
{
    public static void main(String[] args)
    {
        System.out.println("Start training");
        Random random = new Random();

        //tree shit
        System.out.println("tree shit");
        System.out.println("Level BF");
        Tree arbol =  new Tree();
        for (int i = 0; i < 15; i++) {
            //arbol.insertBalanced(random.nextInt(100)); 
            arbol.insertBalanced(i);
        } 
        System.out.println(arbol.printTreeBF());

        System.out.println("DF Printing (pre order)");
        System.out.println(arbol.printTreeDF(0));
        System.out.println("DF Printing(in order)");
        System.out.println(arbol.printTreeDF(1));
        System.out.println("DF Printing(post order)");
        System.out.println(arbol.printTreeDF(2));
        

        System.out.println();
        System.out.println();
        System.out.println("Binary Search tree shit");
        //binary search tree shit
        Tree bsArbol =  new Tree();
        for (int i = 0; i < 15; i++) { 
            int value = random.nextInt(100);
            System.out.print("["+value+"]");
            bsArbol.bsInsert(value);
        } 
        System.out.println();
        System.out.println(bsArbol.printTreeBF());
        System.out.println("DF Printing(post order)");
        System.out.println(bsArbol.printTreeDF(2));
        
        //AVL trees
        System.out.println("AVL tree shit");
        Tree AVLArbol = new Tree();
    }
    public static class Tree
    {
        Node root;
        public Tree()
        {
            root = null;
        } 
        public boolean isEmpty()
        {
            if (root == null)
                return true;
            return false;
        }
        public void insertBalanced(int data)
        {
            //O(c)
            if (isEmpty())
            {
                root = new Node(data);
                return;
            }
            //O(h)
            root.insertBalanced(data);
        }
        public void bsInsert(int data)
        {
            //O(c)
            if (isEmpty())
            {
                root = new Node(data);
                root.weight = 0;
                return;
            }
            Node cursor = root;
            //O(log(n))
            int level = 1;
            while(true)
            {
                if(data <= cursor.data)
                {
                   if(cursor.left == null)
                   {
                       cursor.left = new Node(data); 
                       cursor.left.weight = level;
                       return;
                   }
                    else
                        cursor = cursor.left;
                   
                }
                else
                {
                   if(cursor.right == null)
                   {
                       cursor.right = new Node(data); 
                       cursor.right.weight = level;
                       return;
                   }
                    else
                        cursor = cursor.right;
                   
                }
                level++;
            }
        }
        public String printTreeBF()
        {
            //space O((n/2)) - > O(n)
            Queue <Node> bfq = new LinkedList<Node>();
            String toRe = "";
            if(isEmpty())
                return "Empty Tree";
            bfq.add(root);
            //rt: O(n)
            while(!bfq.isEmpty())
            {
                Node cn =  bfq.remove();
                if(cn.left != null)
                    bfq.add(cn.left);
                if(cn.right != null)
                    bfq.add(cn.right);
                toRe += cn.toString();
            }         

            return toRe;
        }

        //mode 0 perorder
        //mode 1 inorder
        //mode 2 postorder
        public String printTreeDF(int mode)
        {
            String toRe = "";
            if(isEmpty())
                return "Empty Tree";
            toRe += dfPrint(root, mode);
            
            return toRe;
        }
        public String dfPrint(Node node, int mode)
        {
            String toRe = "";
            if(mode == 0)
                toRe += node.toString();
            if(node.left != null)
            {
                toRe += dfPrint(node.left, mode);
            }
            if(mode == 1)
                toRe += node.toString();
            if(node.right != null)
            {
                toRe += dfPrint(node.right, mode);
            }
            if(mode == 2)
                toRe += node.toString();
            return toRe;
        }

        //AVL tree shit
        public void insertAVL(int datat)
        {
             //O(c)
             if (isEmpty())
             {
                 root = new Node(datat);
                 root.weight = 0;
                 return;
             }

             
        }
    }
    public static class Node
    {
        int data;
        Node left;
        Node right;
        int weight;

        //AVL shit
        int balance;

        public Node(int datat)
        {
            data = datat;
            left = null;
            right = null;
            weight = 1;
            //balance shit
            balance = 0;
            // 0 is balanced
            // 1 is left heavy
            // -1 is right heavy
        }
        public int getNodeStatus()
        {
            if(left == null && right == null)
                return 0;
            if(left != null && right != null)
                return 1;
            if(left == null)
                return 2;
            return 3;
        }
        public void insertBalanced(int datat)
        {
            switch (getNodeStatus())
            {
                case 0:
                //favor left
                left =  new Node(datat);
                break;
                case 1:
                if(left.weight <= right.weight)
                {
                    left.insertBalanced(datat);
                }
                else
                {
                    right.insertBalanced(datat);
                }
                break;
                case 2:
                left =  new Node(datat);
                break;
                default:
                right =  new Node(datat);
                break;
            }
            weight++;
        }
        public String toString()
        {
            return "[" + data + ":" + weight + "]";
        }
    }
}