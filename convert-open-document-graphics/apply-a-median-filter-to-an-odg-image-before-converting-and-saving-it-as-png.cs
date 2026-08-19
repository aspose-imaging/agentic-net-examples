// HOW-TO: Apply Median Filter to ODG Image and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "sample.odg";
            string outputPath = "sample_filtered.png";

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
                // Rasterize ODG to a PNG in memory
                using (var memoryStream = new MemoryStream())
                {
                    var rasterizationOptions = new OdgRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageSize = odgImage.Size
                    };

                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterizationOptions
                    };

                    odgImage.Save(memoryStream, pngOptions);
                    memoryStream.Position = 0;

                    // Load the rasterized image as a RasterImage to apply the median filter
                    using (Image rasterImage = Image.Load(memoryStream))
                    {
                        var raster = (RasterImage)rasterImage;

                        // Apply median filter with size 5 to the whole image
                        raster.Filter(raster.Bounds, new MedianFilterOptions(5));

                        // Save the filtered image as PNG
                        raster.Save(outputPath, new PngOptions());
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
 * 1. When you need to reduce noise in a scanned ODG diagram before exporting it as a high‑quality PNG for web publishing.
 * 2. When you want to preprocess vector‑based ODG drawings with a median filter to improve visual clarity in a PNG thumbnail generator.
 * 3. When an application must convert OpenDocument graphics to PNG while applying a smoothing filter to meet printing specifications.
 * 4. When you are building a batch conversion tool that rasterizes ODG files and removes speckle artifacts before saving them as PNG assets.
 * 5. When you require server‑side image processing in C# to clean up ODG illustrations and store the filtered results as PNG files for further analysis.
 */
