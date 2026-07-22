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
        string inputPath = @"C:\temp\sample.bmp";
        string outputPath = @"C:\temp\sample_progressive.jpg";

        // Ensure any runtime exception is reported cleanly
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
                // Configure JPEG save options with progressive compression
                JpegOptions saveOptions = new JpegOptions
                {
                    // Set progressive compression mode
                    CompressionType = Aspose.Imaging.FileFormats.Jpeg.JpegCompressionMode.Progressive,
                    // Optional: set quality (1-100)
                    Quality = 90,
                    // Preserve resolution (optional)
                    ResolutionSettings = new ResolutionSetting(96.0, 96.0),
                    ResolutionUnit = ResolutionUnit.Inch
                };

                // Save the image using the configured options
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
 * 1. A developer uses this code to convert high‑resolution BMP screenshots to progressive JPEGs for faster page loads on a website, reducing file size while maintaining visual quality.
 * 2. When building an email marketing system, a programmer applies progressive JPEG compression to attached product images to keep email payloads small and ensure quick rendering in mail clients.
 * 3. A mobile app developer generates progressive JPEG thumbnails from user‑uploaded photos to save bandwidth and storage on devices with limited resources.
 * 4. In a digital asset management workflow, a C# service employs Aspose.Imaging to re‑encode archival BMP files as progressive JPEGs, achieving lower storage costs without losing detail.
 * 5. A content management system (CMS) plugin automatically converts uploaded BMP graphics to progressive JPEG format using JpegOptions, optimizing images for SEO and improving page‑rank‑friendly load times.
 */