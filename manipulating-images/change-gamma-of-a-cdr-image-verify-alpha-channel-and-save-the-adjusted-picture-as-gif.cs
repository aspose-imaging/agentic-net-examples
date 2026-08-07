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
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.cdr";
        string outputPath = @"C:\temp\sample_adjusted.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Load the CDR image
            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                // Prepare GIF options with vector rasterization settings
                GifOptions gifOptions = new GifOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        PageWidth = cdr.Width,
                        PageHeight = cdr.Height,
                        BackgroundColor = Aspose.Imaging.Color.White
                    }
                };

                // Rasterize CDR to GIF in memory
                using (MemoryStream ms = new MemoryStream())
                {
                    cdr.Save(ms, gifOptions);
                    ms.Position = 0;

                    // Load the rasterized GIF
                    using (GifImage gif = (GifImage)Image.Load(ms))
                    {
                        // Adjust gamma (example value 2.0f)
                        gif.AdjustGamma(2.0f);

                        // Verify alpha channel presence
                        bool hasAlpha = gif.HasAlpha;
                        Console.WriteLine($"GIF has alpha channel: {hasAlpha}");

                        // Ensure output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the adjusted GIF
                        gif.Save(outputPath, gifOptions);
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
 * 1. When a graphics pipeline must convert CorelDRAW (CDR) vector artwork to a web‑friendly GIF while preserving transparency, a developer can use this code to rasterize the CDR, check for an alpha channel, and save the result.
 * 2. When an e‑commerce platform needs to adjust the brightness of product illustrations stored as CDR files before displaying them as animated GIFs, the gamma adjustment in this snippet provides a quick way to fine‑tune visual intensity.
 * 3. When a digital publishing system imports legacy CDR assets and must ensure they contain an alpha channel for overlay effects in newsletters, the code’s HasAlpha check validates transparency before outputting the GIF.
 * 4. When an automated batch job processes a folder of CorelDRAW designs, applies a consistent gamma correction, and stores the processed images as GIFs for email marketing campaigns, this example shows the necessary C# steps.
 * 5. When a UI designer wants to preview a CDR illustration with corrected gamma on a low‑color‑depth display, the code rasterizes the vector file, adjusts gamma, confirms alpha support, and saves a lightweight GIF for quick testing.
 */