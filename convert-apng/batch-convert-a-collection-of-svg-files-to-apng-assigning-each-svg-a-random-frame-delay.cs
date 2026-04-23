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
            string inputDir = @"C:\InputSvgs";
            string outputDir = @"C:\OutputApngs";

            // Ensure the base output directory exists
            Directory.CreateDirectory(outputDir);

            // Get all SVG files in the input directory
            var svgFiles = Directory.GetFiles(inputDir, "*.svg");

            Random rnd = new Random();

            foreach (var inputPath in svgFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the SVG image
                using (Image image = Image.Load(inputPath))
                {
                    // Assign a random frame delay between 100ms and 1000ms
                    int delay = rnd.Next(100, 1001);
                    var apngOptions = new ApngOptions { DefaultFrameTime = (uint)delay };

                    // Build the output file path
                    string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".apng";
                    string outputPath = Path.Combine(outputDir, outputFileName);

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the image as APNG with the random frame delay
                    image.Save(outputPath, apngOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}