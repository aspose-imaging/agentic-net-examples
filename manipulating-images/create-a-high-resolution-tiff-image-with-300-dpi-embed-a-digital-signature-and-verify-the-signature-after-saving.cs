using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define output path for the high‑resolution TIFF image
            string outputPath = "output/highres.tif";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create TIFF options with default format
            var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

            // Create a new TIFF image of size 1000x1000 pixels
            using (Image image = Image.Create(tiffOptions, 1000, 1000))
            {
                // Set the resolution to 300 DPI
                ((RasterImage)image).SetResolution(300, 300);

                // Embed a digital signature using a password
                ((RasterCachedImage)image).EmbedDigitalSignature("secure123");

                // Save the image to the specified path
                image.Save(outputPath, tiffOptions);
            }

            // Load the saved image to verify the digital signature
            using (Image loadedImage = Image.Load(outputPath))
            {
                bool isSigned = ((RasterCachedImage)loadedImage).IsDigitalSigned("secure123", 80);
                Console.WriteLine($"Signature valid: {isSigned}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}