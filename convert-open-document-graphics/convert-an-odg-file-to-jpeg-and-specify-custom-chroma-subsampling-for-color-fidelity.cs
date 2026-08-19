// HOW-TO: Convert ODG to JPEG with Custom Chroma Subsampling in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = Path.Combine("Input", "sample.odg");
            string outputPath = Path.Combine("Output", "sample.jpg");

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure JPEG options with custom chroma subsampling
                var jpegOptions = new JpegOptions
                {
                    // Set YCbCr color type to enable chroma subsampling
                    ColorType = JpegCompressionColorMode.YCbCr,
                    // Example 2:2:2 subsampling for all components
                    HorizontalSampling = new byte[] { 2, 2, 2 },
                    VerticalSampling = new byte[] { 2, 2, 2 },
                    // Optional quality setting
                    Quality = 90
                };

                // Set vector rasterization options for the ODG source
                jpegOptions.VectorRasterizationOptions = new OdgRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = image.Size
                };

                // Save as JPEG with the specified options
                image.Save(outputPath, jpegOptions);
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
 * 1. When you need to generate high‑quality JPEG previews of OpenDocument graphics while preserving color fidelity using specific chroma subsampling.
 * 2. When an application must batch‑convert ODG diagrams to JPEG for web publishing and control the YCbCr sampling to reduce file size without noticeable quality loss.
 * 3. When you want to rasterize vector ODG pages to a JPEG with a white background and exact page dimensions for inclusion in PDF reports.
 * 4. When integrating Aspose.Imaging into a C# service that receives ODG files and returns JPEG images with a configurable quality setting.
 * 5. When developing a document‑management system that stores ODG files but needs thumbnail JPEGs with consistent color handling for preview grids.
 */
