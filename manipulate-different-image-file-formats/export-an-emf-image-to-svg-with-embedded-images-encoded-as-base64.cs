// HOW-TO: Convert EMF to SVG with Embedded Images Base64 in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = @"C:\temp\input.emf";
        string outputPath = @"C:\temp\output.svg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
            {
                SvgOptions saveOptions = new SvgOptions
                {
                    TextAsShapes = true
                };

                EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
                {
                    BackgroundColor = Color.WhiteSmoke,
                    PageSize = emfImage.Size,
                    RenderMode = EmfRenderMode.Auto,
                    BorderX = 50,
                    BorderY = 50
                };

                saveOptions.VectorRasterizationOptions = rasterOptions;

                emfImage.Save(outputPath, saveOptions);
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
 * 1. When you need to display Windows Metafile graphics on the web, converting EMF to SVG with Base64‑encoded raster images ensures the SVG is self‑contained and browser‑compatible.
 * 2. When generating printable reports that combine vector shapes and embedded bitmaps, you can use this code to rasterize EMF content and embed the images directly into an SVG file.
 * 3. When migrating legacy engineering diagrams stored as EMF into a modern SVG workflow, the conversion preserves appearance by embedding any raster parts as Base64 data.
 * 4. When creating an SVG asset pipeline that must avoid external image files, this approach embeds all EMF raster elements, simplifying deployment and version control.
 * 5. When building a C# application that converts user‑uploaded EMF files to scalable SVG for responsive UI components, the code ensures the output SVG contains all necessary image data without separate resources.
 */
