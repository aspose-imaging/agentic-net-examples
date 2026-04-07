using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input JPEG files (modify paths as needed)
        string[] inputPaths = new string[]
        {
            "input1.jpg",
            "input2.jpg",
            "input3.jpg"
        };

        // Validate each input file exists
        foreach (string path in inputPaths)
        {
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"File not found: {path}");
                return;
            }
        }

        // Output PDF path
        string outputPath = "merged.pdf";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Temporary JPEG canvas file (intermediate)
        string tempCanvasPath = "temp_canvas.jpg";
        Directory.CreateDirectory(Path.GetDirectoryName(tempCanvasPath));

        // Collect sizes of all input images
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

        // Create temporary JPEG canvas bound to tempCanvasPath
        Source tempSource = new FileCreateSource(tempCanvasPath, false);
        JpegOptions jpegOptions = new JpegOptions()
        {
            Source = tempSource,
            Quality = 100
        };

        using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
        {
            // Merge images horizontally onto the canvas
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

            // Prepare PDF options with custom author metadata
            PdfOptions pdfOptions = new PdfOptions();
            pdfOptions.PdfDocumentInfo = new Aspose.Imaging.FileFormats.Pdf.PdfDocumentInfo()
            {
                Author = "Custom Author"
            };

            // Save the canvas as PDF with metadata
            canvas.Save(outputPath, pdfOptions);
        }

        // Optionally delete the temporary canvas file
        if (File.Exists(tempCanvasPath))
        {
            File.Delete(tempCanvasPath);
        }
    }
}