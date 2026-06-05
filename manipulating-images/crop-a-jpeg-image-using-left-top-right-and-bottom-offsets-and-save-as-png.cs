using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\input.jpg";
        string outputPath = @"C:\Images\output.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the JPEG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access the Crop overload with shifts
                RasterImage raster = (RasterImage)image;

                // Define cropping offsets (left, right, top, bottom)
                int leftShift = 10;   // pixels to remove from the left
                int rightShift = 10;  // pixels to remove from the right
                int topShift = 20;    // pixels to remove from the top
                int bottomShift = 20; // pixels to remove from the bottom

                // Perform the crop operation
                raster.Crop(leftShift, rightShift, topShift, bottomShift);

                // Save the cropped image as PNG
                raster.Save(outputPath, new PngOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}