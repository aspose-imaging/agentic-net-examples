using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Dng;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output directories
        string inputDirectory = "Input";
        string outputDirectory = "Output";

        // Minimum pixel count requirement (e.g., 800x600)
        int minPixelCount = 800 * 600;

        // Ensure the output directory exists
        Directory.CreateDirectory(outputDirectory);

        // Process each file in the input directory
        foreach (string inputPath in Directory.GetFiles(inputDirectory))
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
                // Check if the image meets the pixel count requirement
                if (image.Width * image.Height > minPixelCount)
                {
                    // Embed digital signature using a password
                    string password = "SecretPassword123";
                    dynamic raster = image; // Use dynamic to call EmbedDigitalSignature on the concrete type
                    raster.EmbedDigitalSignature(password);

                    // Prepare output path
                    string fileName = Path.GetFileName(inputPath);
                    string outputPath = Path.Combine(outputDirectory, fileName);

                    // Ensure the output directory for this file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the modified image (preserves original format)
                    raster.Save(outputPath);
                }
            }
        }
    }
}