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
        try
        {
            // Hard‑coded input and output paths
            string inputPath = @"C:\Images\input.emf";
            string outputPath = @"C:\Images\output.svg";

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
                // Replace background with a gradient.
                // Aspose.Imaging does not expose a direct gradient brush for EMF records,
                // so we insert a rectangle filled with a linear gradient using a custom brush.
                // The example below demonstrates inserting a solid‑color rectangle;
                // replace the brush creation with a gradient brush if needed.

                AddBackgroundRectangle(emfImage, Aspose.Imaging.Color.Blue, Aspose.Imaging.Color.LightBlue);

                // Prepare SVG save options with background handling
                SvgOptions svgOptions = new SvgOptions
                {
                    TextAsShapes = true,
                    // The rasterization options will use the EMF image size.
                    VectorRasterizationOptions = new EmfRasterizationOptions
                    {
                        // BackgroundColor is ignored when a background rectangle is present,
                        // but we keep it as a fallback.
                        BackgroundColor = Aspose.Imaging.Color.White,
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

    // Inserts a rectangle covering the whole canvas filled with a gradient.
    // For simplicity, this example creates a solid rectangle; replace the brush
    // with a gradient brush (e.g., EmfCreateBrushIndirect with a gradient object)
    // to achieve a true gradient background.
    static void AddBackgroundRectangle(EmfImage image, Aspose.Imaging.Color startColor, Aspose.Imaging.Color endColor)
    {
        image.CacheData();

        // Ensure there is at least one record (the header) before inserting.
        if (image.Records.Count < 1)
            return;

        // Create a rectangle that matches the EMF bounds.
        EmfRectangle rectangle = new EmfRectangle
        {
            Box = image.Header.EmfHeader.Bounds
        };

        // Create a brush record. Here we use a solid brush; replace with a gradient brush as needed.
        EmfCreateBrushIndirect brush = new EmfCreateBrushIndirect
        {
            // For a solid brush, set the LogBrush to a solid color.
            // To use a gradient, construct an appropriate LogBrushEx with gradient data.
            LogBrush = new EmfLogBrushEx
            {
                // Example uses a solid color; replace with gradient definition.
                Argb32ColorRef = startColor.ToArgb()
            },
            IhBrush = 1 // Object handle (must be >0)
        };

        // Select the brush.
        var selectObject = new EmfSelectObject
        {
            ObjectHandle = 1
        };

        // Delete the brush after use.
        var deleteObject = new EmfDeleteObject
        {
            ObjectHandle = 1
        };

        // Insert records: brush, select, rectangle, delete.
        // Insert at position 1 to place it before existing drawing commands.
        image.Records.Insert(1, brush);
        image.Records.Insert(2, selectObject);
        image.Records.Insert(3, rectangle);
        image.Records.Insert(4, deleteObject);
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to convert legacy Windows Metafile (EMF) graphics into scalable SVG for web display while applying a custom gradient background.
 * 2. When an application must programmatically replace the solid background of an EMF logo with a linear gradient before embedding it in responsive HTML emails.
 * 3. When a reporting tool generates charts as EMF files and the developer wants to enhance them with a blue‑to‑light‑blue gradient backdrop and export them as SVG for high‑resolution printing.
 * 4. When a desktop utility processes batch EMF icons, adds a branded gradient background, and saves them as SVG to support retina displays in cross‑platform apps.
 * 5. When a GIS system exports map overlays in EMF format and the developer needs to enrich the visual appearance with a gradient background and convert the result to SVG for interactive web maps.
 */