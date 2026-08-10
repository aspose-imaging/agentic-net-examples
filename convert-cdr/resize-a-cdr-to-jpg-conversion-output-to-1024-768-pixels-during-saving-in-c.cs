// HOW-TO: Resize CDR to JPEG 1024x768 While Saving in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        // Wrap the whole logic to catch unexpected exceptions
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\sample.cdr";
            string outputPath = @"C:\Images\sample_converted.jpg";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR file
            using (Image image = Image.Load(inputPath))
            {
                // Prepare JPEG save options with rasterization settings to obtain 1024×768 size
                var rasterOptions = new CdrRasterizationOptions
                {
                    PageWidth = 1024,
                    PageHeight = 768,
                    // Optional: set a background color to avoid transparency issues
                    BackgroundColor = Color.White
                };

                var jpegOptions = new JpegOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the image as JPEG with the specified size
                image.Save(outputPath, jpegOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any error without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to convert a CorelDRAW (.cdr) file to a JPEG thumbnail of exact 1024×768 pixels for web preview.
 * 2. When an automated batch process must generate fixed‑size JPEGs from CDR assets for a content management system.
 * 3. When you want to ensure a consistent image dimension for printing or UI layout by rasterizing CDR pages to 1024×768 JPEGs.
 * 4. When integrating Aspose.Imaging into a C# application that must resize vector graphics during export to meet email attachment size limits.
 * 5. When you have to programmatically convert and resize CDR drawings to JPEG with a white background to avoid transparency issues.
 */
