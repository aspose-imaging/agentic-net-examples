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
            // Hardcoded input and output paths
            string inputPath1 = "input1.tif";
            string inputPath2 = "input2.tif";
            string inputPath3 = "input3.tif";
            string outputPath = "output.tif";

            // Verify input files exist
            if (!File.Exists(inputPath1))
            {
                Console.Error.WriteLine($"File not found: {inputPath1}");
                return;
            }
            if (!File.Exists(inputPath2))
            {
                Console.Error.WriteLine($"File not found: {inputPath2}");
                return;
            }
            if (!File.Exists(inputPath3))
            {
                Console.Error.WriteLine($"File not found: {inputPath3}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the first TIFF image and use its frames to create the result image
            using (TiffImage firstImage = (TiffImage)Image.Load(inputPath1))
            {
                // Create a new multi‑frame TIFF using the frames from the first image
                TiffImage resultImage = new TiffImage(firstImage.Frames);

                // Load and add frames from the second image
                using (TiffImage secondImage = (TiffImage)Image.Load(inputPath2))
                {
                    resultImage.Add(secondImage);
                }

                // Load and add frames from the third image
                using (TiffImage thirdImage = (TiffImage)Image.Load(inputPath3))
                {
                    resultImage.Add(thirdImage);
                }

                // Save the concatenated multi‑frame TIFF
                resultImage.Save(outputPath);
                resultImage.Dispose();
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
 * 1. When a developer needs to combine scanned document pages stored as separate TIFF files into a single multi‑frame TIFF for easy archiving or electronic filing.
 * 2. When a medical imaging application must merge individual DICOM‑exported TIFF slices into one multi‑frame TIFF for streamlined patient record storage.
 * 3. When a GIS system requires concatenating separate georeferenced TIFF tiles into a single multi‑frame TIFF to simplify batch processing of satellite imagery.
 * 4. When a digital publishing workflow needs to assemble separate high‑resolution TIFF artwork layers into one multi‑frame TIFF for efficient PDF conversion.
 * 5. When an automated quality‑control tool must read, merge, and save multiple TIFF inspection images as a single multi‑frame TIFF for downstream analysis in C# using Aspose.Imaging.
 */