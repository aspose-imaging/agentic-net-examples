using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded paths (no argument validation)
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output_signed.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Four‑character password for the digital signature
        string password = "ABCD";

        // Load the PNG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage (or RasterCachedImage) to access signature methods
            if (image is RasterImage rasterImage)
            {
                // Embed the digital signature using the password
                rasterImage.EmbedDigitalSignature(password);

                // Save the signed image
                rasterImage.Save(outputPath);
            }
            else
            {
                Console.Error.WriteLine("Loaded image is not a raster image.");
                return;
            }
        }

        // Reload the saved image to verify the signature
        using (Image signedImage = Image.Load(outputPath))
        {
            if (signedImage is RasterImage rasterSigned)
            {
                bool isSigned = rasterSigned.IsDigitalSigned(password);
                Console.WriteLine(isSigned
                    ? "Digital signature successfully embedded and verified."
                    : "Digital signature verification failed.");
            }
            else
            {
                Console.Error.WriteLine("Saved image is not a raster image.");
            }
        }
    }
}