﻿using System.Text;
using BigO.Core;
using BigO.Core.Validation;
using JetBrains.Annotations;
using static System.Char;

namespace BigO.Security;

/// <summary>
///     Utility for generating strong passwords
/// </summary>
[PublicAPI]
public static class PasswordGenerator
{
    private const int AlphabetCount = 25;
    private const int NumbersCount = 9;
    private const int SpecialCharactersCount = 7;
    private static readonly char[] UpperCaseCharacters;
    private static readonly char[] LowerCaseCharacters;
    private static readonly char[] Numbers;
    private static readonly char[] SpecialCharacters;

    static PasswordGenerator()
    {
        // ReSharper disable once StringLiteralTypo
        UpperCaseCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        LowerCaseCharacters = UpperCaseCharacters.Select(ToLower).ToArray();
        Numbers = "1234567890".ToCharArray();
        SpecialCharacters = "!@#$%^&*".ToCharArray();
    }

    /// <summary>
    ///     Generates a random password of the specified length.
    /// </summary>
    /// <param name="passwordLength">
    ///     The length of the password to be generated. Must be between 6 and 99, inclusive.
    ///     <c>Default is 12</c>.
    /// </param>
    /// <param name="includeUpperCaseCharacters">
    ///     Indicates whether to include upper case characters in the password.
    ///     <c>Default is true</c>.
    /// </param>
    /// <param name="includeLowerCaseCharacters">
    ///     Indicates whether to include lower case characters in the password.
    ///     <c>Default is true</c>.
    /// </param>
    /// <param name="includeNumbers">Indicates whether to include numbers in the password. <c>Default is true</c>.</param>
    /// <param name="includeSpecialCharacters">
    ///     Indicates whether to include special characters in the password.
    ///     <c>Default is true</c>.
    /// </param>
    /// <returns>The generated password.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Thrown when <paramref name="passwordLength" /> is less than 6 or greater
    ///     than 99.
    /// </exception>
    /// <exception cref="ArgumentException">Thrown when no categories are specified to be included in the password.</exception>
    /// <remarks>
    ///     The password is generated by randomly selecting characters from different categories, such as upper case
    ///     characters, lower case characters, numbers, and special characters.
    ///     At least one character from each category specified to be included will be included in the password.
    /// </remarks>
    public static string GeneratePassword(int passwordLength = 12, bool includeUpperCaseCharacters = true,
        bool includeLowerCaseCharacters = true, bool includeNumbers = true, bool includeSpecialCharacters = true)
    {
        Guard.Minimum(passwordLength, 6, nameof(passwordLength));
        Guard.Maximum(passwordLength, 99, nameof(passwordLength));

        ValidateArguments(includeUpperCaseCharacters, includeLowerCaseCharacters, includeNumbers,
            includeSpecialCharacters);

        var categoriesToInclude = GetCategories(includeUpperCaseCharacters, includeLowerCaseCharacters,
            includeNumbers,
            includeSpecialCharacters);

        var numberOfCategories = categoriesToInclude.Count;

        StringBuilder passwordBuilder = new();

        var currentCategoryIndex = RandomGenerator.RandomInt(0, numberOfCategories - 1);
        var currentCategory = categoriesToInclude.ElementAt(currentCategoryIndex);
        var previousCategoryCount = 0;
        var previousCategory = 0;

        for (var i = 0; i < passwordLength; i++)
        {
            if (previousCategoryCount < 1)
            {
                currentCategoryIndex = RandomGenerator.RandomInt(0, numberOfCategories - 1);
                currentCategory = categoriesToInclude.ElementAt(currentCategoryIndex);
            }
            else
            {
                while (currentCategory == previousCategory)
                {
                    currentCategoryIndex = RandomGenerator.RandomInt(0, numberOfCategories - 1);
                    currentCategory = categoriesToInclude.ElementAt(currentCategoryIndex);
                }
            }

            int index;
            switch (currentCategory)
            {
                case 1:
                    index = RandomGenerator.RandomInt(0, AlphabetCount);
                    passwordBuilder.Append(UpperCaseCharacters.ElementAt(index));
                    break;
                case 2:
                    index = RandomGenerator.RandomInt(0, AlphabetCount);
                    passwordBuilder.Append(LowerCaseCharacters.ElementAt(index));
                    break;
                case 3:
                    index = RandomGenerator.RandomInt(0, NumbersCount);
                    passwordBuilder.Append(Numbers.ElementAt(index));
                    break;
                case 4:
                    index = RandomGenerator.RandomInt(0, SpecialCharactersCount);
                    passwordBuilder.Append(SpecialCharacters.ElementAt(index));
                    break;
            }

            if (previousCategory == currentCategory)
            {
                previousCategoryCount += 1;
            }
            else
            {
                previousCategory = currentCategory;
                previousCategoryCount = 0;
            }
        }

        return passwordBuilder.ToString();
    }

    private static List<int> GetCategories(bool includeUpperCaseCharacters,
        bool includeLowerCaseCharacters, bool includeNumbers, bool includeSpecialCharacters)
    {
        List<int> categoriesToInclude = new();

        if (includeUpperCaseCharacters)
        {
            categoriesToInclude.Add(1);
        }

        if (includeLowerCaseCharacters)
        {
            categoriesToInclude.Add(2);
        }

        if (includeNumbers)
        {
            categoriesToInclude.Add(3);
        }

        if (includeSpecialCharacters)
        {
            categoriesToInclude.Add(4);
        }

        return categoriesToInclude;
    }

    private static void ValidateArguments(bool includeUpperCaseCharacters, bool includeLowerCaseCharacters,
        bool includeNumbers, bool includeSpecialCharacters)
    {
        if (includeUpperCaseCharacters)
        {
            return;
        }

        if (includeLowerCaseCharacters)
        {
            return;
        }

        if (includeNumbers)
        {
            return;
        }

        if (includeSpecialCharacters)
        {
            return;
        }

        throw new ArgumentException("At least one criteria need to be included for password generation.");
    }
}