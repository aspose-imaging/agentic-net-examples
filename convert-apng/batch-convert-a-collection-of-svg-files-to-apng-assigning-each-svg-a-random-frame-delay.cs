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
            // Hardcoded input folder containing SVG files
            string inputFolder = @"C:\SvgInput";
            // Hardcoded output folder for generated APNG files
            string outputFolder = @"C:\ApngOutput";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputFolder);

            // Collection of SVG file names to process
            string[] svgFiles = new string[]
            {
                "image1.svg",
                "image2.svg",
                "image3.svg"
                // Add more file names as needed
            };

            Random rnd = new Random();

            foreach (string fileName in svgFiles)
            {
                // Build full input and output paths
                string inputPath = Path.Combine(inputFolder, fileName);
                string outputFileName = Path.ChangeExtension(fileName, ".apng.png");
                string outputPath = Path.Combine(outputFolder, outputFileName);

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Generate a random frame delay between 100ms and 1000ms
                uint randomDelay = (uint)rnd.Next(100, 1001);

                // Load the SVG image
                using (Image image = Image.Load(inputPath))
                {
                    // Save as APNG with the random frame delay
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