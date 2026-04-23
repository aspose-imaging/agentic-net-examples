using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.jpg";
        string outputPath = @"C:\Images\output_resized.jpg";

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

            // Load the JPEG image
            using (Image image = Image.Load(inputPath))
            {
                // Determine new dimensions while preserving aspect ratio
                const int maxWidth = 1200;
                int newWidth = image.Width;
                int newHeight = image.Height;

                if (image.Width > maxWidth)
                {
                    newWidth = maxWidth;
                    newHeight = (int)Math.Round((double)image.Height * maxWidth / image.Width);
                }

                // Resize only if needed
                if (newWidth != image.Width || newHeight != image.Height)
                {
                    image.Resize(newWidth, newHeight);
                }

                // Save the resized image
                image.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}