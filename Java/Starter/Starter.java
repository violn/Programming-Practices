import java.util.Arrays;
import java.util.HashSet;

public class Starter 
{
    public static int begins(String[] words, String first)
    {
        int num = 0;
        HashSet<String> u = new HashSet<String>(Arrays.asList(words));
        
        for (String string : u) 
        {
            if(string.startsWith(first))
            {
                num++;
            }
        }

        return num;
    }

    public static void main(String[] args) 
    {
        String[] words = new String[]{"people", "persons", "book", "year", "persons", "tape", "pecan", "people", "persons"};
        System.out.println(begins(words, "p"));
    }
}
