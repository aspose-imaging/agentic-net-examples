// HOW-TO: Check If Sharpening Kernel Increases Brightness For PNG In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            double[,] customKernel = new double[,]
            {
                { 0, -1, 0 },
                { -1, 5, -1 },
                { 0, -1, 0 }
            };

            double sum = 0;
            for (int i = 0; i < customKernel.GetLength(0); i++)
            {
                for (int j = 0; j < customKernel.GetLength(1); j++)
                {
                    sum += customKernel[i, j];
                }
            }

            if (sum > 1)
            {
                Console.WriteLine("Kernel sum exceeds one: brightness increase possible.");
            }
            else
            {
                Console.WriteLine("Kernel sum does not exceed one.");
            }

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                // Image loaded; additional processing can be added here.
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to verify that a custom sharpening filter will brighten a PNG before applying it with Aspose.Imaging in C#.
 * 2. When you want to ensure a convolution kernel’s total weight is greater than one to avoid unexpected darkening of images.
 * 3. When you are building an automated image‑enhancement pipeline that conditionally applies a sharpen filter only if it increases brightness.
 * 4. When you must programmatically check kernel parameters to meet quality requirements for PNG assets in a .NET application.
 * 5. When you are debugging a raster image processing routine and need to log whether the defined kernel will affect image luminance.
 */
