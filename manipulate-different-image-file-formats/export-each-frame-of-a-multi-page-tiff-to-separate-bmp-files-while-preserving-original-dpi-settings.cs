using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\multi.tif";
            string outputDirectory = @"C:\Images\Frames";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load the multi‑page TIFF
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                TiffFrame[] frames = tiffImage.Frames;

                for (int i = 0; i < frames.Length; i++)
                {
                    TiffFrame frame = frames[i];

                    // Prepare BMP save options (default options are sufficient)
                    BmpOptions bmpOptions = new BmpOptions();

                    // Build output file path
                    string outputPath = Path.Combine(outputDirectory, $"frame_{i + 1}.bmp");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the frame as BMP while preserving DPI
                    frame.Save(outputPath, bmpOptions);
                }
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
 * 1. When a developer needs to extract each page of a scanned multi‑page TIFF invoice into individual high‑resolution BMP files for legacy accounting software that only accepts BMP input while keeping the original DPI for accurate scaling.
 * 2. When a developer must convert a multi‑page TIFF medical image (e.g., DICOM‑derived TIFF) into separate BMP frames for integration with a diagnostic tool that requires BMP format and precise DPI metadata for measurements.
 * 3. When a developer wants to split a multi‑page TIFF architectural blueprint into separate BMP layers so that each floor plan can be displayed in a CAD viewer that reads BMP files and respects the original DPI for correct dimensions.
 * 4. When a developer is preparing a batch of multi‑page TIFF photographs for a printing pipeline that only processes BMP images, ensuring each frame retains its DPI to maintain print quality.
 * 5. When a developer needs to archive each page of a multi‑page TIFF legal document as an individual BMP file for a document management system that indexes BMP files and relies on DPI information for searchable metadata.
 */