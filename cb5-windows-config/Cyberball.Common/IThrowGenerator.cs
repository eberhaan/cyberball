namespace Cyberball.Common
{
    public interface IThrowGenerator
    {
        int GetNextThrow(int prevPlayer);
    }
}