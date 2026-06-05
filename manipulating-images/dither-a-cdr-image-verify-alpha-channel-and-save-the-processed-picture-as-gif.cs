using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.cdr";
            string outputPath = "output.gif";

            // Validate input file existence
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
                // Rasterize CDR to PNG in memory
                using (MemoryStream ms = new MemoryStream())
                {
                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            PageWidth = cdr.Width,
                            PageHeight = cdr.Height
                        }
                    };
                    cdr.Save(ms, pngOptions);
                    ms.Position = 0;

                    // Load rasterized image
                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        // Verify presence of alpha channel
                        bool hasAlpha = false;
                        int[] argbPixels = raster.LoadArgb32Pixels(raster.Bounds);
                        foreach (int argb in argbPixels)
                        {
                            int alpha = (argb >> 24) & 0xFF;
                            if (alpha < 255)
                            {
                                hasAlpha = true;
                                break;
                            }
                        }
                        Console.WriteLine($"Alpha channel present: {hasAlpha}");

                        // Apply dithering (Floyd‑Steinberg, 1‑bit)
                        raster.Dither(DitheringMethod.FloydSteinbergDithering, 1);

                        // Save as GIF
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
 * 1. When a designer needs to convert a CorelDRAW (.cdr) vector illustration into a web‑friendly GIF while verifying that any transparent regions are correctly detected before dithering.
 * 2. When an e‑commerce platform must generate low‑size product thumbnails from CDR files, confirm the presence of an alpha channel, and then dither the image for optimal GIF compression.
 * 3. When a marketing automation script batch‑processes corporate brand assets, converting CDR logos to GIFs for email campaigns and checking the alpha channel to avoid unexpected opaque backgrounds.
 * 4. When a desktop publishing tool integrates Aspose.Imaging to allow users to export their CDR artwork as GIFs with dithering for legacy printers, ensuring the image’s transparency is correctly identified.
 * 5. When a mobile app backend receives user‑uploaded CDR files, rasterizes them, validates transparency, applies dithering, and stores the result as a GIF for fast delivery to low‑bandwidth devices.
 */