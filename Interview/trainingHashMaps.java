import java.awt.List;
import java.util.Queue;
import java.util.Random;

import com.sun.org.apache.xalan.internal.xsltc.compiler.util.CompareGenerator;

import java.util.LinkedList;

public class trainingHashMaps
{
    public static void main(String[] args)
    {
        System.out.println("Start training");
        Random random = new Random();

        String[] words ={"cow", "nice", "boobs", "felt", "pelican", "terrarium", "constraint", "gallant"};

        HashTable hs = new HashTable(10);

        for (int i = 0; i < words.length; i++)
        {
            hs.insert(words[i], words[i]);
        }
        System.out.println(hs.toString());

        if(hs.getValue("cow"))
        {
            System.out.println("Found it :D");
        }
        else{
            System.out.println("no dice :(");
        }
    }
    public static class HashTable
    {
        LinkedList<Tuple> [] hashTable;
        int tableSize;

        public HashTable(int tableSizet)
        {
            //O(1)
            hashTable = new LinkedList[tableSizet];
            tableSize = tableSizet;
        }
        public int hashFunction(String key)
        {
            char fchar = key.charAt(0);
            int ikey = (Character.getNumericValue(fchar))% tableSize;
            return ikey;
        }
        public void insert(String key, String value)
        {
            int hash = hashFunction(key);
            if(hashTable[hash] == null)
            {
                hashTable[hash] = new LinkedList<Tuple>();
            }
            hashTable[hash].add(new Tuple(key, value));
        }
        public boolean getValue(String key)
        {
            int hash = hashFunction(key);
            if(hashTable[hash] != null)
            {
                if(hashTable[hash].contains(new Tuple(key, key)))
                {
                    return true;
                }
                return false;
            }
            return false;
        }
        public String toString()
        {
            String toRe = "";
            for(int i = 0; i < hashTable.length; i++)
            {
                if(hashTable[i] != null)
                {
                    toRe += hashTable[i].toString() + "\n";
                }
            }
            return toRe;
        }
    }
    public static class Tuple implements Comparable
    {
        String key;
        String value;
        public Tuple(String key, String value)
        {
            this.key = key;
            this.value = value;
        }
        public String toString()
        {
            return "["+key+"|"+value+"]";
        }

        public int compareTo(Object o)
        {
            Tuple tup = (Tuple)o;
;            if(tup.key.equalsIgnoreCase(this.key))
            {
                return 0;
            }
            return -1;
        }
    }
}