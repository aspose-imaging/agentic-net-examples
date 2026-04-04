using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Images\sample.jpg";
        string outputPath = @"C:\Images\Resized\sample_resized.jpg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates it if necessary)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image, resize proportionally to fit within 1024x1024 using NearestNeighbour, then save
        using (Image image = Image.Load(inputPath))
        {
            const int maxSize = 1024;

            // Determine scaling factor that keeps the aspect ratio inside the bounding box
            double widthScale = (double)maxSize / image.Width;
            double heightScale = (double)maxSize / image.Height;
            double scale = Math.Min(1.0, Math.Min(widthScale, heightScale)); // do not upscale smaller images

            // Calculate new dimensions
            int newWidth = (int)Math.Round(image.Width * scale);
            int newHeight = (int)Math.Round(image.Height * scale);

            // Perform the resize using NearestNeighbour algorithm
            image.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

            // Save the resized image
            image.Save(outputPath);
        }
    }
}