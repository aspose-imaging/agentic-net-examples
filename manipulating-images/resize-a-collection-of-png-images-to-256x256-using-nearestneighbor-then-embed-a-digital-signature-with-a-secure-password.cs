using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            string[] files = Directory.GetFiles(inputDirectory, "*.png");

            foreach (var file in files)
            {
                // Verify input file exists
                if (!File.Exists(file))
                {
                    Console.Error.WriteLine($"File not found: {file}");
                    return;
                }

                using (RasterImage image = (RasterImage)Image.Load(file))
                {
                    // Resize to 256x256 using default NearestNeighbour resampling
                    image.Resize(256, 256);

                    // Embed digital signature with a secure password
                    image.EmbedDigitalSignature("secure123");

                    // Prepare output path
                    string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(file) + "_resized.png");

                    // Ensure output directory exists for the file
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save as PNG
                    var options = new PngOptions();
                    image.Save(outputPath, options);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}