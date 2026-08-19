// HOW-TO: Read Multi‑Page TIFF and Calculate Frame Duration from Resolution in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output\\output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TiffImage tiff = (TiffImage)Image.Load(inputPath))
            {
                int frameIndex = 0;
                foreach (TiffFrame frame in tiff.Frames)
                {
                    // Compute a simple duration based on frame resolution (pixels per inch)
                    // Example: duration = (horizontal resolution + vertical resolution) / 2 milliseconds
                    double hRes = tiff.HorizontalResolution;
                    double vRes = tiff.VerticalResolution;
                    int duration = (int)((hRes + vRes) / 2);

                    Console.WriteLine($"Frame {frameIndex}: Duration = {duration} ms");
                    frameIndex++;
                }

                // Save the (unchanged) TIFF to the output path
                tiff.Save(outputPath);
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
 * 1. When you need to extract each page of a multi‑page TIFF and determine how long each frame should be displayed based on its DPI for creating a timed slideshow.
 * 2. When building a document viewer that reads scanned PDFs saved as TIFF stacks and adjusts animation speed according to the image resolution.
 * 3. When converting high‑resolution scanned images into a lightweight animated TIFF where frame delays are derived from the original horizontal and vertical resolution values.
 * 4. When validating that all pages in a multi‑page TIFF have consistent resolution before processing them further in a C# imaging pipeline.
 * 5. When generating metadata reports that list each TIFF frame’s calculated display duration for quality‑control or archival purposes.
 */
