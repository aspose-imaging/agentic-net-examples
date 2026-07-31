using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output\\output.apng";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
            {
                ApngOptions options = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    DefaultFrameTime = 100,
                    ColorType = PngColorType.TruecolorWithAlpha,
                    PngCompressionLevel = PngCompressionLevel.ZipLevel9
                };

                using (ApngImage apng = (ApngImage)Image.Create(options, sourceImage.Width, sourceImage.Height))
                {
                    apng.RemoveAllFrames();
                    apng.AddFrame(sourceImage);
                    apng.Save();
                }
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
 * 1. When a developer needs to convert a single PNG asset into an animated PNG (APNG) with lossless compression for high‑quality web animations.
 * 2. When a game developer wants to generate lightweight, losslessly compressed APNG sprites on the fly using C# and Aspose.Imaging to ensure crisp visuals across devices.
 * 3. When an e‑learning platform must embed the original PNG color profile into an APNG tutorial slide to preserve accurate colors while delivering animated content.
 * 4. When a desktop application has to batch‑process user‑uploaded PNGs into APNG files with a fixed frame duration and maximum ZIP compression for archival storage.
 * 5. When a digital publishing workflow requires programmatically creating APNG files from source images in .NET, preserving truecolor with alpha and embedding ICC profile data for print‑ready output.
 */