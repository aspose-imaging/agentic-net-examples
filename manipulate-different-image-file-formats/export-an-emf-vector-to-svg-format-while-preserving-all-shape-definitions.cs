// HOW-TO: Convert EMF Vector File to SVG Preserving Shapes in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"c:\temp\test.emf";
        string outputPath = @"c:\temp\test.output.svg";

        // Ensure any runtime exception is reported without crashing
        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF image
            using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
            {
                // Prepare SVG save options
                SvgOptions saveOptions = new SvgOptions
                {
                    TextAsShapes = true // Preserve text as vector shapes
                };

                // Configure rasterization options for EMF
                EmfRasterizationOptions rasterizationOptions = new EmfRasterizationOptions
                {
                    BackgroundColor = Color.WhiteSmoke,
                    PageSize = emfImage.Size,
                    RenderMode = EmfRenderMode.Auto,
                    // Optional margins; can be omitted if not needed
                    BorderX = 0,
                    BorderY = 0
                };

                // Attach rasterization options to SVG options
                saveOptions.VectorRasterizationOptions = rasterizationOptions;

                // Save as SVG
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
 * 1. When you need to display Windows Metafile (EMF) graphics on the web, you can convert them to scalable SVG files while keeping all vector shapes intact.
 * 2. When generating printable reports that contain EMF logos, you can export the logos to SVG to ensure they remain resolution‑independent in PDF or HTML outputs.
 * 3. When migrating a legacy desktop application that stores diagrams as EMF, you can batch‑convert the files to SVG for use in modern browsers or mobile apps.
 * 4. When creating an automated build pipeline that processes design assets, you can use this code to transform EMF icons into SVG sprites without losing text as vector shapes.
 * 5. When integrating with a GIS system that requires SVG overlays, you can convert EMF map symbols to SVG while preserving their exact geometry and styling.
 */
