namespace Domain.Classes
{
    public class Eraser
    {
        /// <summary>
        /// uses left of eraser
        /// </summary>
        private int Durability { get; set; }

        public Eraser(int durability)
        {
            Durability = durability;
        }

        /// <summary>
        /// Removes a word from the paper as entered
        /// </summary>
        /// <param name="word">the word to be removed</param>
        /// <param name="paper">the paper written on</param>
        /// <returns>the paper written on after erasing word</returns>
        public Paper Erase(string word, Paper paper)
        {
            return paper; 
        }
    }
}
