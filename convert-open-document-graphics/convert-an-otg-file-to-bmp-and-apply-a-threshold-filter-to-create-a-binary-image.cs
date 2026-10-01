// HOW-TO: Convert OTG to BMP with Fixed Threshold Binarization in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        string inputPath = "input\\input.otg";
        string outputPath = "output\\output.bmp";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = image as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
                    return;
                }

                // Apply fixed threshold binarization (threshold value 128)
                raster.BinarizeFixed(128);

                // Save as BMP
                BmpOptions bmpOptions = new BmpOptions();
                raster.Save(outputPath, bmpOptions);
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
 * 1. When you need to prepare scanned engineering drawings in OTG format for legacy systems that only accept BMP, applying a binary threshold to simplify the image.
 * 2. When converting OTG files from a medical imaging device into BMP for a Windows application that requires monochrome images.
 * 3. When automating a batch process that extracts high‑contrast outlines from OTG maps by binarizing them before OCR or pattern recognition.
 * 4. When integrating Aspose.Imaging into a document workflow that transforms proprietary OTG graphics into BMP thumbnails with a fixed threshold for consistent visual quality.
 * 5. When developing a C# utility that reduces OTG file size by converting to BMP and applying a 128‑level threshold to create a binary image for faster network transmission.
 */
