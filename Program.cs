namespace Muddy_Children_Problem
{
    internal class Program
    {
        public static bool verbose = true;

        private static int childCount = 4;
        private static Random rnd = new Random();

        private static bool[] answerIndex;
        private static bool[] muddyIndex;
        private static LogicalChild[] children;


        private static void CreateMuddyIndex()
        {
            /* // [Slash to toggle]

            // < Set custom muddy arrangement >
            //muddyIndex = [true, false, false, false];
            //muddyIndex = [true, true, false, false];
            //muddyIndex = [false, true, true, false];
            //muddyIndex = [true, false, false, true];
            //muddyIndex = [true, false, true, false];
            //muddyIndex = [false, true, false, true];
            //muddyIndex = [false, true, true, true];
            //muddyIndex = [true, true, true, true];
            //muddyIndex = [true, false, false, true, false, true, true, true, false];
            muddyIndex = [true, false, false, true, false, true, true, true, false, true];

            /*/

            // < Add muddy children (randomly) >
            muddyIndex = new bool[childCount];
            muddyIndex[rnd.Next(childCount)] = true; // At least 1 muddy
            for (int i = 1; i < childCount; i++)
            {
                if (muddyIndex[i]) continue; // Initial muddy child.

                if (rnd.Next(2) == 1)
                    muddyIndex[i] = true;
            }
            //*/
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Muddy Children demo:\n");

            // Get muddy index
            CreateMuddyIndex();
            childCount = muddyIndex.Length;

            // Count children.
            int muddyCount = muddyIndex.Count(x => x);

            // Initialise arrays.
            answerIndex = new bool[childCount];
            children = new LogicalChild[childCount];
            
            // Name children.
            for (int i = 0; i < childCount; i++)
            {
                string name = $"{(char)(65 + i)}";
                children[i] = new(name);
            }

            PrintState();

            // Decisions.
            int overflow = childCount * 2;
            while (muddyCount > 0 && overflow-- > 0)
            {
                for (int i = 0; i < childCount; i++)
                {
                    // Get perspective.
                    int clean = 0;
                    int muddy = 0;
                    for (int j = 0; j < childCount; j++)
                    {
                        if (j == i) continue; // Ignore self.

                        if (muddyIndex[j])
                            muddy++;
                        else
                            clean++;
                    }

                    if (children[i].Ask(muddy, clean))
                    {
                        Console.WriteLine($"  {children[i].Name}: \"I am muddy\".");
                        answerIndex[i] = true;
                        muddyCount--;
                    }
                }
            }

            Console.WriteLine();
            PrintState(true);

            // Check correctness.
            bool isCorrect = true;
            string comments = "";
            for (int i = 0; i < childCount; i++)
            {
                if (answerIndex[i] != muddyIndex[i])
                {
                    isCorrect = false;
                    comments += $" ! Index {i} was wrong.\n";
                }
            }
            Console.WriteLine($"this is {(isCorrect ? "" : "in")}correct!\n{comments}");
        }

        private static void PrintState(bool showAnswerIndex = false)
        {
            string output = "";

            for (int i = 0; i < childCount; i++)
            {
                string ans = showAnswerIndex ? $"?{(answerIndex[i] ? 'm' : 'c')}" : "  ";
                output += $"{children[i].Name}|{(muddyIndex[i] ? 'm' : 'c')}{ans}";

                if (i < (childCount - 1)) output += "  ";
            }

            Console.WriteLine(output);
        }
    }
}
