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
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.emf";
            string outputPath = @"C:\Images\output.emf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EMF image, add background rectangle, and save
            using (MetaImage meta = (MetaImage)Image.Load(inputPath))
            {
                AddBackgroundRectangleEmf((EmfImage)meta, Color.Blue);
                meta.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Inserts a rectangle filled with the specified color at the beginning of the EMF records.
    public static void AddBackgroundRectangleEmf(EmfImage image, Color color)
    {
        image.CacheData();
        if (image.Records.Count < 1)
        {
            return;
        }

        // Rectangle covering the entire image bounds
        EmfRectangle rectangle = new EmfRectangle();
        rectangle.Box = image.Header.EmfHeader.Bounds;

        // Brush with the desired background color
        EmfCreateBrushIndirect brush = new EmfCreateBrushIndirect();
        brush.LogBrush = new EmfLogBrushEx();
        brush.LogBrush.Argb32ColorRef = color.ToArgb();
        brush.IhBrush = 1; // Object handle (starts at 1)

        // Select the brush
        EmfSelectObject selectObject = new EmfSelectObject();
        selectObject.ObjectHandle = 1;

        // Delete the brush after drawing
        EmfDeleteObject deleteObject = new EmfDeleteObject();
        deleteObject.ObjectHandle = 1;

        // Insert records at the start of the EMF stream
        image.Records.Insert(1, brush);
        image.Records.Insert(2, selectObject);
        image.Records.Insert(3, rectangle);
        image.Records.Insert(4, deleteObject);
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to replace an unwanted solid background in legacy EMF files with a color that matches the surrounding UI theme before embedding the vector graphics in a .NET application.
 * 2. When generating printable reports that include EMF logos whose original canvas color must be overwritten with the report’s background color to prevent visual seams.
 * 3. When batch‑processing scanned EMF diagrams that contain a blue margin and the code must programmatically add a rectangle of the document’s page color to hide the margin.
 * 4. When building a custom branding tool that inserts a corporate‑colored background rectangle into third‑party EMF icons so they seamlessly blend with the application’s color scheme.
 * 5. When cleaning up EMF assets exported from CAD software where the default background clashes with a dark UI, and a C# routine is required to prepend a matching‑color rectangle to each file.
 */