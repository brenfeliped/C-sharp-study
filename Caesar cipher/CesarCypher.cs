using System;

namespace Codenation.Challenge
{
  public class CesarCypher : ICrypt, IDecrypt
  {

    public int Mod(int diviend, int divisor)
    {
      int remainder = (diviend % divisor + divisor) % divisor;

      return remainder;
    }
    public string CryptDecrypt(string message, string operation = "decrypt")
    { // operation "crypt" for encryption and "decrypt" for decryption, "decrypt" is default

      Int16 key = 3;
      string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToLower();
      string cipherText = "";
      int indexMsg = 0;
      int indexCryptDecrypt = 0;

      if (message != null)
      {
        foreach (char letter in message.ToLower())
        {
          if (alphabet.Contains(letter.ToString()))                 // if is a letter
          {
            indexMsg = alphabet.IndexOf(letter);

            if (operation.ToLower() == "crypt")
            {
              indexCryptDecrypt = Mod((indexMsg + key), 26);
            }

            else if (operation.ToLower() == "decrypt")
            {
              indexCryptDecrypt = Mod((indexMsg - key), 26);     // calculates the index for Decrypt
            }
            else
            {
              throw new ArgumentException();
            }

            cipherText += alphabet[indexCryptDecrypt];
          }
          else if (Char.IsDigit(letter) || letter.ToString() == " ")
            cipherText += letter;

          else
            throw new ArgumentOutOfRangeException();

        }
      }

      else
        throw new ArgumentNullException();

      return cipherText;
    }
    public string Crypt(string message)
    {
      return CryptDecrypt(message, "Crypt");
    }

    public string Decrypt(string cryptedMessage)
    {
      return CryptDecrypt(cryptedMessage, "Decrypt");
    }

  }

}
