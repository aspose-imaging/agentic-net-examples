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
            string inputPath = @"C:\Images\sample.cdr";
            string outputPath = @"C:\Images\adjusted.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR image
            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                // Prepare GIF options with vector rasterization settings matching the CDR size
                GifOptions rasterOptions = new GifOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        PageWidth = cdr.Width,
                        PageHeight = cdr.Height
                    }
                };

                // Rasterize CDR to GIF in memory
                using (MemoryStream ms = new MemoryStream())
                {
                    cdr.Save(ms, rasterOptions);
                    ms.Position = 0;

                    // Load the rasterized GIF
                    using (GifImage gif = (GifImage)Image.Load(ms))
                    {
                        // Adjust gamma (example value)
                        gif.AdjustGamma(2.2f);

                        // Verify alpha channel presence
                        bool hasAlpha = gif.HasAlpha;
                        Console.WriteLine($"GIF has alpha channel: {hasAlpha}");

                        // Save the adjusted GIF to the output path
                        gif.Save(outputPath, new GifOptions());
                    }
                }
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
 * 1. When a developer needs to convert a CorelDRAW (CDR) illustration to a web‑friendly GIF, apply gamma correction for accurate brightness, and confirm that the resulting GIF retains its alpha channel for transparent overlays.
 * 2. When an automated image‑processing pipeline must batch‑process CDR files, rasterize them to GIF with the original dimensions, adjust the gamma to standardize color appearance, and verify alpha channel presence before publishing.
 * 3. When a UI designer wants to preview a CDR logo as a GIF with corrected gamma for on‑screen consistency and programmatically ensure the GIF includes an alpha channel for compositing.
 * 4. When a content‑management system integrates Aspose.Imaging for .NET to ingest vector CDR assets, convert them to GIF using VectorRasterizationOptions, apply a 2.2 gamma curve, and check for alpha support before storing the files.
 * 5. When a developer builds a desktop tool that loads a CDR image, rasterizes it to a same‑size GIF, performs gamma adjustment to compensate for display differences, and validates the presence of an alpha channel to guarantee proper blending in downstream applications.
 */