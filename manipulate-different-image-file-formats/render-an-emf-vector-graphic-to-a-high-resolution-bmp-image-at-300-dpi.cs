using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.emf";
        string outputPath = "output.bmp";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var rasterOptions = new EmfRasterizationOptions
                {
                    PageWidth = image.Width,
                    PageHeight = image.Height
                };

                var bmpOptions = new BmpOptions
                {
                    VectorRasterizationOptions = rasterOptions,
                    ResolutionSettings = new ResolutionSetting(300, 300)
                };

                image.Save(outputPath, bmpOptions);
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
 * 1. When a developer needs to convert Windows Metafile (EMF) vector diagrams into high‑resolution BMP files for printing on a 300 DPI printer, they can use this code.
 * 2. When an application must generate pixel‑perfect thumbnails of EMF icons for inclusion in a legacy Windows application that only supports BMP images, this rasterization approach is required.
 * 3. When a reporting tool exports charts as EMF and the downstream system expects bitmap images with precise DPI settings for PDF embedding, the code provides the needed conversion.
 * 4. When a GIS or CAD system stores map overlays in EMF format but a client device only accepts BMP at 300 DPI for display on high‑resolution monitors, developers can employ this snippet.
 * 5. When an automated batch process needs to archive vector graphics from a design workflow as BMP files with consistent 300 DPI resolution for compliance and archival standards, this solution fulfills the requirement.
 */