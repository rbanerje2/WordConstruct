using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordFinder
{
    class Iterator
    {
        public List<string> GetAllCompoundWords(string[] inputWords)
        {
            List<string> compoundWords = new List<string>();
            Dictionary<string, bool> library = new Dictionary<string, bool>();
            List<string> orderedList = inputWords.OrderByDescending(x => x.Length).Distinct().ToList();
            foreach (var item in orderedList)
            {
                library.Add(item, true);
            }
            foreach (var item in orderedList)
            {
                if (IsWordCompound(item, true, library).Result)
                {
                    compoundWords.Add(item);
                }
            }
            return compoundWords;
        }

        private async Task<bool> IsWordCompound(string inputWord, bool isOriginal, Dictionary<string, bool> lib)
        {
            if (lib.ContainsKey(inputWord) && !isOriginal)
            {
                return lib[inputWord];
            }

            for (int i = 1; i < inputWord.Length; i++)
            {
                var pre = inputWord.Substring(0, i);
                var suf = inputWord.Substring(i);

                if (lib.ContainsKey(pre) && lib[pre])
                {
                    await Task.Yield();
                    if (await IsWordCompound(suf, false, lib))
                    {
                        return true;
                    }
                    await Task.Yield();
                }
            }

            return false;
        }
    }

}
