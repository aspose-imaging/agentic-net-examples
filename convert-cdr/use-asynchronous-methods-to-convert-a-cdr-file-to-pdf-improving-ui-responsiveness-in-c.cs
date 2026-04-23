using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ProgressManagement;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            // Hardcoded relative paths
            string inputPath = "Input/sample.cdr";
            string outputPath = "Output/sample.pdf";

            // Input validation
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Perform conversion on a background thread
            await Task.Run(() =>
            {
                // Load CDR with progress reporting
                using (CdrImage cdr = (CdrImage)Image.Load(inputPath, new LoadOptions
                {
                    ProgressEventHandler = info => Console.WriteLine($"{info.EventType} : {info.Value}/{info.MaxValue}")
                }))
                {
                    // Configure PDF export options with rasterization settings
                    var pdfOptions = new PdfOptions
                    {
                        ProgressEventHandler = info => Console.WriteLine($"Export {info.EventType} : {info.Value}/{info.MaxValue}"),
                        VectorRasterizationOptions = new CdrRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                            SmoothingMode = SmoothingMode.None,
                            PageWidth = cdr.Width,
                            PageHeight = cdr.Height
                        }
                    };

                    // Save as PDF
                    cdr.Save(outputPath, pdfOptions);
                }
            });
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}