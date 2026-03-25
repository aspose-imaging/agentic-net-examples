using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputDirectory = @"C:\Images\Input";
        string outputDirectory = @"C:\Images\Output\Bucket";

        // Validate input directory
        if (!Directory.Exists(inputDirectory))
        {
            Console.Error.WriteLine($"Input directory does not exist: {inputDirectory}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(outputDirectory);

        // Get all BMP files in the input directory
        string[] bmpFiles = Directory.GetFiles(inputDirectory, "*.bmp");

        foreach (string inputPath in bmpFiles)
        {
            // Validate each input file
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Determine output SVG path
            string fileName = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(outputDirectory, fileName + ".svg");

            // Ensure the output directory for this file exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load BMP and save as SVG
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                var vectorOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };

                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = vectorOptions
                };

                image.Save(outputPath, svgOptions);
            }
        }
    }
}