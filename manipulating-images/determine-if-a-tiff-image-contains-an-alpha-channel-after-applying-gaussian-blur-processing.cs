using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.tif";
        string outputPath = @"C:\temp\sample_blur.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the TIFF image, apply Gaussian blur, check alpha, and save
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            var tiffImage = (Aspose.Imaging.FileFormats.Tiff.TiffImage)image;

            // Apply Gaussian blur with radius 5 and sigma 4.0
            tiffImage.Filter(
                tiffImage.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

            // Determine if the image has an alpha channel
            bool hasAlpha = tiffImage.HasAlpha;
            Console.WriteLine($"Image has alpha channel: {hasAlpha}");

            // Save the processed image as PNG
            tiffImage.Save(outputPath, new Aspose.Imaging.ImageOptions.PngOptions());
        }
    }
}