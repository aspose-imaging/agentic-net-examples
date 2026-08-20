// HOW-TO: Add 5 Pixel Border to BMP Images and Convert to PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Get all BMP files in the input directory
            string[] files = Directory.GetFiles(inputDirectory, "*.bmp");

            foreach (string file in files)
            {
                // Validate input file existence
                if (!File.Exists(file))
                {
                    Console.Error.WriteLine($"File not found: {file}");
                    return;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(file);
                string tempBmpPath = Path.Combine(outputDirectory, fileNameWithoutExt + "_bordered.bmp");
                string pdfPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".pdf");

                // Ensure directories for temporary BMP and PDF exist
                Directory.CreateDirectory(Path.GetDirectoryName(tempBmpPath));
                Directory.CreateDirectory(Path.GetDirectoryName(pdfPath));

                // Load the original BMP image
                using (RasterImage src = (RasterImage)Image.Load(file))
                {
                    int newWidth = src.Width + 10;   // 5 pixels border on each side
                    int newHeight = src.Height + 10;

                    // Create a BMP canvas with a white background
                    Source bmpSource = new FileCreateSource(tempBmpPath, false);
                    BmpOptions bmpOptions = new BmpOptions { Source = bmpSource };
                    using (BmpImage canvas = (BmpImage)Image.Create(bmpOptions, newWidth, newHeight))
                    {
                        Graphics graphics = new Graphics(canvas);
                        graphics.Clear(Color.White);
                        graphics.DrawImage(src, new Rectangle(5, 5, src.Width, src.Height));

                        // Save the bordered BMP (bound to the file)
                        canvas.Save();
                    }
                }

                // Convert the bordered BMP to PDF
                using (Image bordered = Image.Load(tempBmpPath))
                {
                    PdfOptions pdfOptions = new PdfOptions();
                    bordered.Save(pdfPath, pdfOptions);
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
 * 1. When you need to automatically add a uniform white border to a collection of BMP scans before generating printable PDF reports.
 * 2. When you must prepare legacy BMP assets with a margin for inclusion in PDF catalogs or e‑books without manual editing.
 * 3. When a document‑management system requires batch conversion of BMP graphics to PDF while ensuring a consistent 5‑pixel frame around each image.
 * 4. When you are creating PDF invoices that embed BMP logos and need a fixed border to align with layout guidelines.
 * 5. When an archival workflow demands converting BMP photographs to PDF with a standard margin for consistent viewing across devices.
 */
