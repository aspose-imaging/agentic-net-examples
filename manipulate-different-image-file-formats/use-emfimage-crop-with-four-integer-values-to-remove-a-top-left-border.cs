// HOW-TO: Crop Left and Top Border from EMF and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.emf";
            string outputPath = @"C:\Images\sample_cropped.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to EmfImage to access EMF-specific methods
                EmfImage emfImage = (EmfImage)image;

                // Define border sizes to remove from the top-left corner
                int leftBorder = 20;   // pixels to remove from the left side
                int topBorder = 30;    // pixels to remove from the top side

                // Crop using shifts: leftShift, rightShift, topShift, bottomShift
                emfImage.Crop(leftBorder, 0, topBorder, 0);

                // Save the cropped image as PNG
                emfImage.Save(outputPath, new PngOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to remove unwanted margins from a vector EMF file before converting it to a PNG for web display.
 * 2. When an automated reporting system generates EMF charts with extra whitespace that must be trimmed programmatically in C#.
 * 3. When you are building a batch image‑processing pipeline that standardizes the size of EMF assets by cropping the top‑left border and saving them as PNGs.
 * 4. When a legacy application exports diagrams as EMF and you must prepare them for inclusion in a PDF by removing the border and converting to PNG.
 * 5. When you want to programmatically clean up scanned EMF drawings by cutting off a fixed number of pixels from the left and top edges using Aspose.Imaging in .NET.
 */
