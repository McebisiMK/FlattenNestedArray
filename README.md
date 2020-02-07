# FlattenNestedArray

An algorithm to flatten an arbitrarily nested array of integers.

## Flatten an arbitrarily nested array:

**Important information:**

- At any given position, the value can be:

  - Integer value or
  - Other array which can containing integers and nested arrays as well.

- Loop through all the arrays to get integers and create a 1D array (flatten array).
  - If a value at position is not convertible to integer, return an error message with the value.
  - If an array is empty, return an error message.
  - If array (nested or not) is valid, return a flatten version of the array.

**Tools and Tech used:**

- .Net Core 3.0
- C#
- AutoFac (IoC Container)
- NUnit
- NSubstitute
- Git

**Instructions:**

- Clone the repository and do the following:

  - Build solution:
    - Navigate to parent folder and run:
      > dotnet build.
  - Run tests:
    - Navigate to Test solution (FlattenNestedArray.Tests) and run:
      > dotnet test.
  - Run application:
    - Navigate to App solution (FlattenNestedArray.App) and run:
      > dotnet run.

- Alternatively run it on visual studio
