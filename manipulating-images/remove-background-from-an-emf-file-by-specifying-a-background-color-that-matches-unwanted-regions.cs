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

            // Load the EMF image
            using (MetaImage metaImage = (MetaImage)Image.Load(inputPath))
            {
                // Cast to EmfImage for record manipulation
                EmfImage emfImage = (EmfImage)metaImage;

                // Add a background rectangle with the desired color (e.g., white)
                AddBackgroundRectangleEmf(emfImage, Color.White);

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the modified image
                emfImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    /// <summary>
    /// Inserts a rectangle filled with the specified background color at the beginning of the EMF records.
    /// This effectively replaces unwanted background regions with the chosen color.
    /// </summary>
    /// <param name="image">The EMF image to modify.</param>
    /// <param name="color">The background color to apply.</param>
    public static void AddBackgroundRectangleEmf(EmfImage image, Color color)
    {
        // Ensure the image data is cached before modifying records
        image.CacheData();

        // If there are no records, nothing to modify
        if (image.Records.Count < 1)
        {
            return;
        }

        // Create a rectangle that covers the entire image bounds
        EmfRectangle rectangle = new EmfRectangle
        {
            Box = image.Header.EmfHeader.Bounds
        };

        // Create a brush with the desired background color
        EmfCreateBrushIndirect brush = new EmfCreateBrushIndirect
        {
            LogBrush = new EmfLogBrushEx(),
            IhBrush = 1 // Object handle index (starts at 1)
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

        // Insert the new records at the beginning of the record list
        // Insert order: brush, select brush, rectangle, delete brush
        image.Records.Insert(1, brush);
        image.Records.Insert(2, selectObject);
        image.Records.Insert(3, rectangle);
        image.Records.Insert(4, deleteObject);
    }
}