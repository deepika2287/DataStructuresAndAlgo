using System.Text;

namespace LCNumStepsToReduceBinaryNumRepresantationToOne;

class Program
{
    static void Main(string[] args)
    {
        Program p = new Program();
        string s = "1101";//"111111111111111111111111111111111111111111";
        var res = p.NumSteps(s);
        Console.WriteLine(res);
    }
    public int NumSteps(string s) {
        int steps = 0;
        StringBuilder str = new StringBuilder(s);

        while(str.Length > 1)
        {
            if(str[str.Length-1] == '0')
            {
                //divide
                Divide(str);
            }
            else
            {
                //add
                AddOne(str);
            }
            steps++;
        }
        return steps;
    }
    private void Divide(StringBuilder str)
    {
        str.Remove(str.Length - 1, 1);
        
    }
    private void AddOne(StringBuilder str)
    {
        int i = str.Length - 1;

        while(i >= 0 && str[i] != '0')
        {
            str[i] = '0';
            i--;
        }

        if(i < 0)
        {
            str.Insert(0,'1');
        }
        else
        {
            str[i] = '1';
        }

        
    }
    
}
