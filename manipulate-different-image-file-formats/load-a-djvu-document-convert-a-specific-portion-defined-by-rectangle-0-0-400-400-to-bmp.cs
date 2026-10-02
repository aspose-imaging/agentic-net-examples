// HOW-TO: Extract a 400x400 Region from DjVu and Save as BMP in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.djvu";
            string outputPath = "Output/portion.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                BmpOptions bmpOptions = new BmpOptions();
                bmpOptions.MultiPageOptions = new DjvuMultiPageOptions(0, new Rectangle(0, 0, 400, 400));
                djvu.Save(outputPath, bmpOptions);
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
 * 1. When you need to preview a specific page area of a large DjVu document as a BMP thumbnail for a web gallery.
 * 2. When extracting a fixed-size portion of a scanned book page in DjVu format to embed in a PDF as a raster image.
 * 3. When converting a selected region of a multi‑page DjVu file to BMP for OCR preprocessing in a C# application.
 * 4. When generating a bitmap snapshot of a DjVu map segment to use as a texture in a Windows desktop app.
 * 5. When isolating a 400 × 400 pixel area from a DjVu invoice to store it as a BMP file for archival or compliance purposes.
 */
