using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static async Task Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.cdr";
        string outputPath = @"C:\Images\sample.pdf";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Perform conversion on a background thread to keep UI responsive
            await Task.Run(() =>
            {
                // Load the CDR image
                using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
                {
                    // Use the first page (index 0) for conversion
                    var page = (CdrImagePage)cdrImage.Pages[0];

                    // Configure PDF options with rasterization settings
                    var pdfOptions = new PdfOptions();
                    var rasterOptions = new CdrRasterizationOptions
                    {
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None,
                        PageWidth = page.Width,
                        PageHeight = page.Height
                    };
                    pdfOptions.VectorRasterizationOptions = rasterOptions;

                    // Save the page as PDF
                    page.Save(outputPath, pdfOptions);
                }
            });
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When building a Windows Forms or WPF desktop application that lets users open CorelDRAW (CDR) files and export them to PDF without freezing the UI, developers can use this asynchronous conversion code.
 * 2. When creating an ASP.NET Core document management system that receives CDR uploads and needs to generate PDF previews on the server while keeping the request thread responsive, this pattern applies.
 * 3. When implementing a batch‑processing tool that converts large numbers of CDR drawings to PDF in the background, allowing the main program to continue handling user commands, the async method is useful.
 * 4. When integrating Aspose.Imaging into a C# graphics‑workflow plugin that must rasterize CDR pages with specific rendering hints before saving them as PDF, this code provides the required conversion logic.
 * 5. When developing a Xamarin or MAUI app that lets users view CorelDRAW designs as PDFs and requires non‑blocking file I/O, the async Task.Run approach ensures smooth performance.
 */