using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        try
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

            // Ensure output directory exists (null‑safe)
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
                Directory.CreateDirectory(outputDir);

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access digital signature methods
                RasterImage raster = (RasterImage)image;

                // Password for digital signature operations
                string password = "secure123";

                // Check if the image is already digitally signed
                bool isSigned = raster.IsDigitalSigned(password);

                if (!isSigned)
                {
                    // Embed a new digital signature
                    raster.EmbedDigitalSignature(password);
                }

                // Save the (potentially) modified image
                image.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}