namespace VotingSystem.Classes {

    /*
     * A class representing an issue to be voted on
     * 
     * Josh Bellmyer    4/9/2021
     */
    public class Issue : Ballot {

        public string Title { get; private set; }
        public string Description { get; private set; }

        public int VotesForYes { get; set; }
        public int VotesForNo { get; set; }

        public override int Year { get; protected set; }
        public override bool Open { get; set; }


        public Issue (string title, string description, int year) {
            Title = title;
            Description = description;
            Year = year;
        }


        public override string ToString () {
            return $"{Title} {Year}";
        }


        // Returns the current status of the election
        public override string GetStatus () {
            if (VotesForYes == VotesForNo) {
                return $"{Title} vote is undecided.";
            }

            string temp = Open ? "is leaning towards being" : "has been";

            if (VotesForYes > VotesForNo) {
                return $"{Title} vote {temp} approved.";
            }
            else {
                return $"{Title} vote {temp} denied.";
            }
        }
    }
}
