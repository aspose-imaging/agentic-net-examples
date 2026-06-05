using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.jpg";
        string outputPath = @"C:\Images\output\sample_converted.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Save as PNG with default options
                image.Save(outputPath, new PngOptions());
            }

            // Validate that the saved PNG can be loaded (viewable)
            if (Image.CanLoad(outputPath))
            {
                Console.WriteLine("PNG file saved successfully and is viewable.");
            }
            else
            {
                Console.Error.WriteLine("Saved PNG file could not be loaded. It may be corrupted.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}