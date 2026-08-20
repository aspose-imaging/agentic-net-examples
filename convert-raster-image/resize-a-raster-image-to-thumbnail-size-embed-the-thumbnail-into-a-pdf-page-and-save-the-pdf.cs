// HOW-TO: Resize Image to Thumbnail and Save as PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.jpg";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputPath = "Output\\thumbnail.pdf";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                // Resize to thumbnail size (150x150) using nearest neighbour resampling
                image.Resize(150, 150, ResizeType.NearestNeighbourResample);

                // Create a PDF canvas with the same dimensions as the thumbnail
                PdfOptions pdfOptions = new PdfOptions();
                pdfOptions.Source = new FileCreateSource(outputPath, false);

                using (Image pdf = Image.Create(pdfOptions, image.Width, image.Height))
                {
                    Graphics graphics = new Graphics(pdf);
                    graphics.Clear(Color.White);
                    graphics.DrawImage(image, new Point(0, 0));
                    pdf.Save(); // Save the bound PDF file
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
 * 1. When you need to generate small preview images of photos and embed them directly into PDF reports for faster loading.
 * 2. When an application must create thumbnail versions of user‑uploaded JPEGs and package them as single‑page PDFs for email attachments.
 * 3. When a document management system requires converting high‑resolution raster images into compact PDF thumbnails to save storage space.
 * 4. When building a gallery web service that supplies PDF files containing 150 × 150 pixel previews of product images.
 * 5. When automating batch processing to resize images and produce PDF catalogs where each page shows a thumbnail of the original picture.
 */
