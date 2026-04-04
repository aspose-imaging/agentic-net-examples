using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputDir = @"C:\Images\Input\";
        string outputDir = @"C:\Images\Output\";

        // List of JPEG files to process
        string[] files = new[]
        {
            "photo1.jpg",
            "photo2.jpg",
            "photo3.jpg"
        };

        foreach (string fileName in files)
        {
            string inputPath = Path.Combine(inputDir, fileName);
            string outputPath = Path.Combine(outputDir, fileName);

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
                int originalWidth = image.Width;
                int originalHeight = image.Height;
                int maxDimension = 1200;

                if (originalWidth > maxDimension || originalHeight > maxDimension)
                {
                    double scale = maxDimension / (double)Math.Max(originalWidth, originalHeight);
                    int newWidth = (int)(originalWidth * scale);
                    int newHeight = (int)(originalHeight * scale);

                    // Resize using Lanczos algorithm
                    image.Resize(newWidth, newHeight, ResizeType.LanczosResample);
                }

                // Save the resized image as JPEG
                image.Save(outputPath);
            }
        }
    }
}