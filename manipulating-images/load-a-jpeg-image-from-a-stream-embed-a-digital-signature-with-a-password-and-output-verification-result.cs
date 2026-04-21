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
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";
            string password = "mySecretPassword";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load JPEG from a file stream, embed digital signature, and save
            using (FileStream inputStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
            using (Image image = Image.Load(inputStream))
            {
                // Cast to RasterImage to access digital signature methods
                if (image is RasterImage rasterImage)
                {
                    rasterImage.EmbedDigitalSignature(password);
                    rasterImage.Save(outputPath);
                }
                else
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
                    return;
                }
            }

            // Load the signed image and verify the signature
            using (Image signedImage = Image.Load(outputPath))
            {
                if (signedImage is RasterImage signedRaster)
                {
                    bool isSigned = signedRaster.IsDigitalSigned(password);
                    Console.WriteLine($"Digital signature verification: {(isSigned ? "Valid" : "Invalid")}");
                }
                else
                {
                    Console.Error.WriteLine("Signed image is not a raster image.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}