// HOW-TO: Convert EMF Vector to PNG with Anti‑Aliasing in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.emf";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (EmfImage emfImage = (EmfImage)Aspose.Imaging.Image.Load(inputPath))
            {
                EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.White,
                    PageSize = emfImage.Size,
                    SmoothingMode = Aspose.Imaging.SmoothingMode.AntiAlias,
                    TextRenderingHint = Aspose.Imaging.TextRenderingHint.AntiAlias
                };

                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                emfImage.Save(outputPath, pngOptions);
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
 * 1. When you need to display Windows Metafile (EMF) graphics on a web page as high‑quality PNG images with smooth edges.
 * 2. When generating printable reports that embed EMF diagrams but require raster PNG output for PDF conversion.
 * 3. When converting legacy EMF icons to PNG thumbnails for a mobile app while preserving visual fidelity.
 * 4. When processing batch EMF files in a C# service and want anti‑aliased PNGs for a digital asset pipeline.
 * 5. When integrating Aspose.Imaging into a .NET application to rasterize vector drawings with anti‑aliasing for UI rendering.
 */
