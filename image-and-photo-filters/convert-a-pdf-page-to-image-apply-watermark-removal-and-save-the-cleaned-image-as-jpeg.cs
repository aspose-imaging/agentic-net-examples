using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.pdf";
        string outputPath = "Output/cleaned.jpg";

        try
        {
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
                    Quality = 90
                };
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
 * 1. When a developer needs to generate a high‑quality JPEG thumbnail of a PDF document for display in a web portal or mobile app.
 * 2. When an automated workflow must extract the first page of a scanned PDF invoice and save it as a JPEG image for OCR processing in a downstream system.
 * 3. When a document management system requires conversion of PDF reports into JPEG files to embed them in email newsletters without relying on PDF viewers.
 * 4. When a legacy C# application has to archive legal PDFs as compressed JPEG images to reduce storage costs while preserving visual fidelity.
 * 5. When a batch job processes a folder of PDF manuals and converts each page to JPEG so that a graphics editor can later apply watermark removal or other image enhancements.
 */