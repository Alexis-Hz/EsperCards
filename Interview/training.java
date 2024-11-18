import java.awt.List;
import java.util.Random;

public class training
{
    public static void main(String[] args)
    {
        System.out.println("Start training");
        Random random = new Random();

        System.out.println("Array stuff");
        //create random array
        int [] array = new int[10];
        for (int i = 0; i < array.length; i++) {
            array[i] = random.nextInt(100); 
        }

        //print random array
        for (int n : array) {
            System.out.println(n);
        }

        System.out.println("Linked List stuff");
        System.out.println("");
        //create random Linked List
        Linked list = new Linked();
        list.instertEnd(random.nextInt(100));
        for (int i = 0; i < 10; i++) {
            list.insertFront(random.nextInt(100)); 
        }
        
        //print Linked list
        System.out.println(list.toString());

        list.instertEnd(random.nextInt(100));
        System.out.println(list.toString());

        System.out.println("Stack stuff");
        //stack shit now
        Linked stack = new Linked();
        for (int i = 0; i < 10; i++) {
            //stack.push(random.nextInt(100)); 
            stack.push(i); 
        }
        System.out.println(stack.toString());
        while(!stack.isEmpty())
        {
            System.out.println(stack.pop());
        }

        //queue shit now
        System.out.println("Queue stuff");
        Linked queue = new Linked();
        for (int i = 0; i < 10; i++) {
            queue.enqueue(i); 
        }
        System.out.println(queue.toString());
        while(!queue.isEmpty())
        {
            System.out.println(queue.dequeue());
        }
    }
    public static class Linked
    {
        Node root;
        public Linked()
        {
            root = null;
        }
        public void insertFront(int data)
        {
            root = new Node(data, root);
        }
        public boolean isEmpty()
        {
            if(root == null)
                return true;
            return false;
        }
        public void instertEnd(int data)
        {
            Node iterator = root;
            if(iterator == null)
            {
                root = new Node(data, null);
                return;
            }
            while(iterator != null && iterator.next != null)
            {
                iterator = iterator.next;
            }
            iterator.next = new Node(data, null);
        }
        public String toString()
        {
            String toRe = "";
            Node iterator = root;
            while(iterator != null)
            {
                toRe += iterator.data + "\n";
                iterator = iterator.next;
            }
            return toRe;
        }
        //stack functions
        public void push(int data)
        {
            root = new Node(data, root);
        }
        public int pop()
        {
            int dataToRe =  root.data;
            root = root.next;
            return dataToRe;
        }

        //queue functions
        //reverse from stack for ease of removal
        public void enqueue(int data)
        {
            instertEnd(data);
        }
        public int dequeue()
        {
            return pop();
        }
    }
    public static class Node
    {
        int data;
        Node next;
        public Node(int datap, Node nextp)
        {
            data = datap;
            next = nextp;
        }
    }
}