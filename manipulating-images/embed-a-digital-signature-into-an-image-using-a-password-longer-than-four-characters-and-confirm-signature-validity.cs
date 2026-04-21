using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access digital signature methods
                var rasterImage = image as RasterImage;
                if (rasterImage == null)
                {
                    Console.Error.WriteLine("Loaded image does not support raster operations.");
                    return;
                }

                // Embed a digital signature with a password longer than four characters
                string password = "StrongPass123";
                rasterImage.EmbedDigitalSignature(password);

                // Save the signed image
                rasterImage.Save(outputPath);
            }

            // Load the signed image to verify the signature
            using (Image signedImage = Image.Load(outputPath))
            {
                var rasterImage = signedImage as RasterImage;
                if (rasterImage == null)
                {
                    Console.Error.WriteLine("Signed image does not support raster operations.");
                    return;
                }

                string password = "StrongPass123";
                bool isSigned = rasterImage.IsDigitalSigned(password);
                Console.WriteLine(isSigned
                    ? "Digital signature verified successfully."
                    : "Digital signature verification failed.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}