using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Temp\input.emf";
            string outputPath = @"C:\Temp\output.svg";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
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
                    RenderMode = Aspose.Imaging.FileFormats.Emf.EmfRenderMode.Auto,
                    BorderX = 0,
                    BorderY = 0
                };

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
 * 1. When a developer needs to convert Windows Metafile (EMF) vector graphics from a legacy reporting system into scalable SVG files for web display while preserving every shape definition.
 * 2. When an application must batch‑process engineering diagrams stored as EMF and export them to SVG so they can be edited in modern vector editors without losing text as vector shapes.
 * 3. When a C# service integrates Aspose.Imaging to transform EMF logos embedded in PDF documents into SVG icons for responsive UI components.
 * 4. When a developer wants to preserve the exact visual fidelity of EMF charts by rasterizing them with a custom background color and page size before saving as SVG for print‑ready workflows.
 * 5. When an automated build pipeline needs to verify that EMF assets are correctly rendered as SVG vectors, using Aspose.Imaging’s EmfRasterizationOptions to ensure consistent border and rendering mode across platforms.
 */