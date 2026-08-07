using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\Images\sample.cdr";
        string outputPath = @"C:\Images\sample_muted.gif";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR image
            using (Image cdrImage = Image.Load(inputPath))
            {
                // Rasterize the vector CDR to a PNG stored in memory
                using (var memoryStream = new MemoryStream())
                {
                    cdrImage.Save(memoryStream, new PngOptions());
                    memoryStream.Position = 0; // Reset stream for reading

                    // Load the rasterized image
                    using (Image rasterImage = Image.Load(memoryStream))
                    {
                        // Cast to RasterCachedImage to access AdjustContrast
                        var raster = (RasterCachedImage)rasterImage;

                        // Reduce contrast (negative value reduces contrast)
                        raster.AdjustContrast(-30f);

                        // Verify transparency by scanning pixels for any alpha < 255
                        bool hasTransparency = false;
                        for (int y = 0; y < raster.Height && !hasTransparency; y++)
                        {
                            for (int x = 0; x < raster.Width; x++)
                            {
                                var pixel = raster.GetPixel(x, y);
                                if (pixel.A < 255)
                                {
                                    hasTransparency = true;
                                    break;
                                }
                            }
                        }
                        Console.WriteLine($"Transparency detected: {hasTransparency}");

                        // Save the processed image as GIF
                        var gifOptions = new GifOptions();
                        raster.Save(outputPath, gifOptions);
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
 * 1. When a developer needs to convert a CorelDRAW (CDR) logo to a low‑contrast GIF for a website’s dark theme while ensuring the image retains its transparent background.
 * 2. When an automated build script must rasterize vector CDR assets, mute their contrast for a print‑friendly preview, and verify that no opaque pixels were introduced before publishing.
 * 3. When a marketing application generates animated GIF banners from CDR designs and must reduce contrast to meet brand guidelines and confirm that the original transparency is preserved.
 * 4. When a batch‑processing tool processes user‑uploaded CDR files, applies a subtle contrast reduction to improve readability on low‑resolution screens, and checks for any alpha values less than 255 before saving as GIF.
 * 5. When a desktop utility prepares CDR‑based UI icons for inclusion in an email template, lowering contrast to avoid visual clutter and validating transparency to prevent unwanted background blocks in the final GIF.
 */