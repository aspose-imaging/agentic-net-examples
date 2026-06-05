using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\Images\input.emf";
            string outputPath = @"C:\Images\output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
            {
                // Set up SVG save options
                SvgOptions saveOptions = new SvgOptions
                {
                    // Render text using the specified font (Arial) by not converting to shapes
                    TextAsShapes = false
                };

                // Configure rasterization options for EMF to SVG conversion
                EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = emfImage.Size,
                    RenderMode = Aspose.Imaging.FileFormats.Emf.EmfRenderMode.Auto,
                    // Optional: map missing fonts to Arial (if needed)
                    // ReplaceTextMapping = new System.Collections.Generic.Dictionary<string, string> { { "*", "Arial" } }
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
 * 1. When a developer needs to convert legacy Windows Metafile (EMF) diagrams into scalable SVG files while ensuring all text appears in a consistent Arial font for web display.
 * 2. When an application must replace missing or unsupported fonts in an EMF report with Arial before exporting to SVG for cross‑platform compatibility.
 * 3. When a batch processing tool has to read EMF icons, set a uniform default font, and generate lightweight SVG assets for responsive UI design.
 * 4. When a document‑generation service requires converting EMF charts to SVG while preserving vector quality and enforcing Arial as the text rendering font.
 * 5. When a migration script updates legacy engineering drawings stored as EMF, applying Arial as the default typeface and saving them as SVG for integration with modern CAD viewers.
 */