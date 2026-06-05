using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.tif";
        string outputPath = @"C:\Images\output.bmp";

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

            // Load the TIFF image
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Rotate 90 degrees clockwise without flipping
                tiffImage.RotateFlip(RotateFlipType.Rotate90FlipNone);

                // Save as BMP with default options
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
 * 1. When a medical imaging application receives scanned DICOM TIFF files that need to be displayed in a Windows desktop viewer that only supports BMP, a developer can use this code to rotate the image 90° clockwise and convert it to BMP.
 * 2. When an archival system processes legacy TIFF photographs that were scanned in portrait orientation and must be stored as BMP thumbnails for quick preview, this snippet rotates the image and saves it with default compression.
 * 3. When a GIS mapping tool imports geospatial TIFF layers that are oriented incorrectly and the downstream engine requires BMP tiles, a developer can apply the RotateFlip operation and save the result as BMP.
 * 4. When an e‑commerce platform receives product scans as TIFF files from vendors and needs to generate BMP assets for legacy point‑of‑sale terminals, this code rotates the image to match the display orientation and converts it.
 * 5. When an automated batch job extracts scanned forms in TIFF format, corrects their orientation by rotating 90 degrees clockwise, and stores them as BMP files for legacy OCR software, this example provides the necessary C# implementation.
 */