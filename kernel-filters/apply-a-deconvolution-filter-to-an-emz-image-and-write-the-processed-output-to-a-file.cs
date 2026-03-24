using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.emz";
        string outputPath = @"C:\temp\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Temporary rasterized PNG path
        string tempPngPath = Path.Combine(Path.GetDirectoryName(outputPath), "temp.png");
        Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));

        // Load the EMZ (vector) image and rasterize to PNG
        using (Image vectorImage = Image.Load(inputPath))
        {
            var vectorOptions = new EmfRasterizationOptions
            {
                PageSize = vectorImage.Size,
                BackgroundColor = Color.White
            };

            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = vectorOptions
            };

            vectorImage.Save(tempPngPath, pngOptions);
        }

        // Load the rasterized PNG, apply deconvolution filter, and save the result
        using (Image rasterImageContainer = Image.Load(tempPngPath))
        {
            var rasterImage = (RasterImage)rasterImageContainer;

            // Apply a motion deconvolution filter (MotionWienerFilterOptions)
            var deconvOptions = new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(10, 1.0, 90.0);
            rasterImage.Filter(rasterImage.Bounds, deconvOptions);

            // Save the processed image as PNG
            var outOptions = new PngOptions();
            rasterImage.Save(outputPath, outOptions);
        }

        // Optionally delete the temporary file
        try
        {
            File.Delete(tempPngPath);
        }
        catch
        {
            // Ignore any errors during cleanup
        }
    }
}