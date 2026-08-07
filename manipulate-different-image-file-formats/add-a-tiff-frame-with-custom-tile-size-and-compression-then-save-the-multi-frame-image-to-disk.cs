// HOW-TO: Create Multi‑Frame TIFF from Multiple PNG Images in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output file path
            string outputPath = "C:\\Temp\\multi_frame.tif";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Input file paths
            string inputPath1 = "C:\\Temp\\frame1.png";
            if (!File.Exists(inputPath1))
            {
                Console.Error.WriteLine($"File not found: {inputPath1}");
                return;
            }

            string inputPath2 = "C:\\Temp\\frame2.png";
            if (!File.Exists(inputPath2))
            {
                Console.Error.WriteLine($"File not found: {inputPath2}");
                return;
            }

            // Load input images
            using (RasterImage img1 = (RasterImage)Image.Load(inputPath1))
            using (RasterImage img2 = (RasterImage)Image.Load(inputPath2))
            {
                int width = img1.Width;
                int height = img1.Height;

                // Create TIFF options
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                // Create multi-frame TIFF
                using (TiffImage tiff = (TiffImage)Image.Create(tiffOptions, width, height))
                {
                    // First frame
                    tiff.SavePixels(tiff.Bounds, img1.LoadPixels(img1.Bounds));

                    // Add second frame
                    tiff.AddFrame(new TiffFrame(tiffOptions, width, height));
                    tiff.Frames[1].SavePixels(tiff.Frames[1].Bounds, img2.LoadPixels(img2.Bounds));

                    // Save the TIFF file
                    tiff.Save(outputPath);
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
 * 1. When you need to combine several PNG scans into a single multi‑page TIFF document for archival or printing.
 * 2. When an application must generate a multi‑frame TIFF on the fly from user‑uploaded images using C# and Aspose.Imaging.
 * 3. When you want to produce a TIFF file that can be opened as separate pages in viewers like Adobe Acrobat or Windows Photo Viewer.
 * 4. When you need to programmatically assemble a multi‑page TIFF for fax transmission or medical imaging workflows.
 * 5. When you are building a batch process that converts a set of PNG files into a multi‑frame TIFF for efficient storage and distribution.
 */
