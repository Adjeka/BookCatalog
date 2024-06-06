using BookCatalog.Infrastructure.Entities;
using System.Text.RegularExpressions;

namespace BookCatalog.Infrastructure
{
    public static class Extention
    {
        public static bool IsValid(this AuthorEntity authorEntity)
        {
            bool isFirstNameEnglish = Regex.IsMatch(authorEntity.FirstName, @"^[a-zA-Z]+$");
            bool isLastNameEnglish = Regex.IsMatch(authorEntity.LastName, @"^[a-zA-Z]+$");
            bool isFirstNameRussian = Regex.IsMatch(authorEntity.FirstName, @"^[а-яА-ЯёЁ]+$");
            bool isLastNameRussian = Regex.IsMatch(authorEntity.LastName, @"^[а-яА-ЯёЁ]+$");

            if ((isFirstNameEnglish && isLastNameEnglish) || (isFirstNameRussian && isLastNameRussian))
            {
                return true;
            }

            return false;
        }
    }
}
