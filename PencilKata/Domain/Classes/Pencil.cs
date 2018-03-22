﻿namespace Domain.Classes
{
    public class Pencil
    {
        /// <summary>
        /// Maximum durability of pencil
        /// </summary>
        public int MaxDurability { get; }

        /// <summary>
        /// Current level of durability of pencil
        /// </summary>
        public int CurrentDurability { get; set; }

        /// <summary>
        /// Current length of pencil
        /// </summary>
        public int Length { get; set; }

        public Pencil(int maxDurability, int length)
        {
            MaxDurability = maxDurability;
            Length = length;
        }

        /// <summary>
        /// Adds letters to paper
        /// </summary>
        /// <param name="sentence">the sentence entered by the user</param>
        /// <param name="paper">the paper to be written on</param>
        /// <returns>the paper passed in with new characters added</returns>
        public Paper Write(string sentence, Paper paper)
        {
            paper.Text += sentence;
            return paper;
        }

        /// <summary>
        /// Adds a new word to first blank space on paper
        /// </summary>
        /// <param name="word">the word to be added</param>
        /// <param name="paper">the paper to be written to</param>
        /// <returns>the modified paper</returns>
        public Paper Edit(string word, Paper paper)
        {
            return paper;
        }
    }
}
