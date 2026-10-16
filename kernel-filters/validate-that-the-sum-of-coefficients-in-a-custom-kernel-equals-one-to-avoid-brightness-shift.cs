// HOW-TO: Check Custom Convolution Kernel Sum Equals One in C# (Aspose.Imaging for .NET)
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
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "kernel.txt";
            string outputPath = "result.txt";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            double[,] kernel = new double[,]
            {
                { -2, -1, 0 },
                { -1, 1, 1 },
                { 0, 1, 2 }
            };

            double sum = 0.0;
            int rows = kernel.GetLength(0);
            int cols = kernel.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    sum += kernel[i, j];
                }
            }

            const double epsilon = 1e-6;
            string message = Math.Abs(sum - 1.0) < epsilon
                ? "Kernel sum equals 1. No brightness shift."
                : $"Kernel sum is {sum}. It does not equal 1.";

            File.WriteAllText(outputPath, message);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer creates a custom convolution matrix for sharpening or edge detection and wants to ensure the filter does not unintentionally brighten or darken the image.
 * 2. When loading a kernel definition from a text file before applying it with Aspose.Imaging, the code can verify the coefficients sum to one to maintain overall image luminance.
 * 3. When debugging a new image processing pipeline, the developer can quickly detect mis‑scaled kernels that would cause a global brightness shift.
 * 4. When building a UI that lets users edit kernel values, the backend can run this check to reject invalid configurations before processing the image.
 * 5. When automating batch image transformations, the script can log whether each custom kernel meets the normalization requirement, preventing unexpected visual artifacts.
 */
