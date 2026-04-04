using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Password used for digital signature operations
        string password = "secret";

        // Load the image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access digital signature methods
            RasterImage raster = image as RasterImage;
            if (raster == null)
            {
                Console.Error.WriteLine("Loaded image is not a raster image.");
                return;
            }

            // Check if the image is already digitally signed
            bool isSigned = raster.IsDigitalSigned(password);
            if (isSigned)
            {
                Console.WriteLine("Image is already digitally signed.");
            }
            else
            {
                // Embed a new digital signature
                raster.EmbedDigitalSignature(password);

                // Save the modified image
                raster.Save(outputPath);
                Console.WriteLine("Digital signature embedded and image saved.");
            }
        }
    }
}