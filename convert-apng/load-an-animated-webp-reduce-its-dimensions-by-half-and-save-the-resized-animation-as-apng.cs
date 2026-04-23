using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\animation_input.webp";
        string outputPath = @"C:\Images\animation_resized.png";

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

            // Load the animated WebP image
            using (Image image = Image.Load(inputPath))
            {
                // Calculate new dimensions (half of original)
                int newWidth = image.Width / 2;
                int newHeight = image.Height / 2;

                // Resize the image (applies to all frames)
                image.Resize(newWidth, newHeight);

                // Save as APNG (animated PNG) using default options
                image.Save(outputPath, new ApngOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}