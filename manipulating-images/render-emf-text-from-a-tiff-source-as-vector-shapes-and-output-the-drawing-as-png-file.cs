// HOW-TO: Convert TIFF to PNG Using EMF Vector Rendering in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/source.tif";
            string outputPath = "Output/result.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image tiffImage = Image.Load(inputPath))
            {
                EmfOptions emfOptions = new EmfOptions();

                using (Image emfImage = Image.Create(emfOptions, tiffImage.Width, tiffImage.Height))
                {
                    Graphics graphics = new Graphics(emfImage);
                    graphics.DrawImage(tiffImage, new Rectangle(0, 0, tiffImage.Width, tiffImage.Height));

                    PngOptions pngOptions = new PngOptions
                    {
                        Source = new FileCreateSource(outputPath, false)
                    };

                    emfImage.Save(outputPath, pngOptions);
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
 * 1. When you need to preserve the quality of text from a scanned TIFF by rendering it as vector shapes before saving it as a high‑resolution PNG in a C# application.
 * 2. When a reporting system must convert multi‑page TIFF documents into PNG thumbnails while keeping text crisp using Aspose.Imaging’s EMF rendering.
 * 3. When you want to generate PNG images from legacy TIFF files for web display, ensuring that any embedded text remains scalable and loss‑less.
 * 4. When automating a batch process that transforms archival TIFF images into PNG assets for a digital asset management pipeline, using vector‑based rendering to reduce file size.
 * 5. When integrating image conversion into a .NET service that needs to render TIFF‑based diagrams as vector graphics and output them as PNG for downstream analytics or UI components.
 */
