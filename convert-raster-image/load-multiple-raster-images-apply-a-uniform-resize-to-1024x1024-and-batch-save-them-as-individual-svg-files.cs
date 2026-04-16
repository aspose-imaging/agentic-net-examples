using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hard‑coded input folder and output folder
        string inputFolder = @"C:\Images\Input";
        string outputFolder = @"C:\Images\Output";

        // List of raster image files to process (hard‑coded)
        string[] inputFiles = new[]
        {
            Path.Combine(inputFolder, "image1.png"),
            Path.Combine(inputFolder, "image2.jpg"),
            Path.Combine(inputFolder, "image3.bmp")
        };

        foreach (string inputPath in inputFiles)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Determine output path (same name, .svg extension, placed in output folder)
            string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".svg";
            string outputPath = Path.Combine(outputFolder, outputFileName);

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the raster image
            using (Image image = Image.Load(inputPath))
            {
                // Resize uniformly to 1024x1024
                image.Resize(1024, 1024);

                // Prepare SVG save options with rasterization settings
                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        // Set the page size to match the resized dimensions
                        PageSize = new Size(1024, 1024)
                    }
                };

                // Save as SVG
                image.Save(outputPath, svgOptions);
            }
        }
    }
}