// HOW-TO: Render EMF Vector Graphic to High Resolution BMP at 300 DPI in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace ImagingNet
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "Input\\vector.emf";
                string outputPath = "Output\\rendered.bmp";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image emfImage = Image.Load(inputPath))
                {
                    BmpOptions bmpOptions = new BmpOptions();
                    VectorRasterizationOptions vectorOptions = new VectorRasterizationOptions
                    {
                        PageWidth = emfImage.Width,
                        PageHeight = emfImage.Height
                    };

                    bmpOptions.VectorRasterizationOptions = vectorOptions;

                    emfImage.Save(outputPath, bmpOptions);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to convert Windows Metafile (EMF) diagrams into BMP files for printing or legacy systems that only accept bitmap formats.
 * 2. When an application must generate high‑resolution raster images from vector logos to embed in PDF reports.
 * 3. When a batch process has to prepare EMF icons for display on devices that do not support vector formats.
 * 4. When a data‑import tool requires converting vector drawings to BMP to perform pixel‑based analysis or OCR.
 * 5. When a software product needs to create 300 DPI BMP thumbnails of EMF schematics for documentation portals.
 */
