// HOW-TO: Batch Convert JPEG2000 Images to JPEG with 80% Quality in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = @"C:\input\";
            string outputDir = @"C:\output\";

            // Get all JPEG2000 files in the input directory
            string[] inputFiles = Directory.GetFiles(inputDir, "*.jp2");

            foreach (string inputPath in inputFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output path with .jpg extension
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".jpg");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load JPEG2000 image and save as JPEG with quality 80
                using (Jpeg2000Image jpeg2000Image = new Jpeg2000Image(inputPath))
                {
                    JpegOptions jpegOptions = new JpegOptions
                    {
                        Quality = 80
                    };
                    jpeg2000Image.Save(outputPath, jpegOptions);
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
 * 1. When you need to reduce the file size of a large collection of JPEG2000 photos for web publishing by converting them to JPEG with a fixed 80% compression quality.
 * 2. When a digital archive requires all JPEG2000 scans to be transformed into standard JPEG files so that legacy applications can display them without special codec support.
 * 3. When an automated workflow must process incoming JP2 files from a scanner and output JPEGs with consistent quality for downstream image analysis pipelines.
 * 4. When a content management system stores images in JPEG2000 format but the front‑end expects JPEG, you can batch convert them while preserving visual fidelity using a set quality level.
 * 5. When you want to migrate a photo library from JP2 to JPEG on a Windows server, ensuring each file is saved with the same 80% quality to maintain uniform appearance across the collection.
 */
