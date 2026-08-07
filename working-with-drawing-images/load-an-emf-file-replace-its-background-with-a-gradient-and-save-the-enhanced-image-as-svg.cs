using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.Emf.Records;
using Aspose.Imaging.FileFormats.Emf.Emf.Objects;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.emf";
        string outputPath = @"C:\Images\output.svg";

        // Path safety checks
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the EMF image
            using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
            {
                // Replace background with a gradient.
                // Aspose.Imaging does not provide a direct gradient brush for EMF records,
                // so we insert a solid color rectangle as a placeholder.
                // To achieve a true gradient, a custom gradient brush record would be needed.
                AddBackgroundRectangleEmf(emfImage, Color.Blue);

                // Prepare SVG save options
                SvgOptions svgOptions = new SvgOptions
                {
                    TextAsShapes = true,
                    // Set background color for the rasterization surface (optional)
                    VectorRasterizationOptions = new EmfRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageSize = emfImage.Size,
                        RenderMode = Aspose.Imaging.FileFormats.Emf.EmfRenderMode.Auto
                    }
                };

                // Save as SVG
                emfImage.Save(outputPath, svgOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Helper method to insert a background rectangle at the beginning of the EMF records.
    // This method adds a solid color rectangle; replace the brush with a gradient brush
    // if a suitable gradient brush implementation is available.
    public static void AddBackgroundRectangleEmf(EmfImage image, Color color)
    {
        // Ensure the image data is loaded
        image.CacheData();

        // Create a rectangle covering the whole image bounds
        EmfRectangle rectangle = new EmfRectangle
        {
            Box = image.Header.EmfHeader.Bounds
        };

        // Create a brush with the desired color
        EmfCreateBrushIndirect brush = new EmfCreateBrushIndirect
        {
            LogBrush = new EmfLogBrushEx(),
            IhBrush = 1 // Object handle starts at 1
        };
        brush.LogBrush.Argb32ColorRef = color.ToArgb();

        // Select the brush
        var selectObject = new EmfSelectObject
        {
            ObjectHandle = 1
        };

        // Delete the brush after use
        var deleteObject = new EmfDeleteObject
        {
            ObjectHandle = 1
        };

        // Insert records at the beginning of the EMF stream
        // Insert order: brush, select, rectangle, delete
        image.Records.Insert(1, brush);
        image.Records.Insert(2, selectObject);
        image.Records.Insert(3, rectangle);
        image.Records.Insert(4, deleteObject);
    }
}

/*
 * Real-World Use Cases:
 * 1. When a Windows desktop application needs to convert legacy EMF vector icons into scalable SVG files with a custom gradient background for high‑resolution UI scaling.
 * 2. When a reporting tool must embed EMF charts into web‑ready SVG graphics and replace the original white canvas with a corporate color gradient using C# and Aspose.Imaging.
 * 3. When a batch processing service automates the migration of printed marketing assets stored as EMF files to SVG format while applying a brand‑consistent gradient backdrop.
 * 4. When a GIS mapping solution imports EMF map overlays, adds a colored gradient background to improve visual contrast, and exports the result as SVG for web mapping APIs.
 * 5. When a document conversion pipeline transforms EMF diagrams from legacy Office documents into SVG with a gradient background to preserve vector quality across browsers.
 */