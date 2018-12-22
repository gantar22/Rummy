using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Rummy_Board {
    

    public struct Rcard
    {
        public Card c;
        public bool is_joker;

        public Rank rank
        {
            get { return c.rank; }
            set { c.rank = value; }
        }
        public Suit suit
        {
            get { return c.suit; }
            set { c.suit = value; }
        }

        public static implicit operator Card(Rcard rcard)
        {
            return rcard.c;
        }
    }

    class set
    {
        List<Card> content; //ordered and non empty and is a valid set

        bool is_run;
        

        public bool validate_initial(List<Rcard> cards)
        {
            if (cards.Count < 3) return false;
            List<Rcard> sorted_cards = cards.OrderBy(c => c.rank).ToList();

            Rank old_rank = sorted_cards[0].rank;
            bool is_run = true;

            for(int i = 1; i < sorted_cards.Count; i++)
            {
                if(old_rank + 1 != sorted_cards[i].rank)
                    is_run = false;
            }
            if(!is_run && sorted_cards[0].rank == (Rank)1)
            {
                is_run = true;
                old_rank = sorted_cards[1].rank;
                for (int i = 2; i < sorted_cards.Count; i++)
                {
                    if (old_rank + 1 != sorted_cards[i].rank)
                        is_run = false;
                }
                if (sorted_cards[sorted_cards.Count - 1].rank != (Rank)13)
                    is_run = false;
            }
           

            return true;
        }

        public bool add_card(Rcard card)
        {
            if (!validate(card)) return false;
            if(is_run)
            {
                if (card.rank == content[0].rank - 1)
                    content.Insert(0, card);
                else
                    content.Add(card);
            } else
            {
                content.Add(card);
            }
            return true;
        }

        bool validate(Rcard card)
        {
            if (card.rank == 0 || card.rank == (Rank)14) return false;
            if(is_run)
            {
                if (card.suit != content[0].suit)
                    return false;
                if (card.rank != content[0].rank - 1 && card.rank != content[content.Count - 1].rank + 1
                    && !(card.rank == (Rank)1 && content[content.Count - 1].rank == (Rank)13))
                    return false;
                if (card.rank == (Rank)2 && content[0].rank != (Rank)3)
                    return false;
            }
            else //its a pair or something
            {
                if (card.rank != content[0].rank)
                    return false;
            }
            return true;
        }
    }

}
