using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020
{
    public class Day21 : Solver
    {
        List<Food> foods = new List<Food>();
        List<string> allIngredients = new List<string>();
        List<string> allAllergens = new List<string>();
        Hashtable ingredientOcurrencies = new Hashtable();
        Hashtable possibleIngredients = new Hashtable();

        Random random = new Random();

        public Day21(string input)
        {
            input.Split("\r\n").ToList().ForEach(i =>
            {
                Food newFood = new Food(i);
                foods.Add(newFood);
                allIngredients = allIngredients.Union(newFood.Ingredients).ToList();
                allAllergens = allAllergens.Union(newFood.Allergens).ToList();

                foreach (string ingredient in newFood.Ingredients)
                {
                    if (ingredientOcurrencies.ContainsKey(ingredient))
                    {
                        ingredientOcurrencies[ingredient] = ((int)ingredientOcurrencies[ingredient]) + 1;
                    }
                    else
                    {
                        ingredientOcurrencies[ingredient] = 1;
                    }
                }
            });
        }


        public override long SolvePart1()
        {
            foreach (string allergens in allAllergens)
            {
                possibleIngredients[allergens] = allIngredients.Select(a => (string)a.Clone()).ToList();
            }

            foreach (Food food in foods)
            {
                foreach (string allergen in food.Allergens)
                {
                    possibleIngredients[allergen] = ((List<string>)possibleIngredients[allergen]).Intersect(food.Ingredients).ToList();
                }
            }

            while (possibleIngredients.Values.Cast<List<string>>().Any(pi => pi.Count() > 1))
            {
                List<string> allergensCompleted = allAllergens.Where(a => ((List<string>)possibleIngredients[a]).Count() == 1).ToList();

                string currentCompletedAllergen = allergensCompleted[random.Next(0, allergensCompleted.Count())];
                string ingredient = ((List<string>)possibleIngredients[currentCompletedAllergen])[0];

                foreach (string anotherAllergen in allAllergens)
                {
                    if (currentCompletedAllergen.Equals(anotherAllergen))
                    {
                        continue;
                    }

                    ((List<string>)possibleIngredients[anotherAllergen]).Remove(ingredient);
                }
            }

            return allIngredients.Where(i => !possibleIngredients.Values.Cast<List<string>>().Any(pi => pi.Contains(i))).Sum(i => (int)ingredientOcurrencies[i]);
        }

        public override long SolvePart2()
        {
            return SolvePart2String().Length;
        }

        public string SolvePart2String()
        {
            SolvePart1();

            string result = "";

            foreach (string ingredient in possibleIngredients.Values.Cast<List<string>>().OrderBy(i => GetAllergen(i[0])).Select(pi => pi[0]))
            {
                result += ingredient + ",";
            }

            return result.Substring(0, result.Length - 1);


            string GetAllergen(string ingredient)
            {
                return possibleIngredients.Keys.Cast<string>().First(a => ((List<string>)possibleIngredients[a])[0].Equals(ingredient));
            }
        }
    }


    class Food
    {
        public List<string> Ingredients = new List<string>();
        public List<string> Allergens = new List<string>();

        public Food(string food)
        {
            string[] foodSplitted = food.Substring(0, food.Length - 1).Split(" (");

            foreach (string ingredient in foodSplitted[0].Split(' '))
            {
                Ingredients.Add(ingredient);
            }

            foreach (string allergen in foodSplitted[1].Replace("contains ", "").Split(", "))
            {
                Allergens.Add(allergen);
            }
        }
    }
}