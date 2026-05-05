using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded collection of input image paths
            string[] inputPaths = new string[]
            {
                @"C:\Images\image1.tif",
                @"C:\Images\image2.tif",
                @"C:\Images\image3.tif"
            };

            foreach (var inputPath in inputPaths)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage to apply filters
                    var rasterImage = (RasterImage)image;

                    // Apply the 3x3 sharpen convolution filter to the whole image
                    rasterImage.Filter(
                        rasterImage.Bounds,
                        new ConvolutionFilterOptions(ConvolutionFilter.Sharpen3x3));

                    // Determine output PNG path (same name, .png extension)
                    string outputPath = Path.ChangeExtension(inputPath, ".png");

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the processed image as PNG
                    var pngOptions = new PngOptions();
                    rasterImage.Save(outputPath, pngOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}