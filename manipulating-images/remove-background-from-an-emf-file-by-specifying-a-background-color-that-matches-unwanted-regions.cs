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

            // Load the EMF image
            using (MetaImage metaImage = (MetaImage)Image.Load(inputPath))
            {
                // Add a background rectangle of the specified color
                AddBackgroundRectangleEmf((EmfImage)metaImage, Color.Blue);

                // Save the modified image
                metaImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Inserts a rectangle filled with the given color at the beginning of the EMF records
    public static void AddBackgroundRectangleEmf(EmfImage image, Color color)
    {
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

        // Insert records at the beginning of the EMF stream
        image.Records.Insert(1, brush);
        image.Records.Insert(2, selectObject);
        image.Records.Insert(3, rectangle);
        image.Records.Insert(4, deleteObject);
    }
}