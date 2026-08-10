// HOW-TO: Batch Resize Multiple Raster Images to 1024x1024 and Save as SVG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = @"C:\Images\Input";
            string outputDir = @"C:\Images\Output";

            // List of raster image file names to process
            string[] files = new[]
            {
                "image1.png",
                "image2.jpg",
                "image3.bmp"
            };

            foreach (string fileName in files)
            {
                // Build full input and output paths
                string inputPath = Path.Combine(inputDir, fileName);
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(fileName) + ".svg");

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load raster image, resize, and save as SVG
                using (Image image = Image.Load(inputPath))
                {
                    // Resize to 1024x1024
                    image.Resize(1024, 1024);

                    // Prepare SVG save options with rasterization settings
                    var rasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size // after resize this is 1024x1024
                    };

                    var svgOptions = new SvgOptions
                    {
                        VectorRasterizationOptions = rasterizationOptions
                    };

                    // Save as SVG
                    image.Save(outputPath, svgOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate scalable SVG versions of a set of product photos for a web catalog, resizing each to a uniform 1024×1024 size.
 * 2. When preparing icons for a mobile app, you can batch convert PNG, JPG, and BMP files to SVG while ensuring consistent dimensions.
 * 3. When automating a design workflow that requires raster images to be vectorized for printing, this code resizes and saves each image as an SVG file.
 * 4. When migrating legacy image assets to a responsive UI, you can use the script to standardize size and output SVGs that scale without loss of quality.
 * 5. When building a CI/CD pipeline that processes image assets, the code batch processes multiple formats, resizes them, and stores them as SVGs for downstream consumption.
 */
