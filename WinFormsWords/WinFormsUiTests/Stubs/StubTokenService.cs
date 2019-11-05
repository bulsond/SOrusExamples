using System;
using System.Collections.Generic;
using WinFormsUi.Interfaces;
using WinFormsUi.Services.Tokens;

namespace WinFormsUiTests.Stubs
{
    class StubTokenService : ITokenService
    {
        public int GetCountSentences(List<IToken> tokens)
        {
            return 3;
        }

        //по одному дубликату для "второе" и "третье"
        public List<IToken> GetTokens(string text)
        {
            var result = new List<IToken>
            {
                new WordToken(0, "Первое", 1),
                new SpaceToken(6),
                new WordToken(7, "второе", 2),
                new SpaceToken(13),
                new WordToken(14, "третье", 3),
                new SignToken(20, "."),
                new SpaceToken(21),
                new WordToken(22, "Четвертое", 4),
                new SpaceToken(31),
                new WordToken(32, "Пятое", 5),
                new SignToken(37, "."),
                new SpaceToken(38),
                new WordToken(39, "Второе", 6),
                new SpaceToken(45),
                new WordToken(46, "Третье", 7),
                new SignToken(52, "."),
            };

            return result;
        }
    }
}
