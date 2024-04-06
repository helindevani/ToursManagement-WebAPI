using ToursDatabase.Enums;

namespace ToursDatabase.Controllers
{
    internal struct Difficulty
    {
        public static implicit operator DifficultyType(Difficulty v)
        {
            throw new NotImplementedException();
        }
    }
}