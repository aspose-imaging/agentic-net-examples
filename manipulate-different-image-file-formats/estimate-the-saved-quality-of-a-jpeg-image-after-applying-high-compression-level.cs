using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.bmp";
        string outputPath = @"C:\temp\sample_compressed.jpg";

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

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure JPEG save options with high compression (low quality)
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 10, // Quality range 1-100; lower value = higher compression
                    CompressionType = JpegCompressionMode.Baseline
                };

                // Save the image with the specified JPEG options
                image.Save(outputPath, jpegOptions);

                // Report the quality setting used
                Console.WriteLine($"Saved JPEG with quality setting: {jpegOptions.Quality}");
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
 * 1. When a C# developer needs to generate a low‑size JPEG preview of a high‑resolution BMP for a web gallery, they can use Aspose.Imaging to apply a high compression level (quality = 10) and quickly estimate the resulting image quality.
 * 2. When an application must reduce storage costs by converting large bitmap assets to highly compressed JPEG files, the code demonstrates how to set the JpegOptions quality parameter and verify the saved quality setting in .NET.
 * 3. When sending images via email from a .NET service, a developer can use this snippet to compress BMP files into small JPEG attachments, ensuring the compression mode (Baseline) and quality level are appropriate for bandwidth‑limited environments.
 * 4. When building a mobile app that displays thumbnail placeholders before loading full‑resolution pictures, the code shows how to generate a JPEG with aggressive compression to test visual acceptability while keeping the file size minimal.
 * 5. When performing automated regression testing of image‑processing pipelines, a tester can employ this example to programmatically compress source BMP images, record the JPEG quality value, and compare the output size and visual fidelity across different quality settings.
 */