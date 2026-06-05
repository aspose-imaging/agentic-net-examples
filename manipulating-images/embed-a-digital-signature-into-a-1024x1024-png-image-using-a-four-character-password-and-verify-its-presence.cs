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
            string inputPath = @"C:\Images\input.png";
            string outputPath = @"C:\Images\output_signed.png";
            // Four‑character password for the digital signature
            string password = "ABCD";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access signature methods
                RasterImage rasterImage = image as RasterImage;
                if (rasterImage == null)
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
                    return;
                }

                // Embed the digital signature using the password
                rasterImage.EmbedDigitalSignature(password);

                // Save the signed image
                rasterImage.Save(outputPath);
            }

            // Load the signed image to verify the signature
            using (Image signedImage = Image.Load(outputPath))
            {
                RasterImage rasterSigned = signedImage as RasterImage;
                if (rasterSigned == null)
                {
                    Console.Error.WriteLine("Signed image is not a raster image.");
                    return;
                }

                // Check if the image is digitally signed
                bool isSigned = rasterSigned.IsDigitalSigned(password);
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