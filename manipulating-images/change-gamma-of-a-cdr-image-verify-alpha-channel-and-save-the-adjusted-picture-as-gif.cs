using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\sample.cdr";
            string outputPath = @"C:\temp\adjusted.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load CDR image
            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                // Prepare GIF options with vector rasterization settings
                GifOptions gifOptions = new GifOptions
                {
                    VectorRasterizationOptions = new CdrRasterizationOptions
                    {
                        PageWidth = cdr.Width,
                        PageHeight = cdr.Height
                    }
                };

                // Save rasterized GIF
                cdr.Save(outputPath, gifOptions);
            }

            // Load the generated GIF to adjust gamma and verify alpha channel
            using (GifImage gif = (GifImage)Image.Load(outputPath))
            {
                // Verify if the GIF has an alpha channel
                bool hasAlpha = gif.HasAlpha;
                Console.WriteLine($"GIF has alpha channel: {hasAlpha}");

                // Adjust gamma (example value 2.0)
                gif.AdjustGamma(2.0f);

                // Save the adjusted GIF (overwrite)
                gif.Save(outputPath, new GifOptions());
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
 * 1. When a developer needs to convert a CorelDRAW CDR illustration to a GIF, verify that the resulting image retains its alpha channel for transparency, and adjust the gamma to improve brightness, this code provides a complete solution.
 * 2. When building an automated workflow that rasterizes CDR assets into GIFs for web publishing, checks for an alpha channel to preserve transparent backgrounds, and applies gamma correction to match display standards, the example can be used directly.
 * 3. When creating a batch‑processing tool that ingests multiple CDR files, converts each to a GIF, confirms the presence of an alpha channel for overlay use, and fine‑tunes gamma to ensure consistent visual quality, this code demonstrates the required steps.
 * 4. When integrating Aspose.Imaging into a C# application that must accept user‑uploaded CDR graphics, render them as GIFs, validate that the GIF includes an alpha channel, and adjust gamma to compensate for low‑contrast screens, the provided snippet shows how to achieve it.
 * 5. When developing a desktop utility for designers to preview CorelDRAW drawings as GIFs, verify transparency via the alpha channel, and apply gamma adjustments for accurate color representation before exporting, this code offers a ready‑to‑use implementation.
 */