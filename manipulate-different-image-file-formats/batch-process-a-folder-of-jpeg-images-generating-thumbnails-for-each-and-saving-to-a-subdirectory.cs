using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input folder containing JPEG images
        string inputFolder = @"C:\Images";

        // Hardcoded output folder for thumbnails (subdirectory of input folder)
        string outputFolder = Path.Combine(inputFolder, "thumbnails");

        // Ensure the output directory exists (unconditional as per rules)
        Directory.CreateDirectory(outputFolder);

        // Get all JPEG files in the input folder (case‑insensitive)
        var jpegFiles = Directory.GetFiles(inputFolder)
                                 .Where(f => f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                                             f.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase));

        foreach (var inputPath in jpegFiles)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Determine output path (same file name inside the thumbnails folder)
            string outputPath = Path.Combine(outputFolder, Path.GetFileName(inputPath));

            // Ensure the directory for the output file exists (unconditional)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the JPEG image
            using (JpegImage image = (JpegImage)Image.Load(inputPath))
            {
                // Define thumbnail size (e.g., max 150x150 while preserving aspect ratio)
                const int maxThumbWidth = 150;
                const int maxThumbHeight = 150;

                // Calculate scaling factor
                double widthFactor = (double)maxThumbWidth / image.Width;
                double heightFactor = (double)maxThumbHeight / image.Height;
                double scale = Math.Min(1.0, Math.Min(widthFactor, heightFactor));

                int thumbWidth = (int)(image.Width * scale);
                int thumbHeight = (int)(image.Height * scale);

                // Resize the image to create a thumbnail
                image.Resize(thumbWidth, thumbHeight, ResizeType.LanczosResample);

                // Save the thumbnail as JPEG
                image.Save(outputPath);
            }
        }
    }
}