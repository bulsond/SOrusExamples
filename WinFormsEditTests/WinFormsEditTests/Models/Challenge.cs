using System.Collections.Generic;

namespace WinFormsEditTests.Models
{
    /// <summary>
    /// Задача
    /// </summary>
    public class Challenge
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Question> Questions { get; }

        public Challenge()
        {
            Questions = new List<Question>();
        }
    }
}
