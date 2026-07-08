using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\input.jpg";
        string outputPath = @"C:\Images\output_300dpi.jpg";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure JPEG save options with 300 DPI resolution
                JpegOptions saveOptions = new JpegOptions
                {
                    // Set horizontal and vertical DPI to 300
                    ResolutionSettings = new ResolutionSetting(300.0, 300.0),
                    // Specify that the resolution unit is inches (dots per inch)
                    ResolutionUnit = ResolutionUnit.Inch,
                    // Optional: keep default quality (100) and other settings
                    Quality = 100
                };

                // Save the image with the specified DPI
                image.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When preparing product photos for high‑resolution print catalogs, a developer can use the code to convert source JPEGs to 300 DPI images so the printed pages retain sharp detail.
 * 2. When generating printable marketing flyers from web‑optimized images, the snippet ensures the output JPEG is saved with a 300 DPI resolution unit (inch) required by commercial printers.
 * 3. When a document‑management system needs to archive scanned documents as JPEGs that meet archival standards, the code sets both horizontal and vertical DPI to 300 using Aspose.Imaging’s JpegOptions.
 * 4. When an e‑learning platform creates downloadable course handouts, the developer can apply this code to embed a 300 DPI resolution into the JPEG so that students can print the material without loss of quality.
 * 5. When a medical imaging application exports diagnostic images to JPEG for inclusion in patient reports, the snippet guarantees the images are saved at 300 DPI, satisfying regulatory requirements for print clarity.
 */