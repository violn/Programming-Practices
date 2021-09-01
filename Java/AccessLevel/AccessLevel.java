public class AccessLevel
{
    public static String canAccess(int[] rights, int minPermission)
    {
        String DorA = "";

        for (int i : rights) 
        {
            if(minPermission < i)
            {
                DorA += "A";
            }

            else DorA += "D";
        }

        return DorA;
    }

    public static void main(String[] args) 
    {
        int[] rights = new int[] {3, 24, 7, 90};
        System.out.println(canAccess(rights, 20));
    }
}
