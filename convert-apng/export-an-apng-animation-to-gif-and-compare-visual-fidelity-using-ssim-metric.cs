// HOW-TO: Convert APNG animation to GIF and evaluate SSIM similarity in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string apngPath = Path.Combine(inputDirectory, "animation.apng");
            string gifPath = Path.Combine(outputDirectory, "animation_converted.gif");

            if (!File.Exists(apngPath))
            {
                Console.Error.WriteLine($"File not found: {apngPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(gifPath));

            // Convert APNG to GIF
            using (Image apngImage = Image.Load(apngPath))
            {
                apngImage.Save(gifPath, new GifOptions());
            }

            // Load original APNG and converted GIF as raster images for SSIM calculation
            using (RasterImage originalRaster = (RasterImage)Image.Load(apngPath))
            using (RasterImage gifRaster = (RasterImage)Image.Load(gifPath))
            {
                int width = Math.Min(originalRaster.Width, gifRaster.Width);
                int height = Math.Min(originalRaster.Height, gifRaster.Height);

                int[] origPixels = new int[originalRaster.Width * originalRaster.Height];
                originalRaster.SaveArgb32Pixels(new Rectangle(0, 0, originalRaster.Width, originalRaster.Height), origPixels);

                int[] gifPixels = new int[gifRaster.Width * gifRaster.Height];
                gifRaster.SaveArgb32Pixels(new Rectangle(0, 0, gifRaster.Width, gifRaster.Height), gifPixels);

                // Truncate to common size if needed
                int[] origCropped = new int[width * height];
                int[] gifCropped = new int[width * height];

                for (int y = 0; y < height; y++)
                {
                    Array.Copy(origPixels, y * originalRaster.Width, origCropped, y * width, width);
                    Array.Copy(gifPixels, y * gifRaster.Width, gifCropped, y * width, width);
                }

                // Convert to luminance
                double[] lumOrig = new double[origCropped.Length];
                double[] lumGif = new double[gifCropped.Length];

                for (int i = 0; i < origCropped.Length; i++)
                {
                    int argb1 = origCropped[i];
                    int r1 = (argb1 >> 16) & 0xFF;
                    int g1 = (argb1 >> 8) & 0xFF;
                    int b1 = argb1 & 0xFF;
                    lumOrig[i] = 0.299 * r1 + 0.587 * g1 + 0.114 * b1;

                    int argb2 = gifCropped[i];
                    int r2 = (argb2 >> 16) & 0xFF;
                    int g2 = (argb2 >> 8) & 0xFF;
                    int b2 = argb2 & 0xFF;
                    lumGif[i] = 0.299 * r2 + 0.587 * g2 + 0.114 * b2;
                }

                // Compute means
                double meanOrig = lumOrig.Average();
                double meanGif = lumGif.Average();

                // Compute variances and covariance
                double varOrig = 0.0;
                double varGif = 0.0;
                double cov = 0.0;

                for (int i = 0; i < lumOrig.Length; i++)
                {
                    double diffOrig = lumOrig[i] - meanOrig;
                    double diffGif = lumGif[i] - meanGif;
                    varOrig += diffOrig * diffOrig;
                    varGif += diffGif * diffGif;
                    cov += diffOrig * diffGif;
                }

                varOrig /= (lumOrig.Length - 1);
                varGif /= (lumGif.Length - 1);
                cov /= (lumOrig.Length - 1);

                // SSIM constants
                const double K1 = 0.01;
                const double K2 = 0.03;
                const double L = 255.0;
                double C1 = (K1 * L) * (K1 * L);
                double C2 = (K2 * L) * (K2 * L);

                double numerator = (2 * meanOrig * meanGif + C1) * (2 * cov + C2);
                double denominator = (meanOrig * meanOrig + meanGif * meanGif + C1) * (varOrig + varGif + C2);
                double ssim = numerator / denominator;

                Console.WriteLine($"SSIM between original APNG and converted GIF: {ssim:F4}");
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
 * 1. When you need to downgrade an animated PNG to a GIF for compatibility with older browsers while checking that the visual quality loss is acceptable.
 * 2. When you are building a batch conversion tool that creates GIF previews of APNG files and wants to automatically flag conversions with low structural similarity.
 * 3. When you integrate image assets into a game engine that only supports GIF animations and must verify that the converted frames remain faithful to the original APNG.
 * 4. When you run automated tests that compare the output of an APNG‑to‑GIF conversion pipeline against the source using the SSIM metric to ensure consistent rendering.
 * 5. When you generate lightweight GIF versions of user‑uploaded APNGs for email newsletters and need a quick C# script to measure any perceptual degradation.
 */
