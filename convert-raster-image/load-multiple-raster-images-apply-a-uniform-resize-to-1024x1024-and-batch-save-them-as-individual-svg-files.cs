using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

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
                // add more file names as needed
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

                // Load the raster image
                using (Image image = Image.Load(inputPath))
                {
                    // Resize to 1024x1024 (ignoring aspect ratio)
                    image.Resize(1024, 1024);

                    // Prepare SVG save options with rasterization settings
                    var rasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size // set page size to match resized image
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