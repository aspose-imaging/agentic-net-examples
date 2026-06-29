using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input/input.png";
            string outputPath = "output/output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Add footer with file name
                Graphics graphics = new Graphics(raster);
                int footerHeight = 30;
                Rectangle footerRect = new Rectangle(0, raster.Height - footerHeight, raster.Width, footerHeight);

                using (SolidBrush backgroundBrush = new SolidBrush(Color.White))
                {
                    graphics.FillRectangle(backgroundBrush, footerRect);
                }

                Font font = new Font("Arial", 12);
                using (SolidBrush textBrush = new SolidBrush(Color.Black))
                {
                    graphics.DrawString(Path.GetFileName(inputPath), font, textBrush, new Point(5, raster.Height - footerHeight + 5));
                }

                // Save as PDF
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
 * 1. When a web application needs to convert uploaded PNG screenshots into PDF reports while automatically appending the original file name as a footer for traceability.
 * 2. When an automated document generation pipeline must batch‑process PNG assets, add a consistent footer, and produce searchable PDF files for archival.
 * 3. When a desktop utility has to display a PNG image, embed a caption with the file name at the bottom, and export the result as a PDF for printing or sharing.
 * 4. When a compliance system requires every exported PDF to contain the source image name in a footer to satisfy audit‑trail requirements.
 * 5. When a C# service integrates Aspose.Imaging to transform product‑catalog PNG images into PDF catalogs, adding a footer with the image filename for easy reference.
 */