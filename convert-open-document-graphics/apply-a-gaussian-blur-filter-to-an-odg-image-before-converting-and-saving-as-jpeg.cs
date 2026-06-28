using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.odg";
        string outputPath = @"C:\Images\sample_blur.jpg";

        try
        {
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
                // Rasterize ODG to a memory stream as JPEG
                using (var rasterStream = new MemoryStream())
                {
                    var jpegOptions = new JpegOptions
                    {
                        // Use ODG rasterization options for vector to raster conversion
                        VectorRasterizationOptions = new OdgRasterizationOptions()
                    };
                    odgImage.Save(rasterStream, jpegOptions);
                    rasterStream.Position = 0;

                    // Load the rasterized image
                    using (Image rasterImage = Image.Load(rasterStream))
                    {
                        var raster = (RasterImage)rasterImage;

                        // Apply Gaussian blur filter to the entire image
                        raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                        // Save the processed image as JPEG
                        raster.Save(outputPath);
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
 * 1. When a web application needs to generate low‑resolution preview thumbnails of OpenDocument graphics (ODG) with a soft focus effect before serving them as JPEGs to reduce bandwidth.
 * 2. When an automated document‑processing pipeline must rasterize vector ODG diagrams, apply a Gaussian blur to hide sensitive details, and store the result as a JPEG for archival.
 * 3. When a desktop publishing tool wants to create stylized background images by blurring ODG illustrations and exporting them as JPEG assets for use in newsletters.
 * 4. When a batch‑processing script processes a folder of ODG files, applies a Gaussian blur to simulate depth‑of‑field, and saves the output as JPEGs for inclusion in a product catalog.
 * 5. When a mobile app prepares ODG‑based icons, applies a subtle blur to achieve a consistent visual style, and converts them to JPEG format for faster loading on devices.
 */