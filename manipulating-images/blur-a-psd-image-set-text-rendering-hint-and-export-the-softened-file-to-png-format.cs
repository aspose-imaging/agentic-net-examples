using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.psd";
        string outputPath = @"C:\Images\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PSD image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for filtering
            RasterImage raster = image as RasterImage;
            if (raster == null)
            {
                Console.Error.WriteLine("The loaded image is not a raster image and cannot be processed.");
                return;
            }

            // Apply Gaussian blur filter to the entire image
            raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Prepare PNG export options with text rendering hint
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel
                }
            };

            // Save the blurred image as PNG
            raster.Save(outputPath, pngOptions);
        }
    }
}