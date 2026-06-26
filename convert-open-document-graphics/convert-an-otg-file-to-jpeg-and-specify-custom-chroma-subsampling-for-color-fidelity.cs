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
            string inputPath = "Input/sample.otg";
            string outputPath = "Output/sample.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var vectorOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = image.Width,
                    PageHeight = image.Height
                };

                using (var jpegOptions = new JpegOptions
                {
                    ColorType = JpegCompressionColorMode.YCbCr,
                    HorizontalSampling = new byte[] { 2, 2, 2 },
                    VerticalSampling = new byte[] { 2, 2, 2 },
                    Quality = 90,
                    VectorRasterizationOptions = vectorOptions
                })
                {
                    image.Save(outputPath, jpegOptions);
                }
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
 * 1. When a developer needs to generate web‑ready JPEG thumbnails from OTG vector drawings while preserving color fidelity by specifying YCbCr chroma subsampling.
 * 2. When an e‑commerce platform must convert product illustration OTG files to high‑quality JPEG images for catalog pages, controlling sampling to avoid banding.
 * 3. When a mobile app processes user‑uploaded OTG graphics and saves them as JPEGs with custom horizontal and vertical sampling to reduce file size without losing color detail.
 * 4. When a printing workflow requires rasterizing OTG artwork to JPEG for proofing, using vector rasterization options and explicit chroma subsampling to match print color standards.
 * 5. When a document management system automatically transforms stored OTG schematics into JPEG previews, applying a 2‑2‑2 sampling scheme to maintain accurate colors across browsers.
 */