using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.bmp";
        string outputPath = @"C:\temp\sample.modified.bmp";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the BMP image
            using (BmpImage bmpImage = new BmpImage(inputPath))
            {
                // Cast to RasterImage to access adjustment methods
                RasterImage rasterImage = (RasterImage)bmpImage;

                // Custom brightness and contrast values
                int brightness = 50;          // Range: -255 to 255
                float contrast = 30f;        // Range: -100 to 100

                // Apply adjustments
                rasterImage.AdjustBrightness(brightness);
                rasterImage.AdjustContrast(contrast);

                // Save the modified image
                rasterImage.Save(outputPath);
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
 * 1. When a desktop application needs to automatically enhance scanned BMP documents by increasing brightness and contrast before archiving them, a developer can use this C# Aspose.Imaging code to adjust the image and save a modified copy.
 * 2. When a game developer wants to dynamically tweak the visual appearance of BMP textures at runtime for different lighting conditions, they can apply custom brightness and contrast values using the RasterImage methods in C#.
 * 3. When a batch‑processing tool must prepare BMP screenshots for OCR by brightening dark areas and boosting contrast, the code demonstrates how to load, modify, and save each image with Aspose.Imaging.
 * 4. When a medical imaging system stores grayscale BMP scans and needs to improve visibility for diagnostic review, a developer can programmatically adjust brightness and contrast in C# and output a new BMP file.
 * 5. When an e‑learning platform generates BMP diagrams and wants to ensure consistent visual quality across devices, the code provides a way to fine‑tune brightness and contrast before delivering the images to users.
 */