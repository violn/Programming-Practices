public class FizzBuzz 
{
    public static void main(String[] args) 
    {
        for(int x = 0; x < 101; x++)
        {
            if(x % 5 == 0 && x % 3 == 0)
            {
                System.out.println("FizzBuzz");
            }

            else if(x % 5 == 0)
            {
                System.out.println("Buzz");
            }

            else if(x % 3 == 0)
            {
                System.out.println("Fizz");
            }

            else System.out.println(x);
        }    
    }
}
