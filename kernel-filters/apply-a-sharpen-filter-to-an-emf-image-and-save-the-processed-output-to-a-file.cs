using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\input.emf";
        string outputPath = @"c:\temp\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EMF image
        using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
        {
            // Rasterize EMF to PNG in memory
            var rasterOptions = new EmfRasterizationOptions { PageSize = emfImage.Size };
            var pngOptions = new PngOptions { VectorRasterizationOptions = rasterOptions };

            using (var memoryStream = new MemoryStream())
            {
                emfImage.Save(memoryStream, pngOptions);
                memoryStream.Position = 0;

                // Load the rasterized image
                using (RasterImage rasterImage = (RasterImage)Image.Load(memoryStream))
                {
                    // Apply Sharpen filter to the whole image
                    rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));

                    // Save the processed image
                    rasterImage.Save(outputPath);
                }
            }
        }
    }
}