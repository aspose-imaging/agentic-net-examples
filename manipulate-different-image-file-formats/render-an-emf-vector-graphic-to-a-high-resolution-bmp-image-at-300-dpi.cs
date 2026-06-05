using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.emf";
            string outputPath = "output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF vector image
            using (Image image = Image.Load(inputPath))
            {
                // Configure BMP save options with 300 DPI resolution
                BmpOptions bmpOptions = new BmpOptions
                {
                    ResolutionSettings = new Aspose.Imaging.ResolutionSetting(300, 300)
                };

                // Set vector rasterization options to render the EMF at its original size
                EmfRasterizationOptions vectorOptions = new EmfRasterizationOptions
                {
                    PageSize = image.Size
                };
                bmpOptions.VectorRasterizationOptions = vectorOptions;

                // Save the rendered bitmap
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
 * 1. When a developer needs to convert legacy Windows Metafile (EMF) diagrams into high‑resolution BMP files for printing on a 300 DPI printer.
 * 2. When an application must generate raster thumbnails of vector logos stored as EMF so they can be displayed in a Windows Forms UI that only supports BMP.
 * 3. When a batch‑processing tool has to prepare EMF technical drawings for archival in a document management system that requires BMP images at 300 DPI.
 * 4. When a reporting service needs to embed vector charts from EMF into a PDF report by first rasterizing them to BMP at print‑quality resolution.
 * 5. When a migration script must transform EMF assets from an old CAD system into BMP assets for use in a game engine that only accepts bitmap textures.
 */