using System.Text;

namespace Domain.Classes
{
    public class Eraser
    {
        /// <summary>
        /// uses left of eraser
        /// </summary>
        public int Durability { get; set; }

        public Eraser(int durability)
        {
            Durability = durability;
        }

        /// <summary>
        /// Removes a word from the paper as entered
        /// </summary>
        /// <param name="word">the word to be removed</param>
        /// <param name="paper">the paper written on</param>
        /// <returns>the sentence after erasing word</returns>
        public string Erase(string word, string input)
        {
            if (Durability > 0)
            {
                int firstIndexOfWord = input.IndexOf(word);
                if (firstIndexOfWord != -1)
                {
                    int length = firstIndexOfWord + word.Length - 1;
                    StringBuilder sentence = new StringBuilder(input);
                    for (var i = length; i >= firstIndexOfWord; i--)
                    {
                        if (Durability > 0)
                        {
                            sentence[i] = ' ';
                            Durability--;
                        }
                        else
                        {
                            i = firstIndexOfWord - 1;
                        }
                    }
                    return sentence.ToString();
                }
            }
            return input; 
        }
    }
}
