using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: Program <input1.jpg> <input2.jpg> ... <output.pdf>");
            return;
        }

        // Separate input JPG paths and output PDF path
        int imageCount = args.Length - 1;
        string[] jpgPaths = new string[imageCount];
        Array.Copy(args, jpgPaths, imageCount);
        string outputPdfPath = args[args.Length - 1];

        // Lists to hold temporary EMZ paths and their sizes
        List<string> emzPaths = new List<string>();
        List<Size> sizes = new List<Size>();

        // Convert each JPG to EMZ (compressed EMF) and record size
        foreach (string jpgPath in jpgPaths)
        {
            using (Image img = Image.Load(jpgPath))
            {
                var vectorOptions = new EmfRasterizationOptions { PageSize = img.Size };
                string emzPath = Path.Combine(Path.GetTempPath(), Path.GetFileNameWithoutExtension(jpgPath) + ".emz");
                img.Save(emzPath, new EmfOptions { VectorRasterizationOptions = vectorOptions, Compress = true });
                emzPaths.Add(emzPath);
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas size for vertical stacking
        int canvasWidth = sizes.Max(s => s.Width);
        int canvasHeight = sizes.Sum(s => s.Height);

        // Create an unbound JPEG canvas (will be saved as PDF)
        var jpegOptions = new JpegOptions { Quality = 100 };
        using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
        {
            int offsetY = 0;
            for (int i = 0; i < emzPaths.Count; i++)
            {
                using (RasterImage img = (RasterImage)Image.Load(emzPaths[i]))
                {
                    var bounds = new Rectangle(0, offsetY, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetY += img.Height;
                }
            }

            // Save the merged canvas as a PDF document
            var pdfOptions = new PdfOptions();
            canvas.Save(outputPdfPath, pdfOptions);
        }

        // Cleanup temporary EMZ files
        foreach (string emzPath in emzPaths)
        {
            try { File.Delete(emzPath); } catch { }
        }
    }
}