// HOW-TO: Apply Normalized Custom Convolution Filter to PNG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-14
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "template.png";
            string outputPath = "output\\result.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            double[,] customKernel = new double[,]
            {
                { 0.25, 0,    0,    0,    0    },
                { 0,    0.2,  0,    0,    0    },
                { 0,    0,    0.1,  0,    0    },
                { 0,    0,    0,    0.2,  0    },
                { 0,    0,    0,    0,    0.25 }
            };

            double sum = 0;
            for (int i = 0; i < customKernel.GetLength(0); i++)
            {
                for (int j = 0; j < customKernel.GetLength(1); j++)
                {
                    sum += customKernel[i, j];
                }
            }

            if (sum != 0)
            {
                for (int i = 0; i < customKernel.GetLength(0); i++)
                {
                    for (int j = 0; j < customKernel.GetLength(1); j++)
                    {
                        customKernel[i, j] /= sum;
                    }
                }
            }

            using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
            {
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(customKernel));

                PngOptions options = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                raster.Save(outputPath, options);
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
 * 1. When you need to apply a custom blur or sharpening effect to a PNG template while ensuring the filter coefficients sum to one, this code normalizes the kernel and runs a convolution filter using Aspose.Imaging in C#.
 * 2. When generating thumbnails that require a specific weighted smoothing operation, you can load the source PNG, normalize a custom kernel, apply the convolution, and save the processed image.
 * 3. When implementing a scientific image analysis pipeline that demands precise control over the convolution matrix, this example shows how to compute the kernel sum, normalize it, and apply it to a raster image in .NET.
 * 4. When creating a watermark or texture overlay where the underlying PNG must be subtly blended using a custom filter, the code demonstrates loading the image, applying a normalized convolution, and exporting the result.
 * 5. When building an automated graphics workflow that processes batch PNG files with a user‑defined filter, the snippet provides the steps to load each file, normalize the kernel, apply the filter, and save the output with Aspose.Imaging.
 */
