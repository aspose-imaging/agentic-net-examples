using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string[] inputPaths = new[]
        {
            @"C:\Images\Input1.jpg",
            @"C:\Images\Input2.png"
        };

        // Desired maximum dimensions (width, height)
        int targetWidth = 800;
        int targetHeight = 600;

        foreach (string inputPath in inputPaths)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Determine output path (same folder, prefixed with "Resized_")
            string outputPath = Path.Combine(
                Path.GetDirectoryName(inputPath) ?? string.Empty,
                "Resized_" + Path.GetFileName(inputPath));

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Compute scaling factor while preserving aspect ratio
                double widthRatio = (double)targetWidth / image.Width;
                double heightRatio = (double)targetHeight / image.Height;
                double scale = Math.Min(widthRatio, heightRatio);

                // If the image is already smaller than target, keep original size
                if (scale > 1) scale = 1;

                int newWidth = (int)(image.Width * scale);
                int newHeight = (int)(image.Height * scale);

                // Perform resize
                image.Resize(newWidth, newHeight);

                // Save the resized image
                image.Save(outputPath);
            }
        }
    }
}