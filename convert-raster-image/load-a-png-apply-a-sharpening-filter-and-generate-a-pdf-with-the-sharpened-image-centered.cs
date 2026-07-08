using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));
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
 * 1. When a developer needs to enhance a low‑resolution PNG screenshot with a sharpening filter and embed it as a centered image in a PDF report.
 * 2. When an e‑commerce platform wants to automatically improve product PNG images and generate printable PDF catalogs with the sharpened images centered on each page.
 * 3. When a medical imaging system must preprocess scanned PNG diagrams by sharpening them and then create a PDF document for archiving with the image centered for easy viewing.
 * 4. When a marketing automation tool converts PNG banner ads into high‑quality PDF flyers, applying a sharpen filter to make the graphics pop and centering them for consistent layout.
 * 5. When a document management workflow requires converting uploaded PNG files to PDF, applying a sharpening filter to restore detail and ensuring the image appears centered in the final PDF file.
 */