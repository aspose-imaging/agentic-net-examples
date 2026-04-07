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
        string[] inputPaths = {
            "Input/image1.jpg",
            "Input/image2.jpg",
            "Input/image3.jpg"
        };

        // Verify each input file exists
        foreach (string path in inputPaths)
        {
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"File not found: {path}");
                return;
            }
        }

        // Collect sizes of grayscale images
        List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
        foreach (string path in inputPaths)
        {
            using (JpegImage img = (JpegImage)Image.Load(path))
            {
                img.Grayscale();
                sizes.Add(new Aspose.Imaging.Size(img.Width, img.Height));
            }
        }

        // Calculate canvas dimensions for horizontal merge
        int totalWidth = sizes.Sum(s => s.Width);
        int maxHeight = sizes.Max(s => s.Height);

        // Create an unbound JPEG canvas (will be saved as PDF later)
        JpegOptions canvasOptions = new JpegOptions();
        using (JpegImage canvas = (JpegImage)Image.Create(canvasOptions, totalWidth, maxHeight))
        {
            int offsetX = 0;
            foreach (string path in inputPaths)
            {
                using (JpegImage img = (JpegImage)Image.Load(path))
                {
                    img.Grayscale();
                    Aspose.Imaging.Rectangle bounds = new Aspose.Imaging.Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            // Output PDF path
            string outputPath = "Output/merged.pdf";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Save the merged canvas as PDF
            PdfOptions pdfOptions = new PdfOptions();
            canvas.Save(outputPath, pdfOptions);
        }
    }
}