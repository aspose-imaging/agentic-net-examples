// HOW-TO: Add Red Border to EMF and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.emf";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image emfImage = Aspose.Imaging.Image.Load(inputPath))
            {
                EmfImage emf = emfImage as EmfImage;
                int origWidth = emf.Width;
                int origHeight = emf.Height;
                int border = 5;
                int newWidth = origWidth + border * 2;
                int newHeight = origHeight + border * 2;

                PngOptions pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                using (Aspose.Imaging.Image pngImage = Aspose.Imaging.Image.Create(pngOptions, newWidth, newHeight))
                {
                    Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(pngImage);
                    using (SolidBrush redBrush = new SolidBrush(Aspose.Imaging.Color.Red))
                    {
                        graphics.FillRectangle(redBrush, new Aspose.Imaging.Rectangle(0, 0, newWidth, newHeight));
                    }
                    graphics.DrawImage(emf, new Aspose.Imaging.Point(border, border));
                    pngImage.Save();
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
 * 1. When you need to embed a vector EMF logo in a web page that only supports PNG, you can add a colored border and convert it to PNG.
 * 2. When preparing print‑ready assets, you may want to highlight an EMF diagram with a red frame before exporting it as a raster PNG for the printer.
 * 3. When generating thumbnails for a document management system, adding a border helps distinguish the image, so you load the EMF, draw a red border, and save it as PNG.
 * 4. When integrating legacy Windows Metafile graphics into a modern .NET application, you can wrap the EMF with a red margin and convert it to PNG for UI display.
 * 5. When creating batch‑processed reports that require each EMF chart to have a consistent red outline, this code programmatically adds the border and outputs PNG files.
 */
