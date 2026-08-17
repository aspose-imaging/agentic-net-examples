// HOW-TO: Create PNG With Alpha Channel And Embed Digital Signature In C# (Aspose.Imaging for .NET)
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
        string inputPath = "input.png";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            PngOptions pngOptions = new PngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                ColorType = PngColorType.TruecolorWithAlpha
            };

            int width = 200;
            int height = 200;

            using (Image image = Image.Create(pngOptions, width, height))
            {
                PngImage pngImage = (PngImage)image;

                Graphics graphics = new Graphics(pngImage);
                graphics.Clear(Color.Transparent);

                RasterImage raster = (RasterImage)pngImage;
                raster.EmbedDigitalSignature("secure123");

                pngImage.Save();
            }

            using (Image loadedImage = Image.Load(outputPath))
            {
                RasterImage rasterLoaded = (RasterImage)loadedImage;
                bool isSigned = rasterLoaded.IsDigitalSigned("secure123");
                Console.WriteLine($"Signature valid: {isSigned}");
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
 * 1. When you need to generate a transparent PNG thumbnail and ensure its authenticity by embedding a digital signature that can be verified later.
 * 2. When a web application must produce PNG assets with alpha transparency and protect them against tampering using Aspose.Imaging’s digital signing feature.
 * 3. When a document management system stores PNG images and requires a built‑in signature to confirm the source before allowing downloads.
 * 4. When an e‑commerce platform creates product images with transparent backgrounds and wants to embed a secret key to detect unauthorized modifications.
 * 5. When a secure reporting tool saves charts as PNG files with alpha channels and needs to validate the signature confidence after the file is written.
 */
