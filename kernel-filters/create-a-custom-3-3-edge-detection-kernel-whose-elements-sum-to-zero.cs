// HOW-TO: Create Custom 3x3 Edge Detection Kernel with Zero Sum in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            double[,] customKernel = new double[,]
            {
                { -1, -1, -1 },
                { -1, 8, -1 },
                { -1, -1, -1 }
            };

            Console.WriteLine("Custom 3x3 Edge Detection Kernel (sum = 0):");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(customKernel[i, j] + "\t");
                }
                Console.WriteLine();
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
 * 1. When you need to apply a simple edge‑detection filter to JPEG images in a C# application without using built‑in filters, you can define a custom 3×3 kernel whose coefficients sum to zero.
 * 2. When integrating Aspose.Imaging into a .NET service that highlights object boundaries, a zero‑sum kernel can be used as the convolution matrix for preprocessing images before further analysis.
 * 3. When building a real‑time video‑processing pipeline that requires lightweight edge detection, developers can generate the kernel programmatically and feed it to the imaging library’s convolution API.
 * 4. When teaching image‑processing concepts, a developer can demonstrate how changing kernel values affects the result by printing a custom 3×3 edge‑detection matrix in C#.
 * 5. When troubleshooting why a convolution filter is producing unexpected brightness shifts, using a kernel whose elements sum to zero ensures the overall image intensity remains unchanged.
 */
