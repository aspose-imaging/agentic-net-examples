using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output_sharpened.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for filtering
            RasterImage rasterImage = (RasterImage)image;

            // Apply a custom sharpen kernel derived from the emboss matrix
            var convolutionOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3);
            rasterImage.Filter(rasterImage.Bounds, convolutionOptions);

            // Save the result as PNG
            var pngOptions = new PngOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };
            image.Save(outputPath, pngOptions);
        }
    }
}