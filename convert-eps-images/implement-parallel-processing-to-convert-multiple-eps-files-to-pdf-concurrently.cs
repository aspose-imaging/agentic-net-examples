using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input EPS files
            string[] inputPaths = new string[]
            {
                @"C:\Images\Input1.eps",
                @"C:\Images\Input2.eps",
                @"C:\Images\Input3.eps"
            };

            // Hardcoded output directory
            string outputDirectory = @"C:\Images\PdfOutput";

            // Process each file in parallel
            Parallel.ForEach(inputPaths, inputPath =>
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output PDF path
                string outputPath = Path.Combine(
                    outputDirectory,
                    Path.GetFileNameWithoutExtension(inputPath) + ".pdf");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load EPS image
                using (var image = (EpsImage)Image.Load(inputPath))
                {
                    // Set PDF options (default compliance)
                    var pdfOptions = new PdfOptions
                    {
                        PdfCoreOptions = new PdfCoreOptions()
                    };

                    // Save as PDF
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
 * 1. When a print shop needs to quickly convert a large batch of EPS artwork files to PDF for client delivery, they can use this parallel C# code with Aspose.Imaging to speed up the process.
 * 2. When a document management system must archive legacy EPS graphics as searchable PDF documents, developers can run the code to process multiple files concurrently on a server.
 * 3. When an e‑commerce platform generates product catalogs and must transform designer‑provided EPS logos into PDF thumbnails in real time, the parallel conversion routine ensures low latency.
 * 4. When a GIS or CAD application exports map layers as EPS and then needs to bundle them into PDF reports, the code enables simultaneous conversion of many layers using .NET tasks.
 * 5. When a cloud‑based microservice receives a list of EPS files via an API and must return PDF versions, developers can employ this parallel processing snippet to handle high‑volume requests efficiently.
 */