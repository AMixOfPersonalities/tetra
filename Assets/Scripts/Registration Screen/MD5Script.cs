using System;
using System.Text;
using UnityEngine;
using TMPro;
public class MD5Script : MonoBehaviour
{
    public TMP_InputField inputField;

    public string GenerateMD5Hash()
    {
        string inputText = inputField.text;

        if (string.IsNullOrEmpty(inputText))
        {
            Debug.LogError("Input field is empty!");
            return null;
        }

        string md5Hash = CalculateMD5Hash(inputText);
        return md5Hash;
    }

    private string CalculateMD5Hash(string input)
    {
        // Step 1: Convert input string to byte array
        byte[] inputBytes = Encoding.UTF8.GetBytes(input);

        // Step 2: Initialize MD5 variables
        uint[] r = new uint[] {
            0x67452301, 0xefcdab89, 0x98badcfe, 0x10325476
        };
        uint[] k = new uint[] {
            0xd76aa478, 0xe8c7b756, 0x242070db, 0xc1bdceee,
            0xf57c0faf, 0x4787c62a, 0xa8304613, 0xfd469501,
            0x698098d8, 0x8b44f7af, 0xffff5bb1, 0x895cd7be,
            0x6b901122, 0xfd987193, 0xa679438e, 0x49b40821,
            0xf61e2562, 0xc040b340, 0x265e5a51, 0xe9b6c7aa,
            0xd62f105d, 0x02441453, 0xd8a1e681, 0xe7d3fbc8,
            0x21e1cde6, 0xc33707d6, 0xf4d50d87, 0x455a14ed,
            0xa9e3e905, 0xfcefa3f8, 0x676f02d9, 0x8d2a4c8a,
            0xfffa3942, 0x8771f681, 0x6d9d6122, 0xfde5380c,
            0xa4beea44, 0x4bdecfa9, 0xf6bb4b60, 0xbebfbc70,
            0x289b7ec6, 0xeaa127fa, 0xd4ef3085, 0x04881d05,
            0xd9d4d039, 0xe6db99e5, 0x1fa27cf8, 0xc4ac5665,
            0xf4292244, 0x432aff97, 0xab9423a7, 0xfc93a039,
            0x655b59c3, 0x8f0ccc92, 0xffeff47d, 0x85845dd1,
            0x6fa87e4f, 0xfe2ce6e0, 0xa3014314, 0x4e0811a1,
            0xf7537e82, 0xbd3af235, 0x2ad7d2bb, 0xeb86d391
        };

        // Step 3: Append padding
        int initialLength = inputBytes.Length;
        int paddedLength = (initialLength + 8 + 63) / 64 * 64;
        byte[] paddedBytes = new byte[paddedLength];
        for (int i = 0; i < initialLength; i++)
        {
            paddedBytes[i] = inputBytes[i];
        }
        paddedBytes[initialLength] = 0x80;
        ulong bitLength = (ulong)initialLength * 8;
        for (int i = 0; i < 8; i++)
        {
            paddedBytes[paddedLength - 8 + i] = (byte)(bitLength >> (8 * i));
        }

        // Step 4: Process message in 512-bit chunks
        for (int chunkStart = 0; chunkStart < paddedLength; chunkStart += 64)
        {
            uint[] w = new uint[16];
            for (int i = 0; i < 16; i++)
            {
                w[i] = (uint)(
                    (paddedBytes[chunkStart + i * 4 + 0] << 0) |
                    (paddedBytes[chunkStart + i * 4 + 1] << 8) |
                    (paddedBytes[chunkStart + i * 4 + 2] << 16) |
                    (paddedBytes[chunkStart + i * 4 + 3] << 24)
                );
            }

            uint[] hash = (uint[])r.Clone();
            for (int i = 0; i < 64; i++)
            {
                uint f, g;
                if (i < 16)
                {
                    f = (hash[1] & hash[2]) | (~hash[1] & hash[3]);
                    g = (uint)i;
                }
                else if (i < 32)
                {
                    f = (hash[3] & hash[1]) | (~hash[3] & hash[2]);
                    g = (uint)((5 * i + 1) % 16);
                }
                else if (i < 48)
                {
                    f = hash[1] ^ hash[2] ^ hash[3];
                    g = (uint)((3 * i + 5) % 16);
                }
                else
                {
                    f = hash[2] ^ (hash[1] | ~hash[3]);
                    g = (uint)((7 * i) % 16);
                }

                uint temp = hash[3];
                hash[3] = hash[2];
                hash[2] = hash[1];
                hash[1] = hash[1] + RotateLeft((hash[0] + f + k[i] + w[g]), (int)i);
                hash[0] = temp;
            }

            for (int i = 0; i < 4; i++)
            {
                r[i] += hash[i];
            }
        }

        // Step 5: Format hash as string
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < 4; i++)
        {
            byte[] tempBytes = BitConverter.GetBytes(r[i]);
            for (int j = 0; j < 4; j++)
            {
                sb.Append(tempBytes[j].ToString("x2"));
            }
        }

        return sb.ToString();
    }

    private uint RotateLeft(uint x, int n)
    {
        return (x << n) | (x >> (32 - n));
    }
}