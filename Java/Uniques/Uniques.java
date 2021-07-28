import java.util.ArrayList;
import java.util.Collections;

public class Uniques
{
	public static void main(String[] args)
	{
		String[] names1 = new String[] {"James", "Corry", "Michael", "Obuno"};
		String[] names2 = new String[] {"James", "Diarno", "Namey", "Obuno", "Fred", "Ducky", "Frank"};
		
		allUniques(names1, names2).forEach(n -> System.out.print(n + " ")); 
	}
	
	public static ArrayList<String> allUniques(String[] array1, String[] array2)
	{
		ArrayList<String> uniques = new ArrayList<String>();
		
		for(String n : array1)
		{
			if (!uniques.contains(n))
			{
				uniques.add(n);
			}
		}
		
		for(String n : array2)
		{
			if (!uniques.contains(n))
			{
				uniques.add(n);
			}
		}
		
		Collections.sort(uniques);
		return uniques;
	}
}