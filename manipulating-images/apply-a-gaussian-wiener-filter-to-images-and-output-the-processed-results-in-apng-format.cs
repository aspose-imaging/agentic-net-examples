using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.png";
        string outputPath = @"C:\Images\result.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access Filter method
            RasterImage rasterImage = (RasterImage)image;

            // Apply Gauss‑Wiener filter to the whole image (radius 5, sigma 4.0)
            rasterImage.Filter(rasterImage.Bounds, new GaussWienerFilterOptions(5, 4.0));

            // Save as APNG (animated PNG) using PngOptions
            // The file will be saved with .apng extension; Aspose.Imaging treats it as a PNG container.
            rasterImage.Save(outputPath, new PngOptions());
        }
    }
}