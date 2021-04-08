using System;

/*
 * A class representing an election
 * 
 * Josh Bellmyer    4/8/2021
 */
public class Election {

    public enum ElectionType {
        Mayor,
        CouncilMember,
        Treasurer,
    }

    public string Candidate1 { get; private set; }
    public string Candidate2 { get; private set; }
    public ElectionType Type { get; private set; }


    public Election (string candidate1, string candidate2, ElectionType type) {
        Candidate1 = candidate1;
        Candidate2 = candidate2;
        Type = type;
    }

    public override string ToString () {
        return $"{Candidate1} vs {Candidate2}";
    }
}
