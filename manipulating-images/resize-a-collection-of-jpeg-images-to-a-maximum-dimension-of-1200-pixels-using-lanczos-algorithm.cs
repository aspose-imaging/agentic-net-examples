using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
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
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputDir, fileName);
                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    // Determine scaling factor to keep max dimension at 1200
                    int originalWidth = image.Width;
                    int originalHeight = image.Height;
                    int maxDimension = Math.Max(originalWidth, originalHeight);

                    if (maxDimension > 1200)
                    {
                        double scale = 1200.0 / maxDimension;
                        int newWidth = (int)Math.Round(originalWidth * scale);
                        int newHeight = (int)Math.Round(originalHeight * scale);

                        // Resize using Lanczos algorithm
                        image.Resize(newWidth, newHeight, ResizeType.LanczosResample);
                    }

                    // Save the resized image (preserves original format)
                    image.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}