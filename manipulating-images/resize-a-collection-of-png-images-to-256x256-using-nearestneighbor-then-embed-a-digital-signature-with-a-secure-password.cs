using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Secure password for digital signature
        const string password = "StrongPassword123!";

        // Hardcoded collection of PNG input files
        string[] inputPaths = { "image1.png", "image2.png", "image3.png" };

        foreach (var inputPath in inputPaths)
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                continue;
            }

            // Build output path inside the 'output' folder
            string outputDirectory = "output";
            string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + "_256x256.png";
            string outputPath = Path.Combine(outputDirectory, outputFileName);

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image using Aspose.Imaging
            using (Image image = Image.Load(inputPath))
            {
                // Process only raster images (PNG is raster)
                if (image is RasterImage rasterImage)
                {
                    // Resize to 256x256 using the default NearestNeighbour resample
                    rasterImage.Resize(256, 256);

                    // Embed a digital signature with the provided password
                    rasterImage.EmbedDigitalSignature(password);

                    // Save the processed image to the output path
                    rasterImage.Save(outputPath);
                }
                else
                {
                    Console.Error.WriteLine($"Unsupported image format: {inputPath}");
                }
            }
        }
    }
}