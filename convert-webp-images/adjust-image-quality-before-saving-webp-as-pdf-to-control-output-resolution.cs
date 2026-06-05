using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.webp";
            string outputPath = @"C:\Images\output.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the WebP image
            using (Image webpImage = Image.Load(inputPath))
            {
                // OPTIONAL: Re‑encode the image with a specific quality before PDF conversion.
                // This step creates an in‑memory WebP with the desired quality.
                var tempWebpOptions = new WebPOptions
                {
                    Lossless = false,   // use lossy compression
                    Quality = 80f       // desired quality (0‑100)
                };

                using (var ms = new MemoryStream())
                {
                    // Save to memory stream with the specified quality
                    webpImage.Save(ms, tempWebpOptions);
                    ms.Position = 0; // reset stream position for reading

                    // Load the re‑encoded WebP from the memory stream
                    using (Image reencodedImage = Image.Load(ms))
                    {
                        // Prepare PDF save options with desired resolution
                        var pdfOptions = new PdfOptions
                        {
                            // Set resolution to control output size and quality
                            ResolutionSettings = new ResolutionSetting(300.0, 300.0)
                        };

                        // Save the image as PDF
                        reencodedImage.Save(outputPath, pdfOptions);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}