using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded list of OTG files to convert
            string[] inputFiles = new[]
            {
                @"C:\Images\Sample1.otg",
                @"C:\Images\Sample2.otg",
                @"C:\Images\Sample3.otg"
                // Add more file paths as needed
            };

            // Process each file in parallel
            Parallel.ForEach(inputFiles, inputPath =>
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine the output PDF path
                string outputPath = Path.ChangeExtension(inputPath, ".pdf");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the OTG image
                using (Image image = Image.Load(inputPath))
                {
                    // Configure rasterization options for OTG
                    var otgRasterOptions = new OtgRasterizationOptions
                    {
                        PageSize = image.Size
                    };

                    // Set up PDF save options and attach rasterization options
                    var pdfOptions = new PdfOptions
                    {
                        VectorRasterizationOptions = otgRasterOptions
                    };

                    // Save the image as PDF
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
 * 1. When a developer needs to batch‑convert a large collection of OTG CAD drawings into searchable PDF documents for a document‑management system, they can use this parallel conversion code to speed up the process.
 * 2. When an engineering web portal must generate PDF previews of user‑uploaded OTG files on the fly, the code enables concurrent rendering so multiple requests are handled efficiently.
 * 3. When a company wants to archive legacy OTG schematics as PDF files for long‑term storage and compliance, the parallel conversion reduces the time required to process thousands of files.
 * 4. When a desktop application provides an “Export All” feature that turns a folder of OTG images into PDF reports for printing, the Task Parallel Library ensures the export completes quickly on multi‑core machines.
 * 5. When an automated build pipeline needs to validate that OTG assets can be rendered to PDF without errors, the code can run the conversions in parallel to keep the CI job fast.
 */