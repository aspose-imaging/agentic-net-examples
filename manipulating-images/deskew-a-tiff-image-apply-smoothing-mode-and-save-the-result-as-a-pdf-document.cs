using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.tif";
        string outputPath = "Output/result.pdf";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Deskew the image without resizing the canvas and with a white background.
                tiffImage.NormalizeAngle(false, Color.White);

                // Apply smoothing mode for better rendering quality.
                Graphics graphics = new Graphics(tiffImage);
                graphics.SmoothingMode = SmoothingMode.AntiAlias;

                // Save the processed image as PDF.
                PdfOptions pdfOptions = new PdfOptions();
                tiffImage.Save(outputPath, pdfOptions);
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
 * 1. When a scanning application uses Aspose.Imaging for .NET to correct the tilt of incoming TIFF files, apply anti‑alias smoothing, and output the results as PDF archives.
 * 2. When an invoicing system processes scanned receipt TIFF images, deskews them with Aspose.Imaging, sets the graphics smoothing mode, and saves them as PDF for record‑keeping.
 * 3. When a medical imaging workflow needs to straighten rotated TIFF X‑ray images, improve visual quality with smoothing, and generate PDF reports using C# and Aspose.Imaging.
 * 4. When a legal document platform automates the preparation of TIFF contracts by normalizing the angle, applying anti‑aliasing, and converting them to PDF via Aspose.Imaging for electronic signatures.
 * 5. When a batch conversion utility processes large TIFF map collections, deskews each image, applies smoothing mode for clearer rendering, and saves them as PDF files using Aspose.Imaging for .NET.
 */