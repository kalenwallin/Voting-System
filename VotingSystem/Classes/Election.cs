namespace VotingSystem.Classes {

    /*
     * A class representing an election
     * 
     * Josh Bellmyer    4/9/2021
     */
    public class Election {

        public string Candidate1 { get; private set; }
        public string Candidate2 { get; private set; }
        public string ElectionType { get; private set; }
        public int Year { get; private set; }


        public Election (string candidate1, string candidate2, string electionType, int year) {
            Candidate1 = candidate1;
            Candidate2 = candidate2;
            ElectionType = electionType;
            Year = year;
        }

        public override string ToString () {
            return $"{ElectionType} {Year} ({Candidate1} vs {Candidate2})";
        }
    }
}
