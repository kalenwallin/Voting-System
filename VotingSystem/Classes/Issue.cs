namespace VotingSystem.Classes {

    /*
     * A class representing an issue to be voted on
     * 
     * Josh Bellmyer    4/9/2021
     */
    public class Issue {

        public string Title { get; private set; }
        public string Description { get; private set; }
        public int Year { get; private set; }


        public Issue (string title, string description, int year) {
            Title = title;
            Description = description;
            Year = year;
        }

        public override string ToString () {
            return $"{Title} {Year}";
        }
    }
}
