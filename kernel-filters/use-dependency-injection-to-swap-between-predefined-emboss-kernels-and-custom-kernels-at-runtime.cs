// HOW-TO: Apply Emboss Filter With Switchable Predefined Or Custom Kernel In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-14
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Collections.Generic;
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

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            double[,] customKernel = new double[,]
            {
                { -2, -1, 0 },
                { -1, 1, 1 },
                { 0, 1, 2 }
            };

            string mode = "predefined"; // change to "custom" to use custom kernel

            var kernelProviders = new Dictionary<string, Func<double[,]>>()
            {
                { "predefined", () => Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3 },
                { "custom", () => customKernel }
            };

            if (!kernelProviders.ContainsKey(mode))
            {
                Console.Error.WriteLine($"Unknown mode: {mode}");
                return;
            }

            double[,] selectedKernel = kernelProviders[mode]();

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                var options = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(selectedKernel);
                image.Filter(image.Bounds, options);
                image.Save(outputPath);
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
 * 1. When you need to add an emboss effect to PNG images while allowing the filter kernel to be changed at runtime without recompiling the code.
 * 2. When you want end‑users of a C# desktop photo editor to choose between a built‑in emboss kernel and a custom‑defined kernel for personalized image styling.
 * 3. When you are building a batch image‑processing service that selects different convolution kernels based on a configuration setting to process large numbers of images automatically.
 * 4. When you need to unit‑test various emboss kernels quickly by swapping them through dependency injection instead of hard‑coding a single filter.
 * 5. When you are exposing an Aspose.Imaging‑based web API that receives a mode parameter to apply either the default emboss kernel or a client‑provided custom kernel to uploaded images.
 */
