using System;
using System.Collections.Generic;
using System.Linq;
using WinFormsUi.Interfaces;
using WinFormsUi.Models;
using WinFormsUi.Services.Tokens;

namespace WinFormsUi.Services
{
    public class WordService : IWordService
    {
        public WordService()
        { }

        public List<IWord> GetWordsWithDuplicates(List<IToken> tokens)
        {
            if (tokens == null)
                throw new ArgumentException(nameof(tokens));

            var result = tokens.Where(t => t is WordToken)
                               .Cast<WordToken>()
                               .Select(t => new Word(t.Value, t.Position, t.OrderNumber))
                               .ToList();

            return new List<IWord>(result);
        }

        public List<IWord> GetWords(List<IToken> tokens)
        {
            var wordDubl = GetWordsWithDuplicates(tokens);

            var result = wordDubl.GroupBy(w => w.Value)
                                 .Select(g =>
                                 {
                                     var word = g.First();
                                     foreach (Word w in g)
                                     {
                                         word.AddDuplicate(w.Positions.First(),
                                             w.OrderNumbers.First());
                                     }
                                     return word;
                                 })
                                 .ToList();

            return result;
        }

        public List<ITFIDFWord> GetTFIDFWords(List<IToken> tokens, int countSentences)
        {
            var words = this.GetWords(tokens);

            return words.Select(w =>
                    TFIDFWord.CreateFromWord(w, countSentences) as ITFIDFWord)
                        .ToList();
        }
    }
}
