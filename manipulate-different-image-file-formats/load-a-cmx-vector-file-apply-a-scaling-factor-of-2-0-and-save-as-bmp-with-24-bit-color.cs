// HOW-TO: Scale CMX Vector Image by 2 and Save as 24‑Bit BMP in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.cmx";
            string outputPath = @"C:\Images\output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CMX image
            using (CmxImage cmxImage = (CmxImage)Image.Load(inputPath))
            {
                // Apply scaling factor of 2.0
                int newWidth = cmxImage.Width * 2;
                int newHeight = cmxImage.Height * 2;
                cmxImage.Resize(newWidth, newHeight);

                // Prepare BMP save options for 24‑bit color
                BmpOptions bmpOptions = new BmpOptions
                {
                    BitsPerPixel = 24
                };

                // Save as BMP
                cmxImage.Save(outputPath, bmpOptions);
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
 * 1. When you need to convert legacy CorelDRAW CMX drawings to a high‑resolution 24‑bit BMP for printing or archival purposes.
 * 2. When a desktop application must enlarge a vector diagram twice its original size before exporting it to a bitmap format for use in reports.
 * 3. When an automated batch process has to resize CMX assets and store them as BMP files compatible with older Windows applications.
 * 4. When integrating Aspose.Imaging into a C# service that receives CMX files, scales them for thumbnail generation, and saves them as 24‑bit BMP images.
 * 5. When migrating graphic assets from a vector‑only workflow to a raster‑only pipeline that requires BMP output with specific color depth.
 */
