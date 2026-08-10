// HOW-TO: Load JPEG2000 Image With Limited Buffer And Get Resolution In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.ImageLoadOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.jp2";
        string outputPath = @"C:\temp\resolution.txt";

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

            // Set up JPEG2000 load options with a limited buffer size (e.g., 4 MB)
            var loadOptions = new Jpeg2000LoadOptions
            {
                BufferSizeHint = 4 * 1024 * 1024 // 4 MB
            };

            // Load the JPEG2000 image using the specified load options
            using (Image img = Image.Load(inputPath, loadOptions))
            {
                // Cast to Jpeg2000Image to access resolution properties
                var jpeg2000Image = img as Jpeg2000Image;
                if (jpeg2000Image == null)
                {
                    Console.Error.WriteLine("Loaded image is not a JPEG2000 image.");
                    return;
                }

                // Retrieve horizontal and vertical resolution (PPI)
                double horizontalResolution = jpeg2000Image.HorizontalResolution;
                double verticalResolution = jpeg2000Image.VerticalResolution;

                // Display resolutions on console
                Console.WriteLine($"Horizontal Resolution: {horizontalResolution} DPI");
                Console.WriteLine($"Vertical Resolution: {verticalResolution} DPI");

                // Write resolutions to the output file
                string outputContent = $"Horizontal Resolution: {horizontalResolution} DPI{Environment.NewLine}" +
                                       $"Vertical Resolution: {verticalResolution} DPI{Environment.NewLine}";
                File.WriteAllText(outputPath, outputContent);
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
 * 1. When processing large JPEG2000 files on a server with limited RAM, you can load the image using a small buffer and read its DPI without exhausting memory.
 * 2. When building a document conversion tool that needs to preserve original image resolution, this code extracts horizontal and vertical DPI from a JP2 file before resizing.
 * 3. When generating print‑ready PDFs from high‑resolution scans, you can quickly obtain the source image’s resolution to set the correct page scaling.
 * 4. When validating incoming medical imaging data (e.g., DICOM JPEG2000) you can verify that the image meets required resolution specifications without loading the full pixel data.
 * 5. When creating a thumbnail service that logs image metadata, you can read the JPEG2000 resolution efficiently and store it in a log file for later analysis.
 */
