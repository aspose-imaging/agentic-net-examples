using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.cdr";
            string outputPath = "Output/sample.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var pdfOptions = new PdfOptions
                {
                    PdfDocumentInfo = new PdfDocumentInfo(),
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    }
                };

                image.Save(outputPath, pdfOptions);
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
 * 1. When a desktop WPF application needs to let users preview CorelDRAW (CDR) designs as PDF without freezing the UI, developers can call the asynchronous Aspose.Imaging conversion method.
 * 2. When a WinForms batch‑processing tool must convert large CDR files to PDF in the background while keeping the progress bar responsive, the async API enables non‑blocking image processing.
 * 3. When a web API endpoint receives a CDR upload and must return a PDF stream to the client, using async conversion prevents thread‑pool starvation on the ASP.NET server.
 * 4. When a mobile Xamarin.Forms app allows users to share CorelDRAW artwork as PDF, asynchronous conversion ensures the UI remains interactive during the format transformation.
 * 5. When an automated document management system schedules nightly CDR‑to‑PDF conversions, employing async methods lets the scheduler run other tasks concurrently without blocking I/O operations.
 */