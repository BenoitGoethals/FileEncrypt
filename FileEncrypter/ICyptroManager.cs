using System;

namespace FileEncrypter
{
    public interface ICyptroManager
    {
        void AsynCyrptoFile(string file);
        void AsynDeCyrptoFile(string file);
    }
}