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
        string inputPath = @"C:\Images\input.tif";
        string outputDirectory = @"C:\Images\WebPPages";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the multi‑page TIFF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to TiffImage to access frames
            TiffImage tiffImage = image as TiffImage;
            if (tiffImage == null)
            {
                Console.Error.WriteLine("The loaded image is not a TIFF.");
                return;
            }

            // Iterate through each frame (page) of the TIFF
            for (int i = 0; i < tiffImage.Frames.Length; i++)
            {
                // Set the current frame as active
                tiffImage.ActiveFrame = tiffImage.Frames[i];

                // Build output file path using page number (1‑based)
                string outputPath = Path.Combine(outputDirectory, $"page_{i + 1}.webp");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the active frame as a WebP image
                tiffImage.Save(outputPath, new WebPOptions());
            }
        }
    }
}