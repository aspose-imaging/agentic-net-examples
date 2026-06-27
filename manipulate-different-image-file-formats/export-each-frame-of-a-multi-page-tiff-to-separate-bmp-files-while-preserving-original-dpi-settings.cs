using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output locations
        string inputPath = @"C:\Images\multi_page.tif";
        string outputDirectory = @"C:\Images\Frames";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the multi‑page TIFF
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Iterate over each frame in the TIFF
                for (int i = 0; i < tiffImage.Frames.Length; i++)
                {
                    TiffFrame frame = tiffImage.Frames[i];

                    // Build the output BMP path (preserving original DPI automatically)
                    string outputPath = Path.Combine(outputDirectory, $"frame_{i + 1}.bmp");

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the current frame as a BMP file
                    frame.Save(outputPath, new BmpOptions());
                }
            }
        }
        catch (Exception ex)
        {
            // Report any unexpected errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to extract individual scanned pages from a multi‑page TIFF document and save them as high‑resolution BMP files for legacy printing systems that require BMP input.
 * 2. When a medical imaging application must separate each frame of a multi‑page DICOM‑converted TIFF into BMP images while keeping the original DPI for accurate measurements.
 * 3. When a GIS (Geographic Information System) tool has to convert multi‑page satellite TIFF layers into separate BMP tiles for compatibility with older mapping software.
 * 4. When an archival workflow requires converting each page of a multi‑page TIFF manuscript into BMP files to preserve the original DPI before performing OCR processing.
 * 5. When a digital asset management system needs to generate BMP thumbnails for each frame of a multi‑page TIFF to maintain consistent resolution across different display devices.
 */