using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.otg";
        string outputPath = @"C:\Images\sample.filtered.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the OTG image
            using (Image otgImage = Image.Load(inputPath))
            {
                // Prepare PNG save options with OTG rasterization settings
                var pngOptions = new PngOptions();
                var otgRasterization = new OtgRasterizationOptions
                {
                    PageSize = otgImage.Size
                };
                pngOptions.VectorRasterizationOptions = otgRasterization;

                // Rasterize OTG to a memory stream as PNG
                using (var memoryStream = new MemoryStream())
                {
                    otgImage.Save(memoryStream, pngOptions);
                    memoryStream.Position = 0;

                    // Load the rasterized PNG image
                    using (Image rasterImg = Image.Load(memoryStream))
                    {
                        var rasterImage = (RasterImage)rasterImg;

                        // Apply median filter to the whole image
                        rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

                        // Save the filtered image as PNG
                        rasterImage.Save(outputPath);
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
 * 1. When a developer needs to clean up noise in a vector‑based OTG diagram before delivering a high‑quality PNG thumbnail for a web gallery.
 * 2. When an engineering application must rasterize an OTG schematic, apply a median filter to smooth jagged edges, and save the result as a PNG for inclusion in a PDF report.
 * 3. When a medical imaging system receives OTG annotations, filters out speckle artifacts with a median filter, and stores the cleaned image as PNG for electronic health records.
 * 4. When a GIS tool converts OTG map layers to PNG tiles, uses a median filter to reduce pixel‑level noise caused by rasterization, and writes the tiles to disk.
 * 5. When an e‑learning platform processes OTG illustrations, applies a median filter to improve visual clarity, and saves the final PNG for responsive mobile delivery.
 */