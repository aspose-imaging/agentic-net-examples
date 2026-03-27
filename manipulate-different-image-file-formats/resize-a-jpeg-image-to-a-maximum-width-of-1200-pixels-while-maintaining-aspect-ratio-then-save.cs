using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output file paths
        string inputPath = "input.jpg";
        string outputPath = "output\\resized.jpg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
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
                double scale = (double)maxWidth / image.Width;
                newWidth = maxWidth;
                newHeight = (int)(image.Height * scale);

                // Resize the image using nearest neighbour resampling
                image.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);
            }

            // Prepare JPEG save options (optional quality setting)
            JpegOptions saveOptions = new JpegOptions
            {
                Quality = 90
            };

            // Save the resized image
            image.Save(outputPath, saveOptions);
        }
    }
}