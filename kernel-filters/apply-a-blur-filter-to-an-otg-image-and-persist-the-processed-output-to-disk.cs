using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string inputPath = @"C:\Images\input.otg";
        string intermediatePath = @"C:\Images\temp.png";
        string outputPath = @"C:\Images\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(intermediatePath));
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load OTG image and rasterize to PNG
        using (Image otgImage = Image.Load(inputPath))
        {
            // Prepare rasterization options
            OtgRasterizationOptions rasterOptions = new OtgRasterizationOptions
            {
                PageSize = otgImage.Size
            };

            // PNG save options with vector rasterization
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save rasterized PNG
            otgImage.Save(intermediatePath, pngOptions);
        }

        // Load the rasterized PNG, apply Gaussian blur, and save final output
        using (Image image = Image.Load(intermediatePath))
        {
            RasterImage rasterImage = (RasterImage)image;

            // Apply Gaussian blur filter to the whole image
            rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Save blurred image
            PngOptions saveOptions = new PngOptions();
            rasterImage.Save(outputPath, saveOptions);
        }
    }
}