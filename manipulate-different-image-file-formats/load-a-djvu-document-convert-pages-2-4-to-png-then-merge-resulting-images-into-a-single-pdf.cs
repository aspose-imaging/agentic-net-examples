using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.djvu";
        string outputDir = "output";
        string pngPath2 = Path.Combine(outputDir, "page2.png");
        string pngPath3 = Path.Combine(outputDir, "page3.png");
        string pngPath4 = Path.Combine(outputDir, "page4.png");
        string pdfPath = Path.Combine(outputDir, "merged.pdf");

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(pngPath2));
        Directory.CreateDirectory(Path.GetDirectoryName(pngPath3));
        Directory.CreateDirectory(Path.GetDirectoryName(pngPath4));
        Directory.CreateDirectory(Path.GetDirectoryName(pdfPath));

        // Export pages 2‑4 to PNG
        using (FileStream stream = File.OpenRead(inputPath))
        {
            using (DjvuImage djvu = new DjvuImage(stream))
            {
                // Page numbers are 1‑based; array index is 0‑based
                DjvuPage page2 = (DjvuPage)djvu.Pages[1];
                page2.Save(pngPath2, new PngOptions());

                DjvuPage page3 = (DjvuPage)djvu.Pages[2];
                page3.Save(pngPath3, new PngOptions());

                DjvuPage page4 = (DjvuPage)djvu.Pages[3];
                page4.Save(pngPath4, new PngOptions());
            }
        }

        // Collect sizes of the PNG images
        List<Size> sizes = new List<Size>();
        string[] pngPaths = new[] { pngPath2, pngPath3, pngPath4 };
        foreach (string pngPath in pngPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(pngPath))
            {
                sizes.Add(img.Size);
            }
        }

        // Determine canvas dimensions (vertical stacking)
        int canvasWidth = sizes.Max(s => s.Width);
        int canvasHeight = sizes.Sum(s => s.Height);

        // Create PDF canvas bound to the output file
        Source pdfSource = new FileCreateSource(pdfPath, false);
        JpegOptions jpegOptions = new JpegOptions { Source = pdfSource, Quality = 100 };
        using (JpegImage pdfCanvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
        {
            int offsetY = 0;
            foreach (string pngPath in pngPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(pngPath))
                {
                    Rectangle bounds = new Rectangle(0, offsetY, img.Width, img.Height);
                    pdfCanvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetY += img.Height;
                }
            }

            // Save the PDF (canvas is already bound to the file source)
            pdfCanvas.Save();
        }
    }
}