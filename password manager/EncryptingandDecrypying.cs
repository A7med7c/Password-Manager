﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamentals.ConsoleApp.projects.password_manager
{
    internal class EncryptingandDecrypying
    {
        private static readonly string _originalChars = "ABCDEFGHIJKLMNOPQRSTUWXYZabcdefghijklmnopqrstuwxyz0123456789";
        private static readonly string _altChars = "ghijklmnopqrstuwxyz012345ABCDEFWXYZabcdef6789GHIJKLMNOPQRSTU";
        public static string Encrypt(string password)
        {
            var sb = new StringBuilder();   
            foreach (char ch in password)
            {
                var charIndex = _originalChars.IndexOf(ch);
                sb.Append(_altChars[charIndex]);
            }
            return sb.ToString();   
        }
        public static string Decrypt(string password )
        {
            var sb = new StringBuilder();
            foreach (char ch in password)
            {
                var charIndex = _altChars.IndexOf(ch);
                sb.Append(_originalChars[charIndex]);
            }
            return sb.ToString();
        }
    }
}
