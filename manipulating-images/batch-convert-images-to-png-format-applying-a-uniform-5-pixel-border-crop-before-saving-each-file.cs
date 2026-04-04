using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input files (adjust paths as needed)
        string[] inputFiles = new string[]
        {
            @"C:\Images\Input\photo1.jpg",
            @"C:\Images\Input\photo2.bmp",
            @"C:\Images\Input\photo3.tif"
        };

        // Hardcoded output directory
        string outputDir = @"C:\Images\Output\";

        // Ensure the output directory exists (unconditional per requirements)
        Directory.CreateDirectory(outputDir);

        foreach (string inputPath in inputFiles)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Compute crop rectangle (5‑pixel border on each side)
                int cropX = 5;
                int cropY = 5;
                int cropWidth = Math.Max(0, image.Width - 2 * cropX);
                int cropHeight = Math.Max(0, image.Height - 2 * cropY);
                var cropRect = new Rectangle(cropX, cropY, cropWidth, cropHeight);

                // Apply cropping
                image.Crop(cropRect);

                // Prepare output file path (same name, .png extension)
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileNameWithoutExt + ".png");

                // Ensure output directory exists (unconditional per requirements)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save as PNG using default options
                var pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
            }
        }
    }
}