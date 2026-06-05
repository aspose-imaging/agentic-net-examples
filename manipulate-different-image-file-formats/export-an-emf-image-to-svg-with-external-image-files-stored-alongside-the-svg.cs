using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.Graphics;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.emf";
        string outputPath = @"C:\temp\output.svg";

        // Ensure any runtime exception is caught and reported
        try
        {
            // Validate input file existence
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
                    TextAsShapes = true // Render text as shapes
                };

                // Configure rasterization options for EMF to SVG conversion
                EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
                {
                    BackgroundColor = Color.WhiteSmoke,
                    PageSize = emfImage.Size,
                    RenderMode = EmfRenderMode.Auto,
                    BorderX = 50, // Horizontal margin
                    BorderY = 50  // Vertical margin
                };

                // Assign rasterization options to the SVG options
                saveOptions.VectorRasterizationOptions = rasterOptions;

                // Save the EMF image as SVG
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
 * 1. When a Windows desktop application needs to convert legacy EMF vector drawings into web‑friendly SVG files while preserving embedded raster images as separate files for faster loading.
 * 2. When a reporting service generates charts as EMF and must deliver them to browsers as scalable SVG graphics with external image assets stored next to the SVG for responsive design.
 * 3. When a document conversion pipeline processes engineering diagrams saved in EMF and requires SVG output with text rendered as shapes and margins defined by EmfRasterizationOptions.
 * 4. When a batch job migrates a library of EMF icons to SVG for use in a cross‑platform UI, ensuring the SVG references external bitmap resources placed in the same folder.
 * 5. When an automated build script needs to validate that EMF assets can be rasterized with a custom background color and saved as SVG using Aspose.Imaging’s C# API for quality assurance.
 */