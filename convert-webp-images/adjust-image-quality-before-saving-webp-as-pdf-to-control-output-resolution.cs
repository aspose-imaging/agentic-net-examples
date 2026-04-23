using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\temp\input.webp";
        string outputPath = @"C:\temp\output.pdf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Desired quality for the intermediate WebP encoding (0‑100)
        const float desiredQuality = 80f;

        // Load the original WebP image
        using (Image originalImage = Image.Load(inputPath))
        {
            // Re‑encode the image with the specified quality into a memory stream
            var webpOptions = new WebPOptions
            {
                Lossless = false,
                Quality = desiredQuality
            };

            using (var tempStream = new MemoryStream())
            {
                originalImage.Save(tempStream, webpOptions);
                tempStream.Position = 0; // Reset stream for reading

                // Load the re‑encoded image from the memory stream
                using (Image reencodedImage = Image.Load(tempStream))
                {
                    // Save the image as PDF
                    var pdfOptions = new PdfOptions(); // Default PDF options
                    reencodedImage.Save(outputPath, pdfOptions);
                }
            }
        }
    }
}