using Azure.Core;
using Azure.Identity;
using Azure.Security.KeyVault.Keys;
using Azure.Security.KeyVault.Keys.Cryptography;
using Azure.Security.KeyVault.Secrets;
using System.Text;

string keyVaultUrl = "https://kv-sykorajak.vault.azure.net/";

TokenCredential credential = new DefaultAzureCredential();
//TokenCredential credential = new ClientSecretCredential("tenant_id", "client_id", "client_secret");

var secretClient = new SecretClient(vaultUri: new Uri(keyVaultUrl), credential);

KeyVaultSecret secret = await secretClient.GetSecretAsync("secretname");
Console.WriteLine(secret.Value);

var keyClient = new KeyClient(vaultUri: new Uri(keyVaultUrl), credential);
var cryptographyClient = keyClient.GetCryptographyClient("keyname");

EncryptResult encryptResult = cryptographyClient.Encrypt(EncryptionAlgorithm.RsaOaep, Encoding.UTF8.GetBytes("Hello, MFF!"));
foreach (byte b in encryptResult.Ciphertext)
{
    Console.Write("{0:X2}", b);
}
Console.WriteLine();

DecryptResult decryptResult = cryptographyClient.Decrypt(EncryptionAlgorithm.RsaOaep, encryptResult.Ciphertext);
Console.WriteLine(Encoding.UTF8.GetString(decryptResult.Plaintext));