// HOW-TO: Adjust WebP Image Quality and Convert to PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.webp";
            string outputPath = "Output\\result.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (WebPImage webpImage = (WebPImage)Image.Load(inputPath))
            {
                var webpOptions = new WebPOptions
                {
                    Quality = 80,
                    Lossless = false
                };

                using (var memoryStream = new MemoryStream())
                {
                    webpImage.Save(memoryStream, webpOptions);
                    memoryStream.Position = 0;

                    using (Image reloadedImage = Image.Load(memoryStream))
                    {
                        var pdfOptions = new PdfOptions();
                        reloadedImage.Save(outputPath, pdfOptions);
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

/*
 * Real-World Use Cases:
 * 1. When you need to reduce the file size of a WebP image before embedding it in a PDF report.
 * 2. When you want to control the visual quality of a WebP image while generating a PDF document in a C# application.
 * 3. When you must ensure a PDF generated from a WebP source meets specific resolution or compression requirements for web publishing.
 * 4. When you are building an automated pipeline that converts user‑uploaded WebP pictures to PDFs with consistent quality settings.
 * 5. When you need to validate the existence of a WebP file, adjust its quality, and save the result as a PDF without intermediate disk files.
 */
