using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.cdr";
        string outputPath = @"C:\Images\sample_blurred.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CDR image
        using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
        {
            // Rasterize the vector CDR image to a PNG using rasterization options
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = new CdrRasterizationOptions()
            };

            // Save the rasterized image to the output path (initial PNG)
            cdrImage.Save(outputPath, pngOptions);
        }

        // Load the rasterized PNG image
        using (RasterImage rasterImage = (RasterImage)Image.Load(outputPath))
        {
            // Apply Gaussian blur filter to the entire image
            rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Save the blurred image, overwriting the previous file
            rasterImage.Save(outputPath);
        }
    }
}