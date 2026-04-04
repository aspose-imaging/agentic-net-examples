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
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Images\input.emf";
        string outputPath = @"C:\Images\output\ChangedBackground_input.emf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EMF image, add a background rectangle, and save the result
        using (MetaImage metaImage = (MetaImage)Image.Load(inputPath))
        {
            // Cast to EmfImage to access EMF‑specific members
            AddBackgroundRectangleEmf((EmfImage)metaImage, Color.Blue);

            // Save the modified image
            metaImage.Save(outputPath);
        }
    }

    /// <summary>
    /// Inserts a rectangle filled with the specified color at the bottom of the EMF record list.
    /// This effectively changes the background color of the image.
    /// </summary>
    /// <param name="image">The EMF image to modify.</param>
    /// <param name="color">The background color to apply.</param>
    public static void AddBackgroundRectangleEmf(EmfImage image, Color color)
    {
        // Ensure all records are loaded into memory
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
            IhBrush = 1 // Object handle (must be > 0)
        };
        brush.LogBrush.Argb32ColorRef = color.ToArgb();

        // Select the brush for subsequent drawing operations
        EmfSelectObject selectObject = new EmfSelectObject
        {
            ObjectHandle = 1
        };

        // Delete the brush after drawing the rectangle to clean up the object table
        EmfDeleteObject deleteObject = new EmfDeleteObject
        {
            ObjectHandle = 1
        };

        // Insert the new records at the beginning of the record list
        // Index 0 inserts before all existing drawing commands
        image.Records.Insert(0, brush);
        image.Records.Insert(1, selectObject);
        image.Records.Insert(2, rectangle);
        image.Records.Insert(3, deleteObject);
    }
}