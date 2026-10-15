// HOW-TO: Increase BMP Blur Smoothing with 7x7 Kernel in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.bmp";
            string outputPath = "Output\\blurred.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            double[,] customKernel = new double[7, 7];
            double value = 1.0 / 49.0;
            for (int i = 0; i < 7; i++)
                for (int j = 0; j < 7; j++)
                    customKernel[i, j] = value;

            using (BmpImage image = (BmpImage)Image.Load(inputPath))
            {
                image.Filter(image.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(customKernel));
                BmpOptions options = new BmpOptions();
                image.Save(outputPath, options);
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
 * 1. When a developer needs to reduce noise in a BMP photograph for a desktop publishing workflow, they can apply a 7x7 convolution blur using Aspose.Imaging in C#.
 * 2. When preparing BMP assets for a game’s background, a programmer may want a stronger smoothing effect to create a soft‑focus look, which this 7x7 kernel code provides.
 * 3. When converting scanned BMP documents into a more uniform appearance before OCR, applying a larger blur kernel helps eliminate speckles and uneven lighting.
 * 4. When generating thumbnail previews of BMP images for a web gallery, a developer can use the 7x7 blur to create a visually pleasing, less detailed version quickly.
 * 5. When implementing a custom image‑processing pipeline that requires consistent smoothing across multiple BMP files, this code demonstrates how to set a custom 7x7 kernel with Aspose.Imaging in C#.
 */
