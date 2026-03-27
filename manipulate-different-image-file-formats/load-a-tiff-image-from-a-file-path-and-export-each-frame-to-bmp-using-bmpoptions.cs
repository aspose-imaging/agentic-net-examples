using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hard‑coded input TIFF file
        string inputPath = "input.tif";

        // Verify the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the multi‑frame TIFF image
        using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
        {
            // Directory where BMP frames will be saved
            string outputDir = "output";
            // Ensure the output directory exists (unconditional per requirements)
            Directory.CreateDirectory(Path.GetDirectoryName(outputDir));

            // Export each frame to a separate BMP file
            for (int i = 0; i < tiffImage.Frames.Length; i++)
            {
                var frame = tiffImage.Frames[i];
                string outputPath = Path.Combine(outputDir, $"frame_{i + 1}.bmp");

                // Ensure the directory for this file exists (unconditional)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the frame using BMP options
                frame.Save(outputPath, new BmpOptions());
            }
        }
    }
}