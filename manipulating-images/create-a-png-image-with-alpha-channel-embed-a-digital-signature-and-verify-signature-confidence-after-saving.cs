using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define output path (ensure it contains a directory)
            string outputPath = "Output/output.png";

            // Create output directory unconditionally
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a new PNG image with alpha channel (200x200)
            using (var png = new PngImage(200, 200, PngColorType.TruecolorWithAlpha))
            {
                // Embed a digital signature using a valid password
                ((RasterImage)png).EmbedDigitalSignature("secure123");

                // Save the image to the specified path
                png.Save(outputPath);
            }

            // Verify the digital signature after saving
            string inputPath = outputPath;

            // Check that the file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the saved image and check signature
            using (var loadedImage = Image.Load(inputPath))
            {
                var raster = (RasterImage)loadedImage;
                bool isSigned = raster.IsDigitalSigned("secure123");
                Console.WriteLine($"Is digitally signed: {isSigned}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to generate a PNG with transparency for a web UI and protect it from tampering by embedding a digital signature.
 * 2. When a C# application must create a true‑color PNG with an alpha channel for overlay graphics and later verify its integrity after saving.
 * 3. When a software solution stores confidential diagrams as PNG files and wants to ensure only authorized users can confirm the image’s authenticity using a password.
 * 4. When an automated reporting tool produces PNG charts, embeds a signature for compliance auditing, and checks the signature confidence before distribution.
 * 5. When a digital asset management system programmatically creates PNG thumbnails, signs them to prevent unauthorized modifications, and validates the signature during import.
 */