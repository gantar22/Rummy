using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Suit { spade, heart, club, diamond, red_joker, black_joker}

public enum Rank : int { }// 1 = ACE numbers = themselves, JQK = 11,12,13; 14 = Joker

public struct Card {

    public Rank rank;

    public Suit suit;

    public Card(int rank, Suit suit)
    {
        this.rank = (Rank)rank;
        this.suit = suit;
    }
}
