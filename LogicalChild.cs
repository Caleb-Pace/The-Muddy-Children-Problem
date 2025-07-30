namespace Muddy_Children_Problem
{
    class LogicalChild(string name)
    {
        public string Name { get; set; } = name;
        private int round = -1;


        public bool Ask(int seenMuddy, int seenClean)
        {
            if (Program.verbose && round < 0) Console.WriteLine($"    {Name} sees {seenMuddy}m and {seenClean}c");

            round++;

            // ---- ---- ---- ---- ---- //

            //return true; // "I am muddy".

            // ---- ---- ---- ---- ---- //

            return false; // Silence.
        }
    }
}
