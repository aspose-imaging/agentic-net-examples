using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input directory containing PNG files
            string inputDirectory = @"C:\InputPngs";
            // Hardcoded output PDF file path
            string outputPdfPath = @"C:\Output\combined.pdf";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

            // Shared memory stream that will hold all PDF pages
            using (MemoryStream sharedStream = new MemoryStream())
            {
                // Get all PNG files in the input directory
                string[] pngFiles = Directory.GetFiles(inputDirectory, "*.png");

                foreach (string pngPath in pngFiles)
                {
                    // Verify the input file exists
                    if (!File.Exists(pngPath))
                    {
                        Console.Error.WriteLine($"File not found: {pngPath}");
                        return;
                    }

                    // Load the PNG image
                    using (Image image = Image.Load(pngPath))
                    {
                        // Prepare PDF export options
                        PdfOptions pdfOptions = new PdfOptions();

                        // Save the image as a PDF page into the shared stream
                        // The stream position is advanced automatically, effectively appending pages
                        image.Save(sharedStream, pdfOptions);
                    }
                }

                // Write the aggregated PDF data to the final output file
                // Ensure the output directory exists (already created above)
                using (FileStream fileStream = new FileStream(outputPdfPath, FileMode.Create, FileAccess.Write))
                {
                    sharedStream.Position = 0;
                    sharedStream.CopyTo(fileStream);
                }
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
 * 1. When a developer needs to merge a collection of PNG screenshots from a test suite into a single PDF document for easy distribution, this code can batch‑convert and aggregate the images using a shared MemoryStream.
 * 2. When an application must generate a printable PDF catalog from a folder of product PNG images without creating intermediate files, the code streams each image directly into the combined PDF.
 * 3. When a server‑side service has to prepare a PDF portfolio of uploaded PNG receipts for compliance reporting, the shared MemoryStream approach lets it concatenate pages before applying a final compression step.
 * 4. When a desktop utility is required to archive daily PNG logs into one PDF file to save disk space, the code demonstrates how to load each PNG with Aspose.Imaging and append it to a single PDF stream.
 * 5. When a workflow automates the conversion of PNG design assets into a multi‑page PDF presentation for stakeholders, this snippet shows how to batch process the images and write the aggregated PDF in one operation.
 */