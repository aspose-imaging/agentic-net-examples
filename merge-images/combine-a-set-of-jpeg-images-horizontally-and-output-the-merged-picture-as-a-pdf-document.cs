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
    static void Main(string[] args)
    {
        // Hardcoded input JPEG files
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

        // Hardcoded output PDF file
        string outputPath = "output/merged.pdf";
        // Temporary JPEG file used as canvas source
        string tempPath = "temp/temp.jpg";

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
        Directory.CreateDirectory(Path.GetDirectoryName(tempPath));

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
        int totalWidth = sizes.Sum(s => s.Width);
        int maxHeight = sizes.Max(s => s.Height);

        // Create JPEG canvas bound to temporary file
        JpegOptions jpegOptions = new JpegOptions
        {
            Source = new FileCreateSource(tempPath, false)
        };

        using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, totalWidth, maxHeight))
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

            // Save the bound JPEG canvas to the temporary file
            canvas.Save();
        }

        // Load the temporary JPEG and save as PDF
        using (Image pdfSource = Image.Load(tempPath))
        {
            PdfOptions pdfOptions = new PdfOptions();
            pdfSource.Save(outputPath, pdfOptions);
        }
    }
}