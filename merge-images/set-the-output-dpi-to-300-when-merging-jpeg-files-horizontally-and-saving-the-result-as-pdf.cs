using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Input");
        string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Output");
        string outputPdfPath = Path.Combine(outputDirectory, "Merged.pdf");

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

        // Get all JPEG files in the input directory
        string[] files = Directory.GetFiles(inputDirectory, "*.jpg");

        if (files.Length == 0)
        {
            Console.WriteLine("No JPEG files found.");
            return;
        }

        // Collect sizes of all images
        List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
        foreach (string file in files)
        {
            if (!File.Exists(file))
            {
                Console.Error.WriteLine($"File not found: {file}");
                return;
            }
            using (Aspose.Imaging.RasterImage img = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(file))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas dimensions for horizontal merge
        int newWidth = sizes.Sum(s => s.Width);
        int newHeight = sizes.Max(s => s.Height);

        // Create canvas options with DPI settings
        JpegOptions canvasOptions = new JpegOptions
        {
            ResolutionSettings = new Aspose.Imaging.ResolutionSetting(300, 300),
            ResolutionUnit = Aspose.Imaging.ResolutionUnit.Inch
        };

        // Create an unbound canvas
        using (JpegImage canvas = (JpegImage)Aspose.Imaging.Image.Create(canvasOptions, newWidth, newHeight))
        {
            // Merge images horizontally
            int offsetX = 0;
            foreach (string file in files)
            {
                using (Aspose.Imaging.RasterImage img = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(file))
                {
                    Aspose.Imaging.Rectangle bounds = new Aspose.Imaging.Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            // Save the merged canvas as PDF
            PdfOptions pdfOptions = new PdfOptions();
            canvas.Save(outputPdfPath, pdfOptions);
        }
    }
}