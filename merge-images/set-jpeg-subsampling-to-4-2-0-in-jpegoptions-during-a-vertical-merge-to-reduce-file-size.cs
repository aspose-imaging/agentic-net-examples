// HOW-TO: Vertically Merge JPEG Images With 4:2:0 Subsampling In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input image paths
            string[] inputPaths = new string[]
            {
                "input1.jpg",
                "input2.jpg",
                "input3.jpg"
            };

            // Hardcoded output image path
            string outputPath = "merged_output.jpg";

            // Validate each input file exists
            foreach (string inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Collect sizes of all input images
            List<Size> sizes = new List<Size>();
            foreach (string inputPath in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(inputPath))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas size for vertical merge
            int canvasWidth = 0;
            int canvasHeight = 0;
            foreach (Size sz in sizes)
            {
                if (sz.Width > canvasWidth) canvasWidth = sz.Width;
                canvasHeight += sz.Height;
            }

            // Prepare JPEG options
            Source src = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions()
            {
                Source = src,
                Quality = 90
            };

            // Create JPEG canvas bound to the output file
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetY = 0;
                foreach (string inputPath in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(inputPath))
                    {
                        Rectangle bounds = new Rectangle(0, offsetY, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetY += img.Height;
                    }
                }

                // Save the bound image (no path needed)
                canvas.Save();
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
 * 1. When you need to combine several scanned pages into a single JPEG while keeping the file size low by applying 4:2:0 chroma subsampling.
 * 2. When generating a long vertical banner from multiple product photos and want to optimize bandwidth for web delivery using Aspose.Imaging in C#.
 * 3. When creating a printable PDF preview that requires a single high‑resolution JPEG composed of stacked images with reduced color data to meet email attachment limits.
 * 4. When automating the preparation of image sprites for mobile apps, merging icons vertically and using subsampling to satisfy strict storage constraints.
 * 5. When processing camera burst shots into one continuous image for a gallery view, and you need to preserve visual quality while minimizing storage using JPEG options in .NET.
 */
