using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string inputCdrPath = @"C:\Images\input.cdr";
        string tempPngPath = @"C:\Images\temp.png";
        string outputPngPath = @"C:\Images\output.png";

        // Verify input file exists
        if (!File.Exists(inputCdrPath))
        {
            Console.Error.WriteLine($"File not found: {inputCdrPath}");
            return;
        }

        // Ensure directory for temporary PNG exists
        Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));

        // Load CDR and export to temporary PNG
        using (Image cdrImage = Image.Load(inputCdrPath))
        {
            cdrImage.Save(tempPngPath, new PngOptions());
        }

        // Ensure directory for final output exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPngPath));

        // Load the temporary PNG, apply Gaussian blur, resize, and save final PNG
        using (Image pngImage = Image.Load(tempPngPath))
        {
            var raster = (RasterImage)pngImage;

            // Apply Gaussian blur filter to the whole image
            var blurOptions = new GaussianBlurFilterOptions(5, 4.0);
            raster.Filter(raster.Bounds, blurOptions);

            // Resize to 1200x800 using default resampling
            raster.Resize(1200, 800);

            // Save the processed image as PNG
            raster.Save(outputPngPath, new PngOptions());
        }
    }
}