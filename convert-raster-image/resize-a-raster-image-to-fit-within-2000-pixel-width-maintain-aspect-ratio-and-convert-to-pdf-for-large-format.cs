// HOW-TO: Resize Image to 2000px Width and Convert to PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                int originalWidth = image.Width;
                int originalHeight = image.Height;

                if (originalWidth > 2000)
                {
                    double ratio = 2000.0 / originalWidth;
                    int newWidth = 2000;
                    int newHeight = (int)Math.Round(originalHeight * ratio);
                    image.Resize(newWidth, newHeight, ResizeType.LanczosResample);
                }

                PdfOptions pdfOptions = new PdfOptions();
                image.Save(outputPath, pdfOptions);
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
 * 1. When a developer needs to shrink high‑resolution photos to a printable width of 2000 pixels while preserving the original aspect ratio before generating a PDF for large‑format prints.
 * 2. When an e‑commerce platform must automatically convert uploaded product JPEGs into PDF catalogs, ensuring images are not wider than 2000 px to keep file size manageable.
 * 3. When a printing service processes client‑supplied images and must resize them to fit within a 2000‑pixel limit and output a PDF ready for poster‑size printing.
 * 4. When a desktop application creates printable PDFs from user‑selected photos, resizing any image exceeding 2000 px width to avoid distortion on large‑format printers.
 * 5. When a batch‑processing script prepares marketing assets by resizing oversized raster images and bundling them into PDF files for high‑resolution print distribution.
 */
