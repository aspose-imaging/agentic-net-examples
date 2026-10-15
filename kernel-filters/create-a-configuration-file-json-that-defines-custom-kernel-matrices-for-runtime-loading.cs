// HOW-TO: Create JSON Kernel Configuration File for Custom Image Filters in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "Config/kernelConfig.json";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            var kernels = new Dictionary<string, double[,]>
            {
                { "MotionBlur5x5", new double[,] {
                    {0.25, 0, 0, 0, 0},
                    {0, 0.2, 0, 0, 0},
                    {0, 0, 0.1, 0, 0},
                    {0, 0, 0, 0.2, 0},
                    {0, 0, 0, 0, 0.25}
                }},
                { "Emboss3x3", new double[,] {
                    {-2, -1, 0},
                    {-1, 1, 1},
                    {0, 1, 2}
                }},
                { "Sharpen3x3", new double[,] {
                    {0, -1, 0},
                    {-1, 5, -1},
                    {0, -1, 0}
                }},
                { "BlurBox5x5", new double[,] {
                    {0.04,0.04,0.04,0.04,0.04},
                    {0.04,0.04,0.04,0.04,0.04},
                    {0.04,0.04,0.04,0.04,0.04},
                    {0.04,0.04,0.04,0.04,0.04},
                    {0.04,0.04,0.04,0.04,0.04}
                }},
                { "EdgeDetection3x3", new double[,] {
                    {-1,-1,-1},
                    {-1,8,-1},
                    {-1,-1,-1}
                }}
            };

            using (var writer = new StreamWriter(outputPath))
            {
                writer.WriteLine("{");
                writer.WriteLine("  \"kernels\": {");
                int processed = 0;
                foreach (var kvp in kernels)
                {
                    writer.WriteLine($"    \"{kvp.Key}\": [");
                    int rows = kvp.Value.GetLength(0);
                    int cols = kvp.Value.GetLength(1);
                    for (int i = 0; i < rows; i++)
                    {
                        writer.Write("      [");
                        for (int j = 0; j < cols; j++)
                        {
                            writer.Write(kvp.Value[i, j].ToString(System.Globalization.CultureInfo.InvariantCulture));
                            if (j < cols - 1) writer.Write(", ");
                        }
                        writer.Write("]");
                        if (i < rows - 1) writer.WriteLine(",");
                        else writer.WriteLine();
                    }
                    writer.Write("    ]");
                    processed++;
                    if (processed < kernels.Count) writer.WriteLine(",");
                    else writer.WriteLine();
                }
                writer.WriteLine("  }");
                writer.WriteLine("}");
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
 * 1. When you want to define reusable convolution kernels like blur or sharpen and load them at runtime for Aspose.Imaging processing.
 * 2. When you need to store multiple custom filter matrices in a single JSON file to share across different .NET projects.
 * 3. When you want to let end‑users modify kernel values without recompiling the application, enabling dynamic image effects.
 * 4. When you are building a batch image‑processing pipeline that reads kernel definitions from a config file to apply consistent transformations.
 * 5. When you need to version‑control and document your custom convolution filters alongside source code for easier maintenance.
 */
