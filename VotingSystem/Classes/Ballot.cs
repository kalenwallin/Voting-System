namespace VotingSystem.Classes {

    /*
     * An class representing a single ballot
     * 
     * Josh Bellmyer    4/9/2021
     */
    public class Ballot {

        public int BallotId { get; set; }
        public int UserId { get; set; }
        public int ElectionId { get; set; }
        public Candidate Candidate1 { get; private set; }
        public Candidate Candidate2 { get; private set; }
        public int IssueId { get; set; }
        public bool VotedYes { get; private set; }

        public Ballot() { 
        
        }

        public Ballot(Candidate candidate1, Candidate candidate2, bool votedYes) {
            Candidate1 = candidate1;
            Candidate2 = candidate2;
            VotedYes = votedYes;
        }
    }
}
