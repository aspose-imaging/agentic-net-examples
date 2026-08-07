using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input BMP file paths
            string[] inputPaths = new string[]
            {
                @"C:\temp\image1.bmp",
                @"C:\temp\image2.bmp",
                @"C:\temp\image3.bmp"
            };

            // Hardcoded output TIFF file path
            string outputPath = @"C:\temp\output.tif";

            // Verify each input file exists
            foreach (string inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load each BMP and create a corresponding TiffFrame
            List<TiffFrame> frames = new List<TiffFrame>();
            foreach (string inputPath in inputPaths)
            {
                using (Image img = Image.Load(inputPath))
                {
                    // Cast to RasterImage (BMP loads as RasterImage)
                    RasterImage raster = img as RasterImage;
                    if (raster == null)
                    {
                        Console.Error.WriteLine($"Unsupported image format: {inputPath}");
                        return;
                    }

                    // Create a TiffFrame from the raster image
                    TiffFrame frame = new TiffFrame(raster);
                    frames.Add(frame);
                    // Do not dispose the frame here; it will be disposed by TiffImage
                }
            }

            // Create a multi‑page TIFF image from the frames
            using (TiffImage tiffImage = new TiffImage(frames.ToArray()))
            {
                // Save the TIFF to the specified output path
                tiffImage.Save(outputPath);
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
 * 1. When a developer needs to combine multiple BMP scans of receipts into a single multi‑page TIFF using Aspose.Imaging for .NET for easy email attachment and archival.
 * 2. When a developer wants to generate a multi‑page TIFF from BMP tiles of satellite imagery with Aspose.Imaging for .NET for GIS analysis.
 * 3. When a developer must create a multi‑page TIFF from BMP screenshots captured during automated UI testing, leveraging Aspose.Imaging for .NET to embed the images in a test report.
 * 4. When a developer is building a document management system that converts BMP scans of handwritten forms into a searchable multi‑page TIFF via Aspose.Imaging for .NET.
 * 5. When a developer needs to batch‑process BMP medical images and stack them into a single TIFF using Aspose.Imaging for .NET for compatibility with radiology PACS systems.
 */