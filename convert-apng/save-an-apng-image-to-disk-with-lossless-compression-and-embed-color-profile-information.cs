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
            string outputPath = "output/output.apng";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
            {
                ApngOptions createOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    ColorType = PngColorType.TruecolorWithAlpha,
                    PngCompressionLevel = PngCompressionLevel.ZipLevel9
                };

                using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, sourceImage.Width, sourceImage.Height))
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
 * 1. When a developer needs to convert a regular PNG into an animated PNG (APNG) using Aspose.Imaging for .NET with lossless ZipLevel9 compression for web optimization.
 * 2. When a developer wants to embed a truecolor with alpha color profile into an APNG while preserving transparency for high‑quality UI graphics.
 * 3. When a developer creates APNG files on the server from uploaded PNGs in a C# web API, using ApngOptions and FileCreateSource to ensure the output folder exists and the image is saved with maximum compression.
 * 4. When a developer builds a desktop tool that batches screenshots into APNGs, using RasterImage and ApngImage to maintain color fidelity and lossless compression.
 * 5. When a developer must programmatically generate an APNG from a source image, handle missing input files, and store the result in a nested directory structure using Aspose.Imaging’s image loading and saving methods.
 */