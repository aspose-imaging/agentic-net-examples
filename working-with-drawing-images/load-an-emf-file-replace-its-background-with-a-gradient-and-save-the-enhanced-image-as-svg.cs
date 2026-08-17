// HOW-TO: Convert EMF to SVG with Custom Background Color in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.emf";
            string outputPath = "output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.FileFormats.Emf.EmfImage emfImage = (Aspose.Imaging.FileFormats.Emf.EmfImage)Aspose.Imaging.Image.Load(inputPath))
            {
                // Configure SVG save options
                SvgOptions saveOptions = new SvgOptions
                {
                    TextAsShapes = true
                };

                // Set up rasterization options with a solid background (gradient not directly supported)
                EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.LightBlue,
                    PageSize = emfImage.Size,
                    RenderMode = Aspose.Imaging.FileFormats.Emf.EmfRenderMode.Auto
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
 * 1. When you need to embed a Windows Metafile (EMF) into a web page as scalable SVG while applying a solid background color using C#.
 * 2. When converting legacy EMF diagrams to SVG for responsive UI designs and you want the text to be preserved as shapes for consistent rendering.
 * 3. When automating a batch process that transforms EMF assets into SVG files with a predefined background for branding or theming purposes.
 * 4. When integrating Aspose.Imaging into a .NET application to rasterize EMF graphics with a custom background before exporting them as vector SVG files.
 * 5. When generating SVG versions of technical drawings from EMF files and ensuring the output has a uniform background color for printing or publishing.
 */
