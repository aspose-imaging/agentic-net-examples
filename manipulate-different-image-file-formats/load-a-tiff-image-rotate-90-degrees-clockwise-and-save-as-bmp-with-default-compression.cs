using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.tif";
            string outputPath = @"C:\temp\output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image, rotate 90° clockwise, and save as BMP
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Rotate 90 degrees clockwise without flipping
                tiffImage.RotateFlip(RotateFlipType.Rotate90FlipNone);

                // Save as BMP using default options
                tiffImage.Save(outputPath, new BmpOptions());
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
 * 1. When a developer needs to convert a scanned TIFF file to BMP using C# and Aspose.Imaging so that legacy Windows software that only reads BMP can display the image.
 * 2. When an image‑processing workflow must rotate a portrait‑oriented TIFF image 90° clockwise before saving it as a BMP with default compression for downstream analysis.
 * 3. When a batch job processes medical TIFF scans, rotates them to the correct orientation, and outputs BMP files to provide fast, low‑memory previews in a web portal.
 * 4. When a desktop utility built with C# has to ensure a TIFF image is correctly oriented and saved as a BMP thumbnail for printing on older printers that require BMP format.
 * 5. When a C# application uses Aspose.Imaging to accept user‑uploaded TIFF photos, automatically rotate them 90° clockwise, and store them as BMP files for a gallery that only supports BMP images.
 */