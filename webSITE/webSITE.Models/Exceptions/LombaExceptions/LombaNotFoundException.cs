using webSITE.Domain.Abstractions;

namespace webSITE.Domain.Exceptions.LombaExceptions
{
    public class LombaNotFoundException : NotFoundException<Lomba, int>
    {
        public LombaNotFoundException(string message) : base(message)
        {
        }

        public LombaNotFoundException(int id, string keyName) : base(id, keyName)
        {
        }
    }
}
