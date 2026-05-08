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
            string inputPath = "Input\\animation.apng";
            string outputPath = "Output\\animation.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the APNG animation
            using (ApngImage apng = (ApngImage)Image.Load(inputPath))
            {
                // Save as GIF
                var gifOptions = new GifOptions();
                apng.Save(outputPath, gifOptions);
            }

            // Verify the GIF was created
            if (File.Exists(outputPath))
            {
                Console.WriteLine($"GIF saved successfully: {outputPath}");
                Console.WriteLine("You can open this file in major browsers to verify playback.");
            }
            else
            {
                Console.Error.WriteLine("Failed to create the GIF file.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}