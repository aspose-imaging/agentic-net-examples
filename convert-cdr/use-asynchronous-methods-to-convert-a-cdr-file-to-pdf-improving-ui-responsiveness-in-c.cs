// HOW-TO: Asynchronously Convert CorelDRAW CDR to PDF in C# for Responsive UI (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            string inputPath = "input.cdr";
            string outputPath = "output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            await Task.Run(() =>
            {
                using (Image image = Image.Load(inputPath))
                {
                    var pdfOptions = new PdfOptions();
                    image.Save(outputPath, pdfOptions);
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
 * 1. When a Windows Forms application needs to load large CorelDRAW files without freezing the interface, this async conversion lets the UI stay responsive while generating a PDF.
 * 2. When a web service processes user‑uploaded CDR designs and must return PDF previews quickly, the code runs the conversion on a background thread to avoid blocking request threads.
 * 3. When an automated batch job creates PDF archives from a folder of CDR assets but must continue handling other tasks, the asynchronous pattern ensures the job doesn’t monopolize CPU resources.
 * 4. When integrating Aspose.Imaging into a WPF editor that lets users edit vector graphics and export them as PDFs, using Task.Run keeps the export operation smooth and cancellable.
 * 5. When building a mobile‑friendly .NET MAUI app that converts design files to PDF on the device, the async approach prevents the app from becoming unresponsive during the conversion.
 */
