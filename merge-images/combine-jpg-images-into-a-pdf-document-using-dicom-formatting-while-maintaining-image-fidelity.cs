using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input JPG files
        string[] inputPaths = { "image1.jpg", "image2.jpg", "image3.jpg" };
        // Hardcoded output DICOM and PDF files
        string dicomPath = "combined.dcm";
        string pdfPath = "combined.pdf";

        // Verify each input file exists
        foreach (string path in inputPaths)
        {
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"File not found: {path}");
                return;
            }
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(dicomPath));
        Directory.CreateDirectory(Path.GetDirectoryName(pdfPath));

        // Collect sizes of all input images
        List<Size> sizes = new List<Size>();
        foreach (string path in inputPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Determine canvas dimensions (vertical stacking)
        int canvasWidth = 0;
        int canvasHeight = 0;
        foreach (Size sz in sizes)
        {
            if (sz.Width > canvasWidth) canvasWidth = sz.Width;
            canvasHeight += sz.Height;
        }

        // Create DICOM canvas with the calculated size
        var dicomOptions = new DicomOptions { Source = new FileCreateSource(dicomPath, false) };
        using (DicomImage canvas = (DicomImage)Image.Create(dicomOptions, canvasWidth, canvasHeight))
        {
            int offsetY = 0;
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    // Define destination rectangle on the canvas
                    Rectangle destRect = new Rectangle(0, offsetY, img.Width, img.Height);
                    // Copy pixel data from source image to canvas
                    canvas.SaveArgb32Pixels(destRect, img.LoadArgb32Pixels(img.Bounds));
                    offsetY += img.Height;
                }
            }
            // Save the bound DICOM image (source already set)
            canvas.Save();
        }

        // Load the created DICOM image and save it as PDF
        using (DicomImage dicom = (DicomImage)Image.Load(dicomPath))
        {
            var pdfOptions = new PdfOptions();
            dicom.Save(pdfPath, pdfOptions);
        }
    }
}