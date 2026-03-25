using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input folder containing raster images
        string inputFolder = @"C:\Images\Input";
        // Hardcoded output folder for SVG files
        string outputFolder = @"C:\Images\Output";

        // List of raster image file names to process
        string[] files = new[]
        {
            "image1.jpg",
            "image2.png",
            "image3.bmp"
        };

        foreach (var fileName in files)
        {
            // Build full input path
            string inputPath = Path.Combine(inputFolder, fileName);
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Build full output path (same name with .svg extension)
            string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(fileName) + ".svg");
            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load raster image
            using (Image image = Image.Load(inputPath))
            {
                // Resize to 1024x1024
                image.Resize(1024, 1024);

                // Prepare SVG rasterization options (use the resized image size)
                var vectorOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Prepare SVG save options
                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = vectorOptions
                };

                // Save as SVG
                image.Save(outputPath, svgOptions);
            }
        }
    }
}