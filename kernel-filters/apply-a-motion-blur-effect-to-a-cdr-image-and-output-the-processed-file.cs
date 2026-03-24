using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.cdr";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CDR vector image
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            var cdrImage = (Aspose.Imaging.FileFormats.Cdr.CdrImage)image;

            // Rasterize CDR to a PNG in memory
            using (var memoryStream = new MemoryStream())
            {
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new CdrRasterizationOptions
                    {
                        PageWidth = cdrImage.Width,
                        PageHeight = cdrImage.Height
                    }
                };
                cdrImage.Save(memoryStream, pngOptions);
                memoryStream.Position = 0;

                // Load the rasterized image
                using (Aspose.Imaging.Image rasterImageContainer = Aspose.Imaging.Image.Load(memoryStream))
                {
                    var rasterImage = (Aspose.Imaging.RasterImage)rasterImageContainer;

                    // Apply motion wiener (motion blur) filter
                    rasterImage.Filter(
                        rasterImage.Bounds,
                        new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(10, 1.0, 90.0));

                    // Save the processed image
                    rasterImage.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}