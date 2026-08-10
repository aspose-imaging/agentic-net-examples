// HOW-TO: Convert OTG to JPEG with Custom Chroma Subsampling in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.otg");
            string outputPath = Path.Combine("Output", "sample.jpg");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var jpegOptions = new JpegOptions
                {
                    HorizontalSampling = new byte[] { 2, 1, 1 },
                    VerticalSampling = new byte[] { 2, 1, 1 },
                    Quality = 100
                };

                var vectorOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = image.Width,
                    PageHeight = image.Height
                };
                jpegOptions.VectorRasterizationOptions = vectorOptions;

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
 * 1. When you need to render an OTG vector graphic as a high‑quality JPEG for web publishing while preserving color fidelity through specific chroma subsampling.
 * 2. When a batch process must convert multiple OTG files to JPEGs with 100 % quality and custom sampling to match a printing workflow’s color requirements.
 * 3. When integrating Aspose.Imaging into a C# application that generates thumbnails of OTG drawings and requires precise control over JPEG compression parameters.
 * 4. When automating the conversion of OTG design assets to JPEG for email newsletters, ensuring the background is white and the image dimensions match the original vector size.
 * 5. When developing a document management system that stores OTG files but needs to display them as JPEG previews with consistent chroma sampling across different devices.
 */
