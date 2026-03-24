using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input files
        string[] inputFiles = new[]
        {
            @"C:\Images\photo1.jpg",
            @"C:\Images\photo2.tif"
        };

        // Desired maximum dimensions (preserve aspect ratio)
        const int maxWidth = 800;
        const int maxHeight = 600;

        // Hard‑coded output directory
        string outputDir = @"C:\Resized";

        foreach (string inputPath in inputFiles)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Build output path
            string outputPath = Path.Combine(
                outputDir,
                Path.GetFileNameWithoutExtension(inputPath) + "_resized" + Path.GetExtension(inputPath));

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Calculate scaling factor to preserve aspect ratio
                double widthRatio = (double)maxWidth / image.Width;
                double heightRatio = (double)maxHeight / image.Height;
                double scale = Math.Min(1.0, Math.Min(widthRatio, heightRatio)); // only downscale

                int newWidth = (int)Math.Round(image.Width * scale);
                int newHeight = (int)Math.Round(image.Height * scale);

                // Perform proportional resize with high‑quality resampling
                if (image is TiffImage tiff)
                {
                    tiff.ResizeProportional(newWidth, newHeight, ResizeType.LanczosResample);
                }
                else
                {
                    image.Resize(newWidth, newHeight, ResizeType.LanczosResample);
                }

                // Save the resized image (format inferred from file extension)
                image.Save(outputPath);
            }
        }
    }
}