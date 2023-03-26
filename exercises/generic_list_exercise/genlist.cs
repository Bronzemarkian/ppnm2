using static System.Console;

public class genlist<T>{

    public T[] data;
    public int size=0, capacity=8;
    public T this[int i] => data[i]; // our indexer in our list
    public genlist(){ data = new T[capacity];}
    public void add(T item){
        if (size == capacity){  // if our list is not big enough
            T[] newdata = new T[capacity*2];
            System.Array.Copy(data,newdata,size);
            data=newdata;
        }
        data[size] = item;
        size++; // add one to size
    }

    public void remove(int element){
        T[] newdata = new T[size-1];
        System.Array.Copy(data,newdata,element);
        System.Array.Copy(data, element+1, newdata, element, size-element-1);
        data=newdata;
        size--; // remove one from size
    }


}