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
            string[] svgFiles = Directory.GetFiles(inputDir, "*.svg");

            Random rnd = new Random();

            foreach (string inputPath in svgFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output file path (APNG uses .png extension)
                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileName + ".png");

                // Ensure the output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Assign a random frame delay between 100ms and 999ms
                uint randomDelay = (uint)rnd.Next(100, 1000);

                // Load the SVG and save it as an APNG with the random delay
                using (Image image = Image.Load(inputPath))
                {
                    image.Save(outputPath, new ApngOptions() { DefaultFrameTime = randomDelay });
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}