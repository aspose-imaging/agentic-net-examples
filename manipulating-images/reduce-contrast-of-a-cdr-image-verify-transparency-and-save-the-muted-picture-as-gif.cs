// HOW-TO: Reduce Contrast of CDR Image, Check Transparency and Save as GIF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.cdr";
            string outputPath = "output.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR image
            using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
            {
                // Rasterize the vector CDR image to a PNG stored in memory
                using (MemoryStream pngStream = new MemoryStream())
                {
                    cdrImage.Save(pngStream, new PngOptions());
                    pngStream.Position = 0; // Reset stream for reading

                    // Load the rasterized image
                    using (RasterCachedImage rasterImage = (RasterCachedImage)Image.Load(pngStream))
                    {
                        // Simple transparency check based on pixel format (32 bpp implies alpha channel)
                        bool hasTransparency = rasterImage.BitsPerPixel == 32;
                        Console.WriteLine($"Transparency detected: {hasTransparency}");

                        // Reduce contrast (negative value lowers contrast)
                        rasterImage.AdjustContrast(-30f);

                        // Save the result as a GIF
                        GifOptions gifOptions = new GifOptions();
                        rasterImage.Save(outputPath, gifOptions);
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
 * 1. When you need to convert a CorelDRAW (CDR) vector file to a GIF for web use while ensuring any alpha channel is preserved.
 * 2. When you want to programmatically lower the contrast of a CDR‑derived image to create a muted visual effect before publishing.
 * 3. When you must verify whether a rasterized CDR image contains transparency before applying further processing steps.
 * 4. When an automated workflow requires converting CDR files to a GIF format that supports animation or limited color palettes.
 * 5. When you are building a batch image‑processing tool that adjusts contrast and outputs GIFs from multiple CDR sources.
 */
