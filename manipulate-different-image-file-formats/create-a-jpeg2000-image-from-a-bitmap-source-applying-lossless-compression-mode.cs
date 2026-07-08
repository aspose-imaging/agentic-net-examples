using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg2000;

public class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/source.png";
        string outputPath = "Output/result.jp2";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the bitmap source as a raster image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Configure JPEG2000 options for lossless compression (default)
                Jpeg2000Options options = new Jpeg2000Options
                {
                    Irreversible = false // lossless DWT 5-3
                };

                // Create JPEG2000 image from the raster source
                using (Jpeg2000Image jpeg2000Image = new Jpeg2000Image(raster))
                {
                    // Save the JPEG2000 image with the specified options
                    jpeg2000Image.Save(outputPath, options);
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
 * 1. When a developer needs to archive high‑resolution PNG graphics as lossless JPEG2000 files for long‑term storage using C# and Aspose.Imaging, this code converts the bitmap to a JP2 image without quality loss.
 * 2. When an application must prepare medical or scientific images for secure transmission in a format that supports lossless compression, the snippet creates a JPEG2000 file from a raster source while preserving diagnostic detail.
 * 3. When a GIS system requires converting satellite PNG tiles into JPEG2000 to reduce file size without sacrificing spatial accuracy, the example demonstrates the C# workflow for lossless DWT compression.
 * 4. When a digital asset management platform needs to generate web‑ready, losslessly compressed JPEG2000 previews from user‑uploaded PNGs, this code provides a straightforward conversion pipeline.
 * 5. When a developer is building a batch processing tool that normalizes various bitmap formats into a single lossless JPEG2000 archive for compliance reporting, the sample shows how to load, configure, and save the images in .NET.
 */