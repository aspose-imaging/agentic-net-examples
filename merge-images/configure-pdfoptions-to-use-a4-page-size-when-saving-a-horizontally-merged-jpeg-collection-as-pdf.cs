using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Input JPEG files
        string[] inputPaths = { "Input/image1.jpg", "Input/image2.jpg", "Input/image3.jpg" };
        // Output PDF file
        string outputPath = "Output/merged.pdf";

        // Validate input files
        foreach (string path in inputPaths)
        {
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"File not found: {path}");
                return;
            }
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Collect image sizes
        List<Size> sizes = new List<Size>();
        foreach (string path in inputPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas dimensions for horizontal merge
        int canvasWidth = sizes.Sum(s => s.Width);
        int canvasHeight = sizes.Max(s => s.Height);

        // Temporary source for canvas creation
        string tempCanvasPath = Path.Combine(Path.GetTempPath(), "temp_canvas.jpg");
        Source canvasSource = new FileCreateSource(tempCanvasPath, false);
        JpegOptions jpegOptions = new JpegOptions() { Source = canvasSource, Quality = 100 };

        // Create canvas
        using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
        {
            int offsetX = 0;
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            // Configure PDF options with A4 page size (595x842 points at 72 DPI)
            PdfOptions pdfOptions = new PdfOptions();
            pdfOptions.PageSize = new Size(595, 842);

            // Save merged image as PDF
            canvas.Save(outputPath, pdfOptions);
        }
    }
}