using System.Text;

namespace Domain.Classes
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
            CurrentDurability = MaxDurability;
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
            paper.Text += BuildSentence(sentence);

            return paper;
        }

        /// <summary>
        /// Sets durability of pencil back to maximum value
        /// </summary>
        public void Sharpen()
        {
            if(Length > decimal.Zero)
            {
                Length--;
            }
            CurrentDurability = Length != decimal.Zero ? MaxDurability : CurrentDurability;
        }

        /// <summary>
        /// Adds a new word to first blank space on paper
        /// </summary>
        /// <param name="word">the word to be added</param>
        /// <param name="paper">the paper to be written to</param>
        /// <returns>the modified paper</returns>
        public Paper Edit(string word, Paper paper)
        {
            int firstDoubleSpace = paper.Text.IndexOf("  ") + 1;
            int length = firstDoubleSpace + word.Length;
            int wordCounter = 0;
            StringBuilder sentence = new StringBuilder(paper.Text);

            for (var i = firstDoubleSpace; i < length; i++)
            {
                sentence[i] = char.IsWhiteSpace(sentence[i]) ? word[wordCounter] : '@';
                wordCounter++;
            }
            paper.Text = sentence.ToString();

            return paper;
        }

        /// <summary>
        /// Constructs sentence accounting for pencil degregation
        /// </summary>
        /// <param name="input">sentence to be modified</param>
        /// <returns>the modified sentence</returns>
        private string BuildSentence(string input)
        {
            StringBuilder sentence = new StringBuilder(input);

            for (int i = 0; i < sentence.Length; i++)
            {
                if (!char.IsWhiteSpace(sentence[i]))
                {
                    if (CurrentDurability > decimal.Zero)
                    {
                        if (char.IsUpper(sentence[i]))
                        {
                            CurrentDurability -= 2;
                        }
                        else
                        {
                            CurrentDurability--;
                        }
                    }
                    else
                    {
                        sentence[i] = ' ';
                    }
                }
            }

            return sentence.ToString();
        }
    }
}
