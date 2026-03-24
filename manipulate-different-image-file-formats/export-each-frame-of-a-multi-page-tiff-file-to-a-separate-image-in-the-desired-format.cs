using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.tif";
        string outputDir = @"C:\temp\output";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates parent directories if needed)
        Directory.CreateDirectory(outputDir);

        // Load the multi‑page TIFF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to TiffImage to access frames
            TiffImage tiffImage = (TiffImage)image;

            // Iterate through each frame
            for (int i = 0; i < tiffImage.Frames.Length; i++)
            {
                // Each frame is a RasterImage; we can save it directly
                using (RasterImage frame = (RasterImage)tiffImage.Frames[i])
                {
                    // Build output file path for the current frame
                    string outputPath = Path.Combine(outputDir, $"frame_{i + 1}.png");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the frame as PNG
                    frame.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}