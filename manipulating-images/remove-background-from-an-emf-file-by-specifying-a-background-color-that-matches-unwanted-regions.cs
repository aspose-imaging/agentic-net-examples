using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.Emf.Records;
using Aspose.Imaging.FileFormats.Emf.Emf.Objects;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.emf";
        string outputPath = @"C:\Images\output\ChangedBackground_input.emf";

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

            // Load EMF image
            using (MetaImage metaImage = (MetaImage)Image.Load(inputPath))
            {
                // Add background rectangle with the desired color (e.g., White)
                AddBackgroundRectangleEmf((EmfImage)metaImage, Color.White);

                // Save the modified image
                metaImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Helper method to insert a background rectangle into the EMF image
    public static void AddBackgroundRectangleEmf(EmfImage image, Color color)
    {
        // Ensure records are loaded
        image.CacheData();

        // If there are no records, nothing to modify
        if (image.Records.Count < 1)
            return;

        // Create a rectangle covering the entire image bounds
        EmfRectangle rectangle = new EmfRectangle
        {
            Box = image.Header.EmfHeader.Bounds
        };

        // Create a brush with the specified background color
        EmfCreateBrushIndirect brush = new EmfCreateBrushIndirect
        {
            LogBrush = new EmfLogBrushEx(),
            IhBrush = 1 // Object handle starts at 1
        };
        brush.LogBrush.Argb32ColorRef = color.ToArgb();

        // Select the brush for drawing
        EmfSelectObject selectObject = new EmfSelectObject
        {
            ObjectHandle = 1
        };

        // Delete the brush after use
        EmfDeleteObject deleteObject = new EmfDeleteObject
        {
            ObjectHandle = 1
        };

        // Insert records at the beginning of the record list
        image.Records.Insert(1, brush);
        image.Records.Insert(2, selectObject);
        image.Records.Insert(3, rectangle);
        image.Records.Insert(4, deleteObject);
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer using Aspose.Imaging for .NET needs to replace an unwanted white background in a vector‑based EMF logo with a custom‑colored canvas before embedding it into a PDF report.
 * 2. When an application must preprocess scanned EMF diagrams by adding a matching background rectangle to hide legacy printer marks that interfere with OCR analysis.
 * 3. When a Windows desktop tool generates EMF charts and the developer wants to ensure the chart’s background blends with the UI theme by programmatically setting the background color via C#.
 * 4. When a batch conversion service processes legacy EMF files and must remove inconsistent background colors to maintain visual consistency across exported PNG thumbnails.
 * 5. When a GIS mapping solution imports EMF map overlays and the developer needs to eliminate the default background so the overlay integrates seamlessly with satellite imagery.
 */