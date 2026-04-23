using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "output.bmp";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Desired maximum dimensions
                int targetWidth = 800;
                int targetHeight = 600;

                // Calculate scaling factor to maintain aspect ratio
                double widthRatio = (double)targetWidth / image.Width;
                double heightRatio = (double)targetHeight / image.Height;
                double scale = Math.Min(widthRatio, heightRatio);

                int newWidth = (int)(image.Width * scale);
                int newHeight = (int)(image.Height * scale);

                // Resize the image
                image.Resize(newWidth, newHeight);

                // Save as BMP
                BmpOptions options = new BmpOptions();
                image.Save(outputPath, options);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}