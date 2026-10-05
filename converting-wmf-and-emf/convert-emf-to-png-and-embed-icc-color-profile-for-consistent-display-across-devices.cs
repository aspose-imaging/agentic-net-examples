// HOW-TO: Convert EMF to PNG with Vector Rasterization in C# (Aspose.Imaging for .NET)
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
            string inputPath = Path.Combine("Input", "input.emf");
            string outputPath = Path.Combine("Output", "output.png");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image emfImage = Image.Load(inputPath))
            using (PngOptions pngOptions = new PngOptions())
            {
                pngOptions.Source = new FileCreateSource(outputPath, false);
                pngOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = emfImage.Width,
                    PageHeight = emfImage.Height
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
 * 1. When you need to display Windows Metafile (EMF) graphics on web pages that only support PNG images.
 * 2. When generating thumbnails of vector diagrams for reports that require a fixed pixel size and white background.
 * 3. When converting printable vector assets to raster PNG files for inclusion in mobile apps that cannot render EMF.
 * 4. When automating a batch process that transforms EMF logos into PNGs while preserving original dimensions for brand consistency.
 * 5. When preparing vector illustrations for email newsletters that require PNG format to ensure proper rendering across email clients.
 */
