// HOW-TO: Convert CMX to JPEG with White Background for Transparency in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.cmx";
            string outputPath = @"C:\Images\output.jpg";

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
                // Configure JPEG save options with a background color for transparent regions
                JpegOptions jpegOptions = new JpegOptions
                {
                    // Set the background color (e.g., white) to fill transparent areas
                    VectorRasterizationOptions = new CmxRasterizationOptions
                    {
                        BackgroundColor = Aspose.Imaging.Color.White
                    }
                };

                // Save as JPEG
                cmxImage.Save(outputPath, jpegOptions);
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
 * 1. When you need to display legacy CorelDRAW CMX artwork on the web, converting it to JPEG with a white background prevents transparent‑area artifacts.
 * 2. When generating thumbnails for a document management system, you can rasterize CMX files to JPEG while filling transparent parts with a solid color to keep the images consistent.
 * 3. When automating batch conversion of CMX logos for print catalogs, using Aspose.Imaging in C# ensures each JPEG has a uniform background instead of unwanted gaps.
 * 4. When integrating older CMX graphics into a mobile app, converting them to JPEG with a custom background color avoids visual glitches on devices that don’t support transparency.
 * 5. When preparing CMX illustrations for email newsletters, saving them as JPEG with a defined background eliminates rendering issues in email clients that ignore alpha channels.
 */
