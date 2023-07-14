using System.Security.Cryptography;
using System.Text;


namespace Azmoonak.Database.Classes;

public class Security
{
    public async Task<string> HashPassword(string password)
    {
        MD5 md5 = MD5.Create();
        byte[] mainByte = ASCIIEncoding.Default.GetBytes(password);
        byte[] hashBytes = md5.ComputeHash(mainByte);
        return await Task.FromResult(BitConverter.ToString(hashBytes));
    }
}
