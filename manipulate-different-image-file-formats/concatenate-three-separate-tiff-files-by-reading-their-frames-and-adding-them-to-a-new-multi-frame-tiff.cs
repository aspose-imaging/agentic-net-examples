// HOW-TO: Combine Multiple TIFF Files into a Single Multi‑Frame TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath1 = @"C:\Images\input1.tif";
            string inputPath2 = @"C:\Images\input2.tif";
            string inputPath3 = @"C:\Images\input3.tif";
            string outputPath = @"C:\Images\output.tif";

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

            // Collect all frames from the three source TIFFs
            List<TiffFrame> allFrames = new List<TiffFrame>();

            // Helper to load frames from a TIFF file
            void LoadFrames(string path)
            {
                using (TiffImage srcImage = (TiffImage)Image.Load(path))
                {
                    foreach (TiffFrame srcFrame in srcImage.Frames)
                    {
                        // Create a copy of the frame to detach it from the source image
                        TiffFrame copiedFrame = new TiffFrame((RasterImage)srcFrame);
                        allFrames.Add(copiedFrame);
                    }
                }
            }

            LoadFrames(inputPath1);
            LoadFrames(inputPath2);
            LoadFrames(inputPath3);

            // Create a new multi‑frame TIFF from the collected frames
            using (TiffImage resultImage = new TiffImage(allFrames.ToArray()))
            {
                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the concatenated TIFF
                resultImage.Save(outputPath);
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
 * 1. When you need to merge scanned document pages stored as separate TIFF files into one multi‑page TIFF for easier distribution.
 * 2. When creating a PDF‑like image sequence by combining individual TIFF frames from different sources into a single file for archival.
 * 3. When a medical imaging system outputs separate TIFF slices and you must assemble them into a single multi‑frame TIFF for DICOM compatibility.
 * 4. When automating a batch process that consolidates daily generated TIFF reports into one file to reduce file‑management overhead.
 * 5. When building a web service that receives multiple TIFF uploads and returns a single multi‑page TIFF for client consumption.
 */
