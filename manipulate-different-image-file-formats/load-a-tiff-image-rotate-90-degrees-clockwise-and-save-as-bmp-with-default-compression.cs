using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\input.tif";
        string outputPath = @"C:\temp\output.bmp";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to TiffImage to access TIFF-specific operations
                TiffImage tiffImage = (TiffImage)image;

                // Rotate 90 degrees clockwise without changing canvas size
                tiffImage.RotateFlip(RotateFlipType.Rotate90FlipNone);

                // Save the result as BMP using default options
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
 * 1. When converting scanned multi-page TIFF documents to BMP for legacy Windows applications that require a 90‑degree clockwise orientation.
 * 2. When preprocessing medical imaging TIFF files to match the orientation of a display system before saving them as BMP for fast rendering in a C# desktop viewer.
 * 3. When automating a batch job that rotates aerial survey TIFF images taken in portrait mode and stores them as BMP files for compatibility with GIS software that only reads BMP.
 * 4. When integrating Aspose.Imaging in a .NET service that receives TIFF uploads, corrects their orientation by rotating 90 degrees clockwise, and returns BMP thumbnails with default compression.
 * 5. When developing a document management system that normalizes incoming TIFF scans by rotating them and converting them to BMP to reduce file size and simplify downstream processing.
 */