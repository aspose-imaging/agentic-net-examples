using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using System.Drawing;

class PsdProcessor
{
    static void Main()
    {
        // Path to the source PSD file
        string inputPath = @"C:\Images\source.psd";

        // Path where the modified PSD will be saved
        string outputPath = @"C:\Images\modified.psd";

        // Load the PSD document (Aspose.Imaging automatically detects the format)
        using (Image image = Image.Load(inputPath))
        {
            // Cast to a raster image to access common editing methods
            // Most PSD files are loaded as RasterImage derivatives
            var raster = image as RasterImage;
            if (raster == null)
            {
                Console.WriteLine("The loaded file is not a raster image and cannot be edited with this example.");
                return;
            }

            // Example edit: increase brightness by 30 units
            raster.AdjustBrightness(30);

            // Example edit: rotate the image 15 degrees clockwise
            raster.Rotate(15);

            // Example edit: convert the image to grayscale
            raster.Grayscale();

            // Save the edited PSD back to disk, preserving the original format
            raster.Save(outputPath);
        }

        Console.WriteLine("PSD processing completed successfully.");
    }
}