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

            // You only see clean, but there is one muddy.
            // Therefore it must be you.
            if (seenMuddy == 0)
                return true; // "I am muddy".

            // Everyone hesitated.
            // (Round hesitation is used to find the amount of muddy children).
            // If you do not see all the muddy children, you are one.
            if (round > seenMuddy)
                return true; // "I am muddy".

            // ---- ---- ---- ---- ---- //

            return false; // Silence.
        }
    }
}
