// HOW-TO: Convert OTG to PNG with Gamma Correction Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.otg";
            string outputPath = @"C:\Images\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the OTG image
            using (Image otgImage = Image.Load(inputPath))
            {
                // Prepare PNG options with OTG rasterization settings
                PngOptions pngOptions = new PngOptions();
                OtgRasterizationOptions rasterOptions = new OtgRasterizationOptions
                {
                    // Preserve original size
                    PageSize = otgImage.Size
                };
                pngOptions.VectorRasterizationOptions = rasterOptions;

                // Save the rasterized PNG to a temporary file
                string tempPngPath = Path.Combine(Path.GetDirectoryName(outputPath), "temp.png");
                Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));
                otgImage.Save(tempPngPath, pngOptions);

                // Load the rasterized PNG to apply gamma correction
                using (Image pngImage = Image.Load(tempPngPath))
                {
                    // Cast to RasterImage to access AdjustGamma
                    if (pngImage is RasterImage rasterImage)
                    {
                        // Apply gamma correction (example gamma value 2.2)
                        rasterImage.AdjustGamma(2.2f);
                    }

                    // Save the final PNG with gamma correction
                    pngImage.Save(outputPath, new PngOptions());
                }

                // Clean up temporary file
                if (File.Exists(tempPngPath))
                {
                    File.Delete(tempPngPath);
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
 * 1. When you need to display an OpenDocument Graphic (OTG) on the web, converting it to a PNG with proper gamma correction ensures consistent brightness across browsers.
 * 2. When generating thumbnails for a document management system, rasterizing OTG files to PNG and adjusting gamma improves visual quality for preview images.
 * 3. When preparing print‑ready assets from OTG sources, applying gamma correction after conversion to PNG helps match the intended color appearance on printed media.
 * 4. When integrating OTG support into a C# desktop application, using Aspose.Imaging to convert and gamma‑adjust the images simplifies handling of vector graphics.
 * 5. When automating batch processing of design assets, converting multiple OTG files to PNG with gamma correction in a single workflow reduces manual image editing effort.
 */
