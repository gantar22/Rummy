using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : ScriptableObject {

    Stack<Card> cards;

	public Card draw_card()
    {
        if(cards.Count == 0)
        {
            return new Card(0, 0);
        }
        return cards.Pop();
    }

    public Deck(bool jokers = true)
    {
        cards = new Stack<Card>();
        for(Suit suit = 0; (int)suit < 4; suit++)
        {
            for(int rank = 1; rank < 14; rank++)
            {
                shuffle_in(new Card(rank,suit));
            }
        }

        if(jokers)
        {
            shuffle_in(new Card(14, Suit.black_joker));
            shuffle_in(new Card(14, Suit.red_joker  ));
        }
    }

    public void shuffle_in(Card card)
    {
        int i = (int)(Random.value * cards.Count);

        Stack<Card> temp = new Stack<Card>();

        int j;
        for(j = 0; j < i; j++)
        {
            temp.Push(cards.Pop());
        }
        cards.Push(card);

        for(;j > 0; j--)
        {
            cards.Push(temp.Pop());
        }

    }




}
