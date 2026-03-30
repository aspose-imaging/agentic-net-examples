using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.png";

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
            // If the image supports multiple pages, process each page
            if (image is IMultipageImage multipageImage)
            {
                for (int i = 0; i < multipageImage.PageCount; i++)
                {
                    // Each page is a RasterImage
                    var page = (RasterImage)multipageImage.Pages[i];
                    // Apply Emboss3x3 filter to the entire page
                    page.Filter(page.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));
                }
            }
            else if (image is RasterImage rasterImage)
            {
                // Single-page image: apply filter directly
                rasterImage.Filter(rasterImage.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));
            }

            // Save the processed image as PNG
            PngOptions options = new PngOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };
            image.Save(outputPath, options);
        }
    }
}