// HOW-TO: Export EPS to Grayscale PNG Using PngColorType in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.eps";
            string outputPath = "Output/sample_grayscale.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EPS image
            using (var image = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(inputPath))
            {
                // Configure PNG options for grayscale output
                var pngOptions = new PngOptions
                {
                    ColorType = PngColorType.Grayscale,
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    }
                };

                // Save as grayscale PNG
                image.Save(outputPath, pngOptions);
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
 * 1. When you need to generate printable black‑and‑white previews of vector EPS logos for a web catalog.
 * 2. When a reporting system must embed EPS diagrams as grayscale PNGs to reduce file size while preserving contrast.
 * 3. When converting scientific EPS plots to grayscale PNGs for inclusion in journal PDFs that require raster images.
 * 4. When an e‑learning platform requires EPS illustrations to be displayed on devices that only support PNG with a single color channel.
 * 5. When automating batch processing of EPS assets to create consistent grayscale thumbnails for a digital asset management system.
 */
