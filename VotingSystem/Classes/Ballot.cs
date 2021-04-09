namespace VotingSystem.Classes {

    /*
     * An abstract class representing any type of ballot
     * 
     * Josh Bellmyer    4/9/2021
     */
    public abstract class Ballot {

        public abstract int Year { get; protected set; }
        public abstract bool Open { get; set; }

        // Returns the current status of the ballot
        public abstract string GetStatus();
    }
}
