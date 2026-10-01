// HOW-TO: Create a Blurred 200x200 PNG Thumbnail PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.png";
            string outputPath = "Output\\thumbnail.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.0);
                image.Filter(image.Bounds, blurOptions);
                image.Resize(200, 200);
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    image.Save(outputPath, pdfOptions);
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
 * 1. When building a document management system that shows a quick PDF preview of uploaded PNG images, you can use this code to generate a 200 × 200 blurred thumbnail PDF.
 * 2. When creating a web gallery that displays low‑resolution placeholder images while the full‑size picture loads, the code produces a small blurred PNG thumbnail saved as PDF for fast rendering.
 * 3. When sending image attachments via email and you need a compact PDF preview to reduce size, this snippet resizes the image, applies a Gaussian blur, and saves it as a tiny PDF thumbnail.
 * 4. When implementing privacy‑preserving previews where faces or sensitive details must be obscured, the Gaussian blur filter combined with resizing creates a safe PDF thumbnail for user review.
 * 5. When automating batch processing of product photos to generate uniform PDF thumbnails for catalog listings, the code quickly converts each raster image into a 200 × 200 blurred PDF preview.
 */
