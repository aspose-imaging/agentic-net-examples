// HOW-TO: Create Lossless JPEG2000 From PNG Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg2000;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "c:\\temp\\source.png";
        string outputPath = "c:\\temp\\output.jp2";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the bitmap source
            using (Image sourceImage = Image.Load(inputPath))
            {
                // Configure JPEG2000 options for lossless compression
                Jpeg2000Options options = new Jpeg2000Options
                {
                    Irreversible = false // lossless DWT 5-3
                };

                // Save as JPEG2000
                sourceImage.Save(outputPath, options);
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
 * 1. When you need to archive high‑resolution PNG graphics without quality loss by converting them to JPEG2000 for efficient storage in a .NET application.
 * 2. When a medical imaging system requires lossless conversion of scanned PNG files to JPEG2000 to meet DICOM standards using C#.
 * 3. When a GIS platform must transform satellite PNG tiles into JPEG2000 format while preserving exact pixel data for further analysis.
 * 4. When a digital publishing workflow needs to generate JPEG2000 assets from source PNGs to support lossless printing pipelines in Aspose.Imaging.
 * 5. When an automated batch process in C# must ensure that input PNG images are saved as JPEG2000 with lossless compression for compliance with archival guidelines.
 */
