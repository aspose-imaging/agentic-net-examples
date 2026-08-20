// HOW-TO: Create Lossless APNG from PNG with Maximum Compression in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
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

            using (Aspose.Imaging.RasterImage sourceImage = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
            {
                ApngOptions options = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    PngCompressionLevel = PngCompressionLevel.ZipLevel9,
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                using (ApngImage apngImage = (ApngImage)Aspose.Imaging.Image.Create(options, sourceImage.Width, sourceImage.Height))
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
 * 1. When you need to generate an animated PNG for a web banner while preserving the original PNG’s color fidelity and using lossless compression.
 * 2. When a desktop application must convert user‑uploaded PNG assets into APNG files for high‑quality animations without increasing file size.
 * 3. When an e‑learning platform requires embedding a single‑frame PNG into an APNG container to support browsers that only recognize animated PNGs.
 * 4. When a game developer wants to batch‑process sprites, saving them as APNGs with maximum zip compression to reduce download time while keeping exact colors.
 * 5. When a digital publishing workflow needs to add a color‑profile‑aware APNG to a PDF, ensuring the image remains lossless during the conversion.
 */
