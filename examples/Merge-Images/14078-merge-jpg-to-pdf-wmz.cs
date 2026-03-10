using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Input JPG files
        string[] jpgFiles = new string[]
        {
            @"C:\Images\image1.jpg",
            @"C:\Images\image2.jpg",
            @"C:\Images\image3.jpg"
        };

        // Temporary folder for WMZ files
        string tempFolder = Path.Combine(Path.GetTempPath(), "WmzTemp");
        Directory.CreateDirectory(tempFolder);

        // List to hold paths of generated WMZ files
        List<string> wmzFiles = new List<string>();

        // Convert each JPG to WMZ (compressed WMF)
        foreach (string jpgPath in jpgFiles)
        {
            string wmzPath = Path.Combine(tempFolder, Path.GetFileNameWithoutExtension(jpgPath) + ".wmz");
            using (Image img = Image.Load(jpgPath))
            {
                var vectorOptions = new WmfRasterizationOptions() { PageSize = img.Size };
                img.Save(wmzPath, new WmfOptions() { VectorRasterizationOptions = vectorOptions, Compress = true });
            }
            wmzFiles.Add(wmzPath);
        }

        // Collect sizes of WMZ images
        List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
        foreach (string wmzPath in wmzFiles)
        {
            using (RasterImage ri = (RasterImage)Image.Load(wmzPath))
            {
                sizes.Add(ri.Size);
            }
        }

        // Calculate canvas size for vertical stacking
        int canvasWidth = 0;
        int canvasHeight = 0;
        foreach (var sz in sizes)
        {
            if (sz.Width > canvasWidth) canvasWidth = sz.Width;
            canvasHeight += sz.Height;
        }

        // Output PDF path
        string outputPdf = @"C:\Images\merged_output.pdf";

        // Create PDF options
        PdfOptions pdfOptions = new PdfOptions();

        // Create a JPEG canvas (unbound) with calculated size
        JpegOptions jpegOptions = new JpegOptions() { Quality = 100 };
        using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
        {
            int offsetY = 0;
            foreach (string wmzPath in wmzFiles)
            {
                using (RasterImage ri = (RasterImage)Image.Load(wmzPath))
                {
                    Rectangle bounds = new Rectangle(0, offsetY, ri.Width, ri.Height);
                    canvas.SaveArgb32Pixels(bounds, ri.LoadArgb32Pixels(ri.Bounds));
                    offsetY += ri.Height;
                }
            }

            // Save the canvas as PDF
            canvas.Save(outputPdf, pdfOptions);
        }

        // Cleanup temporary WMZ files
        foreach (string wmzPath in wmzFiles)
        {
            File.Delete(wmzPath);
        }
        Directory.Delete(tempFolder);
    }
}