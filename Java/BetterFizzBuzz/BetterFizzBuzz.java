import java.util.*;

public class BetterFizzBuzz 
{
    public static String createFizzBuzz(Hashtable<Integer, String> association, int compare)
    {
        String out = "";
        ArrayList<Integer> e = new ArrayList<>(association.keySet());

        for(int x = e.size() - 1; x >= 0; x--)
        {
            if(compare % e.get(x)== 0)
            {
                out += association.get(e.get(x));
            }
        }
        
        return out;
    }

    public static void main(String[] args) 
    {
        Hashtable<Integer, String> fizzbuzz = new Hashtable<>();
        fizzbuzz.put(5, "Buzz");
        fizzbuzz.put(3, "Fizz");
        fizzbuzz.put(7, "Bizz");
        
        for(int x = 1; x <= 210; x++)
        {
            System.out.println(createFizzBuzz(fizzbuzz, x) == "" ? x : createFizzBuzz(fizzbuzz, x));
        }
    }
}
