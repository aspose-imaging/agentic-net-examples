// HOW-TO: Save JPEG With Baseline Compression For Legacy Viewer Compatibility In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\temp\sample.bmp";
            string outputPath = @"C:\temp\output_baseline.jpg";

            // Verify input file exists
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
                // Set JPEG save options with Baseline compression
                JpegOptions saveOptions = new JpegOptions
                {
                    CompressionType = JpegCompressionMode.Baseline,
                    Quality = 90 // optional quality setting
                };

                // Save the image as JPEG using the configured options
                image.Save(outputPath, saveOptions);
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
 * 1. When you need to convert BMP files to JPEG that can be opened by older web browsers or legacy image viewers, you set the JPEG compression mode to Baseline.
 * 2. When an application must generate thumbnails for archival PDFs and ensure the JPEGs are compatible with legacy printing hardware, using Baseline compression guarantees compliance.
 * 3. When a photo‑sharing service wants to reduce file size while maintaining maximum compatibility across mobile devices released before 2010, saving with Baseline JPEG is required.
 * 4. When a batch‑processing script creates JPEG assets for an e‑learning platform that still uses outdated image libraries, configuring the CompressionType to Baseline prevents rendering errors.
 * 5. When you integrate Aspose.Imaging into a C# workflow that prepares product images for an older ERP system, setting Baseline compression ensures the ERP can display the images without conversion failures.
 */
