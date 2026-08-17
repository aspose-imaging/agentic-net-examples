// HOW-TO: Remove Unwanted Background from EMF by Adding Matching Color Rectangle in C# (Aspose.Imaging for .NET)
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
        string outputPath = @"C:\Images\output.emf";

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
                // Cast to EmfImage for record manipulation
                EmfImage emfImage = (EmfImage)metaImage;

                // Add a background rectangle with the desired color (e.g., white)
                AddBackgroundRectangleEmf(emfImage, Color.White);

                // Save the modified image
                emfImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Inserts a rectangle filled with the specified color at the beginning of the EMF records
    public static void AddBackgroundRectangleEmf(EmfImage image, Color color)
    {
        // Ensure records are loaded
        image.CacheData();

        if (image.Records.Count < 1)
        {
            return;
        }

        // Create rectangle covering the whole image bounds
        EmfRectangle rectangle = new EmfRectangle
        {
            Box = image.Header.EmfHeader.Bounds
        };

        // Create a brush with the desired background color
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

        // Delete the brush after drawing the rectangle
        EmfDeleteObject deleteObject = new EmfDeleteObject
        {
            ObjectHandle = 1
        };

        // Insert records at the beginning (index 1 because index 0 is reserved for the header)
        image.Records.Insert(1, brush);
        image.Records.Insert(2, selectObject);
        image.Records.Insert(3, rectangle);
        image.Records.Insert(4, deleteObject);
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to clean up scanned vector graphics that contain a solid‑colored border they want to hide before further processing.
 * 2. When generating reports that embed EMF logos and the logo background must match the document’s white page color.
 * 3. When converting EMF drawings to other formats and the original background interferes with transparent rendering.
 * 4. When preparing EMF assets for a web application that requires a uniform background color to avoid visual artifacts.
 * 5. When automating batch processing of EMF files to replace unwanted colored regions with a specified color using Aspose.Imaging in C#.
 */
