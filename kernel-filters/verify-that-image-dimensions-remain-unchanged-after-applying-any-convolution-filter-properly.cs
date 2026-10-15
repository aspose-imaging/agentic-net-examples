// HOW-TO: Verify Image Size Stays Same After Applying Convolution Filter in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output/output.jpg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                int originalWidth = image.Width;
                int originalHeight = image.Height;

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                    Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3);

                image.Filter(image.Bounds, filterOptions);

                if (image.Width != originalWidth || image.Height != originalHeight)
                {
                    Console.Error.WriteLine("Image dimensions changed after filter.");
                }

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
 * 1. When you need to apply an emboss effect to a JPEG while ensuring the original width and height are preserved for downstream layout calculations.
 * 2. When validating that custom image filters in an Aspose.Imaging C# pipeline do not unintentionally resize images before saving them to a web server.
 * 3. When creating a batch processing tool that adds artistic convolution filters to photos but must keep the pixel dimensions unchanged for consistent thumbnail generation.
 * 4. When debugging an image processing routine to confirm that applying any Aspose.Imaging convolution filter (e.g., Emboss3x3) does not alter the raster image’s dimensions before further analysis.
 * 5. When integrating Aspose.Imaging into a .NET application that requires dimension checks after filtering to avoid breaking UI components that rely on fixed image sizes.
 */
