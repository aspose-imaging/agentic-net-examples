using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input\\sample.djvu";
        string outputPath = "output\\resized.pdf";

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

            // Load the DjVu document from a file stream
            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = DjvuImage.LoadDocument(stream))
            {
                // Resize each page to 1024x768 (applies to the whole document)
                djvuImage.Resize(1024, 768, ResizeType.BilinearResample);

                // Save the resized document as PDF
                djvuImage.Save(outputPath, new PdfOptions());
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
 * 1. When a developer needs to convert scanned DjVu documents into PDF for easier distribution while ensuring each page fits a standard 1024×768 screen resolution.
 * 2. When an application must batch‑process DjVu files and downscale their pages to reduce file size before archiving them as PDF.
 * 3. When a web service receives DjVu uploads and must generate PDF previews that are uniformly sized for consistent display in browsers.
 * 4. When a digital library wants to preserve legacy DjVu manuscripts as PDF but must resize the pages to match the dimensions of existing PDF collections.
 * 5. When a mobile app requires on‑the‑fly conversion of DjVu pages to PDF with a fixed 1024×768 resolution to optimize rendering on handheld devices.
 */