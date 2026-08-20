// HOW-TO: Convert ODG to PNG with Gamma Correction in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "sample.odg";
            string outputPath = "sample.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image
            using (Image odgImage = Image.Load(inputPath))
            {
                // Save ODG to PNG in a memory stream (rasterization)
                using (var memoryStream = new MemoryStream())
                {
                    odgImage.Save(memoryStream, new PngOptions());
                    memoryStream.Position = 0;

                    // Load the rasterized PNG from the memory stream
                    using (Image pngImage = Image.Load(memoryStream))
                    {
                        // Apply gamma correction if the image is a raster image
                        if (pngImage is RasterImage rasterImage)
                        {
                            // Example gamma value; adjust as needed
                            rasterImage.AdjustGamma(2.2f);
                        }

                        // Save the final PNG with gamma correction applied
                        pngImage.Save(outputPath, new PngOptions());
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
 * 1. When you need to display OpenDocument graphics on the web, you can convert the ODG file to a PNG and adjust its gamma for consistent brightness across browsers.
 * 2. When generating thumbnails for a document management system, converting ODG drawings to PNG with gamma correction ensures the preview matches the original appearance.
 * 3. When exporting vector drawings from LibreOffice to a raster format for inclusion in a PDF report, applying gamma correction prevents the image from looking too dark or too light.
 * 4. When building a C# batch‑processing tool that normalizes image brightness, you can load ODG files, rasterize them to PNG, and use AdjustGamma to standardize visual output.
 * 5. When integrating ODG assets into a mobile app that only supports PNG, converting and gamma‑correcting the images guarantees proper brightness on different device screens.
 */
