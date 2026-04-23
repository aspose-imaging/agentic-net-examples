using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define output path
            string outputPath = "output.png";

            // Ensure output directory exists (unconditional per requirements)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create PNG image with alpha channel
            PngOptions options = new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha,
                Source = new FileCreateSource(outputPath, false)
            };

            // Image dimensions must be at least 200x200 for digital signature
            using (Image image = Image.Create(options, 200, 200))
            {
                // Embed digital signature with a valid password
                RasterImage raster = (RasterImage)image;
                raster.EmbedDigitalSignature("secure123");

                // Save the image (bound to FileCreateSource)
                image.Save();
            }

            // Verify the digital signature after saving
            if (!File.Exists(outputPath))
            {
                Console.Error.WriteLine($"File not found: {outputPath}");
                return;
            }

            using (Image loadedImage = Image.Load(outputPath))
            {
                RasterImage loadedRaster = (RasterImage)loadedImage;
                bool isSigned = loadedRaster.IsDigitalSigned("secure123");
                Console.WriteLine($"Signature verification: {(isSigned ? "Valid" : "Invalid")}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}