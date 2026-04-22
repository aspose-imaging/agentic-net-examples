using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.jpg";
        string outputPath = @"C:\temp\output.png";

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

            // Load the source image (any supported format)
            using (Image sourceImage = Image.Load(inputPath))
            {
                // Save as PNG using default options
                sourceImage.Save(outputPath, new PngOptions());
            }

            // Validate that the saved PNG can be loaded (viewable)
            using (PngImage png = new PngImage(outputPath))
            {
                // If loading succeeds, the PNG is considered viewable
                Console.WriteLine("PNG file saved and verified successfully.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}