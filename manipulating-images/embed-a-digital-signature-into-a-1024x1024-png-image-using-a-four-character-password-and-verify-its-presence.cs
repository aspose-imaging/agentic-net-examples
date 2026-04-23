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
            string outputPath = "output/signed.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a 1024x1024 PNG image with TruecolorWithAlpha
            using (PngImage png = new PngImage(1024, 1024, PngColorType.TruecolorWithAlpha))
            {
                // Embed digital signature using a four‑character password
                string password = "ABCD";
                png.EmbedDigitalSignature(password);

                // Save the image
                PngOptions saveOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                png.Save(outputPath, saveOptions);
            }

            // Verify the digital signature
            string inputPath = outputPath;
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (RasterImage loaded = (RasterImage)Image.Load(inputPath))
            {
                bool isSigned = loaded.IsDigitalSigned("ABCD");
                Console.WriteLine($"Signature verification result: {isSigned}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}