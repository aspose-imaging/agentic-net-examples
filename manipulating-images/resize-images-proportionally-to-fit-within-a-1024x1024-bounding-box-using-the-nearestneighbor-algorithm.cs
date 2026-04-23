using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.jpg";
            string outputPath = @"C:\Images\output_resized.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Determine scaling factor to fit within 1024x1024 while preserving aspect ratio
                const int maxSize = 1024;
                double widthScale = (double)maxSize / image.Width;
                double heightScale = (double)maxSize / image.Height;
                double scale = Math.Min(widthScale, heightScale);

                // Calculate new dimensions (rounded down)
                int newWidth = (int)(image.Width * scale);
                int newHeight = (int)(image.Height * scale);

                // Resize using NearestNeighbour algorithm
                image.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

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