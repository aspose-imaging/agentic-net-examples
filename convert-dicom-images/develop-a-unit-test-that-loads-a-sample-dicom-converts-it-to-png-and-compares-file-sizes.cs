// HOW-TO: How To Load DICOM, Convert To PNG And Compare File Sizes In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "sample.dcm";
        string outputPath = "sample.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load DICOM image
            using (Image dicomImage = Image.Load(inputPath))
            {
                // Convert and save as PNG
                dicomImage.Save(outputPath, new PngOptions());
            }

            // Compare file sizes
            long dicomSize = new FileInfo(inputPath).Length;
            long pngSize = new FileInfo(outputPath).Length;

            Console.WriteLine($"DICOM size: {dicomSize} bytes");
            Console.WriteLine($"PNG size:   {pngSize} bytes");

            if (pngSize < dicomSize)
            {
                Console.WriteLine("PNG file is smaller than the original DICOM file.");
            }
            else if (pngSize == dicomSize)
            {
                Console.WriteLine("PNG file size is equal to the original DICOM file size.");
            }
            else
            {
                Console.WriteLine("PNG file is larger than the original DICOM file.");
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
 * 1. When you need to verify that converting medical DICOM images to PNG reduces storage requirements in a C# application.
 * 2. When you want to automate a regression test that ensures PNG output remains smaller or equal to the original DICOM file after code changes.
 * 3. When you are building a PACS integration and must confirm that exported PNG thumbnails fit within bandwidth constraints.
 * 4. When you need to log file size differences for compliance reporting after converting diagnostic images to a web‑friendly format.
 * 5. When you are troubleshooting image conversion performance and want to compare raw DICOM size with the resulting PNG in a unit test.
 */
