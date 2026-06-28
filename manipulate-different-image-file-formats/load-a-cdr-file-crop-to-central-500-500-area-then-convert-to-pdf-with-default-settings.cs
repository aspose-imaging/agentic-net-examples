using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

public class Program
{
    static void Main(string[] args)
    {
        string inputPath = "sample.cdr";
        string outputPath = "sample.pdf";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                cdr.CacheData();

                int cropWidth = 500;
                int cropHeight = 500;
                int left = (cdr.Width - cropWidth) / 2;
                int top = (cdr.Height - cropHeight) / 2;
                if (left < 0) left = 0;
                if (top < 0) top = 0;

                Rectangle cropRect = new Rectangle(left, top, cropWidth, cropHeight);
                cdr.Crop(cropRect);

                PdfOptions pdfOptions = new PdfOptions();
                cdr.Save(outputPath, pdfOptions);
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
 * 1. When a graphic design workflow requires extracting the central 500 × 500 pixels from a CorelDRAW (CDR) illustration and delivering it as a PDF for client review, a developer can use this Aspose.Imaging for .NET code.
 * 2. When an automated document generation system must convert legacy CDR assets into searchable PDF files while trimming unnecessary borders, the sample demonstrates how to crop and save with default PDF settings.
 * 3. When a web service needs to preview a specific region of a CDR logo by cropping the middle area and returning it as a PDF thumbnail, the code provides the necessary C# image processing steps.
 * 4. When a batch‑processing tool processes a folder of CDR files to create printable PDFs that contain only the central design portion, this snippet shows how to load, crop, and export each file using Aspose.Imaging.
 * 5. When a desktop application integrates CorelDRAW file support and must generate PDF reports that focus on the central artwork area, the example illustrates the required C# operations for cropping and conversion.
 */