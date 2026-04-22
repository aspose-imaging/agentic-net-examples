using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.apng";
            string outputDir = "output";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Load the animated APNG
            using (ApngImage apng = (ApngImage)Image.Load(inputPath))
            {
                int frameIndex = 0;
                foreach (var page in apng.Pages)
                {
                    string outputPath = Path.Combine(outputDir, $"frame_{frameIndex}.png");

                    // Ensure the directory for each output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the current frame as a PNG file
                    page.Save(outputPath, new PngOptions());

                    frameIndex++;
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}