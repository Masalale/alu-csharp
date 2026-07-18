# 33 - Inverse 2D

This task implements the inverse of a 2x2 matrix. The determinant is computed first; if it is zero (non-invertible) or the input is not 2x2, a 1x1 sentinel matrix containing -1 is returned. Otherwise, the standard adjugate-over-determinant formula is applied, with each element of the result rounded to the nearest hundredth.

## Requirements

- All C# files compiled using `dotnet`
- Projects built with .NET 7 SDK
