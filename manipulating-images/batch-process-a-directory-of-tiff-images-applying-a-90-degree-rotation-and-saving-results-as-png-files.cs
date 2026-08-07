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
            // Hardcoded input and output directories
            string inputDir = @"C:\Images\Input";
            string outputDir = @"C:\Images\Output";

            // Get all TIFF files in the input directory
            string[] tiffFiles = Directory.GetFiles(inputDir, "*.tif");

            foreach (string inputPath in tiffFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output PNG path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileNameWithoutExt + ".png");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the TIFF image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to TiffImage to access rotation methods
                    TiffImage tiffImage = image as TiffImage;
                    if (tiffImage != null)
                    {
                        // Rotate 90 degrees clockwise without flipping
                        tiffImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    }

                    // Save the result as PNG
                    image.Save(outputPath, new PngOptions());
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
 * 1. When a medical imaging system receives scanned DICOM pages saved as TIFF files that need to be re‑oriented and delivered to a web portal as PNG thumbnails.
 * 2. When an archival project must convert a folder of legacy scanned documents in TIFF format to PNG after rotating them 90° to match the correct page orientation for online viewing.
 * 3. When a publishing workflow automates the preparation of high‑resolution TIFF artwork by rotating each page and exporting it as PNG for inclusion in e‑books.
 * 4. When a GIS application processes satellite imagery stored as TIFF tiles, rotates them to align with map coordinates, and saves them as PNG for faster rendering in a web map.
 * 5. When a batch job for a printing company needs to re‑orient incoming TIFF proofs and convert them to PNG files for quality‑control inspection on a Windows server.
 */