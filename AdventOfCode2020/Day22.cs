using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020
{
    public class Day22 : Solver
    {
        List<int> player1Deck;
        List<int> player2Deck;

        public Day22(string input)
        {
            string[] decks = input.Split("\r\n\r\n");

            player1Deck = decks[0].Split("\r\n").Skip(1).Select(i => Convert.ToInt32(i)).ToList();
            player2Deck = decks[1].Split("\r\n").Skip(1).Select(i => Convert.ToInt32(i)).ToList();
        }


        public override long SolvePart1()
        {
            while (player1Deck.Count() > 0 && player2Deck.Count > 0)
            {
                int player1Card = player1Deck[0];
                int player2Card = player2Deck[0];
                player1Deck.RemoveAt(0);
                player2Deck.RemoveAt(0);

                if (player1Card > player2Card)
                {
                    player1Deck.Add(player1Card);
                    player1Deck.Add(player2Card);
                }
                else
                {
                    player2Deck.Add(player2Card);
                    player2Deck.Add(player1Card);
                }
            }

            List<int> winnerDeck = player1Deck.Count() > 0 ? player1Deck : player2Deck;

            return CalculateWinningPlayerScore(winnerDeck);
        }

        public override long SolvePart2()
        {
            return PlayRecursiveCombat(player1Deck, player2Deck).result;
        }


        private (long result, int winner) PlayRecursiveCombat(List<int> player1Deck, List<int> player2Deck)
        {
            Dictionary<Deck, List<Deck>> alreadyVisitedConfigurations = new Dictionary<Deck, List<Deck>>();

            while (player1Deck.Count() > 0 && player2Deck.Count > 0)
            {
                if (alreadyVisitedConfigurations.ContainsKey(new Deck(player1Deck)))
                {
                    if (alreadyVisitedConfigurations[new Deck(player1Deck)].Contains(new Deck(player2Deck)))
                    {
                        return (CalculateWinningPlayerScore(player1Deck), 1);
                    }

                    alreadyVisitedConfigurations[new Deck(player1Deck)].Add(new Deck(player2Deck));
                }
                else
                {
                    alreadyVisitedConfigurations.Add(new Deck(player1Deck), new List<Deck>() { new Deck(player2Deck) });
                }

                int player1Card = player1Deck[0];
                int player2Card = player2Deck[0];
                player1Deck.RemoveAt(0);
                player2Deck.RemoveAt(0);

                if (player1Card > player1Deck.Count() || player2Card > player2Deck.Count())
                {
                    if (player1Card > player2Card)
                    {
                        Player1WinsRound(player1Card, player2Card);
                    }
                    else
                    {
                        Player2WinsRound(player1Card, player2Card);
                    }

                    continue;
                }

                List<int> player1SubGameDeck = player1Deck.Take(player1Card).ToList();
                List<int> player2SubGameDeck = player2Deck.Take(player2Card).ToList();

                (long _, int subgGameWinner) = PlayRecursiveCombat(player1SubGameDeck, player2SubGameDeck);

                if (subgGameWinner == 1)
                {
                    Player1WinsRound(player1Card, player2Card);
                }
                else
                {
                    Player2WinsRound(player1Card, player2Card);
                }
            }

            List<int> winnerDeck = player1Deck;
            int winner = 1;

            if (player1Deck.Count() == 0)
            {
                winnerDeck = player2Deck;
                winner = 2;
            }

            return (CalculateWinningPlayerScore(winnerDeck), winner);


            void Player1WinsRound(int player1Card, int player2Card)
            {
                player1Deck.Add(player1Card);
                player1Deck.Add(player2Card);
            }

            void Player2WinsRound(int player1Card, int player2Card)
            {
                player2Deck.Add(player2Card);
                player2Deck.Add(player1Card);
            }
        }

        private long CalculateWinningPlayerScore(List<int> winnerDeck)
        {
            long result = 0;

            for (int i = 0; i < winnerDeck.Count(); i++)
            {
                result += winnerDeck[i] * (winnerDeck.Count() - i);
            }

            return result;
        }
    }

    class Deck
    {
        List<int> cards;

        public Deck(List<int> cards)
        {
            this.cards = cards.Select(i => i).ToList();
        }

        public override bool Equals(object obj)
        {
            return cards.SequenceEqual(((Deck)obj).cards);
        }

        public override int GetHashCode()
        {
            int hash = 5;

            for (int i = 0; i < cards.Count(); i++)
            {
                hash += cards[i] * i;
            }

            return hash;
        }
    }
}