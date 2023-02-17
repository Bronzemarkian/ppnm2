public class genlist<T>{
    public T[] data;
    public int size => data.Length; // => means when going for size, get
    // data length
    public T this[int i] => data[i];
    // constructor:
    public genlist(){data = new T[0];}
    public void add(T item){
        T[] newdata = new T[size+1];
        System.Array.Copy(data,newdata,size);
        newdata[size] = item;
        data = newdata;
    }
}