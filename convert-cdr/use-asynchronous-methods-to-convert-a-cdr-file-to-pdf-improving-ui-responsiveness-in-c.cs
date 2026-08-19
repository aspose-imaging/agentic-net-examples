// HOW-TO: Asynchronously Convert CDR to PDF in C# for Responsive UI (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;

class Program
{
    static async Task Main()
    {
        try
        {
            // Hard‑coded input and output paths
            string inputPath = "sample.cdr";
            string outputPath = "sample.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Perform the conversion on a background thread to keep UI responsive
            await Task.Run(() =>
            {
                // Load the CDR image
                using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
                {
                    // Get the first page (index 0)
                    var page = (CdrImagePage)cdrImage.Pages[0];

                    // Configure PDF rasterization options
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
 * 1. When a Windows Forms or WPF application needs to let users open CorelDRAW files and export them to PDF without freezing the interface.
 * 2. When a server‑side service processes uploaded CDR designs and generates PDF previews while keeping the request thread free.
 * 3. When a batch‑processing tool converts large numbers of CDR pages to PDF in the background to maintain overall application responsiveness.
 * 4. When a mobile or cross‑platform .NET app must render a specific CDR page as a PDF document while performing other UI tasks.
 * 5. When an automated workflow requires rasterizing a CorelDRAW page with specific rendering options (e.g., no smoothing) and saving it as PDF without blocking the main thread.
 */
