using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"c:\temp\input.png";
            string outputPath = @"c:\temp\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (PngImage pngImage = new PngImage(inputPath))
            {
                // Store original dimensions
                int originalWidth = pngImage.Width;
                int originalHeight = pngImage.Height;

                // Rotate 45 degrees without resizing, using transparent background
                pngImage.Rotate(45f, false, Color.Transparent);

                // Verify dimensions remain unchanged
                if (pngImage.Width == originalWidth && pngImage.Height == originalHeight)
                {
                    Console.WriteLine("Dimensions unchanged after rotation.");
                }
                else
                {
                    Console.WriteLine("Dimensions changed after rotation.");
                }

                // Save the rotated image
                pngImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}