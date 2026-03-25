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
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image, set background transparent, apply median filter, and save as PDF
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for pixel manipulation and filtering
            RasterImage rasterImage = (RasterImage)image;

            // Replace all non‑transparent colors with transparent (makes background transparent)
            rasterImage.ReplaceNonTransparentColors(Color.Transparent);

            // Apply a median filter with size 5 to the whole image
            rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

            // Save the processed image as PDF
            rasterImage.Save(outputPath, new PdfOptions());
        }
    }
}