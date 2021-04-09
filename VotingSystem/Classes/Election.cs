namespace VotingSystem.Classes {

    /*
     * A class representing an election
     * 
     * Josh Bellmyer    4/9/2021
     */
    public class Election : Ballot {

        public string Candidate1 { get; private set; }
        public string Candidate2 { get; private set; }
        public string ElectionType { get; private set; }

        public int VotesFor1 { get; set; }
        public int VotesFor2 { get; set; }

        public override int Year { get; protected set; }
        public override bool Open { get; set; }


        public Election (string candidate1, string candidate2, string electionType, int year) {
            Candidate1 = candidate1;
            Candidate2 = candidate2;
            ElectionType = electionType;
            Year = year;

            VotesFor1 = 0;
            VotesFor2 = 0;
        }


        public override string ToString () {
            return $"{ElectionType} {Year} ({Candidate1} vs {Candidate2})";
        }


        // Returns the current status of the election
        public override string GetStatus () {
            if (VotesFor1 == VotesFor2) {
                return "Candidates are tied.";
            }

            string temp = Open ? "is winning with" : "won with";

            if (VotesFor1 > VotesFor2) {
                return $"{Candidate1} {temp} {GetPercentage(VotesFor1, VotesFor2)}% of the vote.";
            }
            else {
                return $"{Candidate2} {temp} {GetPercentage(VotesFor2, VotesFor1)}% of the vote.";
            }
        }


        // Gets the percentage of mainPart relative to the sum of mainPart and otherPart
        private int GetPercentage (int mainPart, int otherPart) {
            return (int)System.Math.Round(mainPart * 100 / (float)(mainPart + otherPart));
        }
    }
}
