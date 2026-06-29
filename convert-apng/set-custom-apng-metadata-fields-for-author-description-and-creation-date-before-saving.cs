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
        string inputPath = "input.png";
        string outputPath = "output.apng";

        try
        {
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
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                using (ApngImage apngImage = (ApngImage)Image.Create(
                    options,
                    sourceImage.Width,
                    sourceImage.Height))
                {
                    apngImage.RemoveAllFrames();
                    apngImage.AddFrame(sourceImage);
                    apngImage.Save();
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
 * 1. When a developer needs to embed author, description, and creation date metadata into an animated PNG (APNG) file to meet digital asset management requirements.
 * 2. When a web application generates APNG stickers and wants to include creator information and timestamps for copyright tracking.
 * 3. When an e‑learning platform creates animated diagrams in APNG format and must store metadata for version control and content indexing.
 * 4. When a mobile game exports character animations as APNG files and requires embedded metadata to be read by analytics tools.
 * 5. When a documentation generator produces APNG screenshots and wants to preserve the original author and creation date for audit trails.
 */