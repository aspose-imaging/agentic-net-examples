// HOW-TO: Crop EMF Border and Save as PDF Using C# Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "image.emf");
            string outputPath = Path.Combine("Output", "cropped.pdf");
            string tempPngPath = Path.Combine("Output", "temp.png");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));

            using (Image emfImage = Image.Load(inputPath))
            {
                var pngOptions = new PngOptions();
                emfImage.Save(tempPngPath, pngOptions);
            }

            using (RasterImage raster = (RasterImage)Image.Load(tempPngPath))
            {
                int border = 10;
                int newWidth = raster.Width - 2 * border;
                int newHeight = raster.Height - 2 * border;
                if (newWidth > 0 && newHeight > 0)
                {
                    var cropRect = new Aspose.Imaging.Rectangle(border, border, newWidth, newHeight);
                    raster.Crop(cropRect);
                }

                var pdfOptions = new PdfOptions();
                raster.Save(outputPath, pdfOptions);
            }

            if (File.Exists(tempPngPath))
            {
                File.Delete(tempPngPath);
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
 * 1. When you need to remove unwanted whitespace from a vector EMF logo before embedding it in a PDF report.
 * 2. When an application must convert legacy EMF diagrams to PDF while trimming the image edges for a cleaner layout.
 * 3. When generating printable PDFs from EMF icons and you want to automatically crop a fixed border around each icon.
 * 4. When automating document workflows that require rasterizing EMF files, cropping them, and saving the result as PDF using C#.
 * 5. When integrating Aspose.Imaging into a .NET service to preprocess EMF graphics by removing margins and delivering them as PDF files.
 */
