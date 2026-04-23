using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        // Define relative input and output directories
        string inputDirectory = "Input";
        string outputDirectory = "Output";

        // Ensure input directory exists before enumerating files
        if (!Directory.Exists(inputDirectory))
        {
            Directory.CreateDirectory(inputDirectory);
            Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
            return;
        }

        // Ensure output directory exists
        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        // Get all PNG files in the input directory
        string[] files = Directory.GetFiles(inputDirectory, "*.png");

        foreach (string inputPath in files)
        {
            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Build the output SVG file path, preserving the original filename
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".svg");

            // Ensure the output directory for this file exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image and convert it to SVG
            using (Image image = Image.Load(inputPath))
            {
                // Set up vector rasterization options with the source image size
                VectorRasterizationOptions vectorOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Configure SVG save options
                SvgOptions saveOptions = new SvgOptions
                {
                    VectorRasterizationOptions = vectorOptions
                };

                // Save the image as SVG
                image.Save(outputPath, saveOptions);
            }
        }
    }
}