using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Images\input.jpg";
        string outputPath = @"C:\Images\output_resized.jpg";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                int originalWidth = image.Width;
                int originalHeight = image.Height;
                const int maxDimension = 1024;

                // Compute scaling factor to fit within 1024x1024 while preserving aspect ratio
                double widthRatio = (double)maxDimension / originalWidth;
                double heightRatio = (double)maxDimension / originalHeight;
                double scale = Math.Min(widthRatio, heightRatio);

                // Do not upscale images smaller than the bounding box
                if (scale > 1.0) scale = 1.0;

                int newWidth = (int)(originalWidth * scale);
                int newHeight = (int)(originalHeight * scale);

                // Resize only if dimensions change
                if (newWidth != originalWidth || newHeight != originalHeight)
                {
                    image.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);
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