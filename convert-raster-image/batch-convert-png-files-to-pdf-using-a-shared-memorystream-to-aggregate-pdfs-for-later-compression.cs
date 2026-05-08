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
            // Hardcoded input folder containing PNG files
            string inputFolder = @"C:\Images\Input";

            // Hardcoded output PDF file that will contain all PDFs concatenated
            string outputPdfPath = @"C:\Images\Output\combined.pdf";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

            // Get all PNG files in the input folder
            string[] pngFiles = Directory.GetFiles(inputFolder, "*.png");

            // Shared memory stream to aggregate PDF data
            using (MemoryStream combinedStream = new MemoryStream())
            {
                // PDF export options (default)
                PdfOptions pdfOptions = new PdfOptions();

                foreach (string pngPath in pngFiles)
                {
                    // Verify the PNG file exists
                    if (!File.Exists(pngPath))
                    {
                        Console.Error.WriteLine($"File not found: {pngPath}");
                        return;
                    }

                    // Load the PNG image
                    using (Image image = Image.Load(pngPath))
                    {
                        // Save the image as PDF into the shared memory stream
                        image.Save(combinedStream, pdfOptions);
                    }
                }

                // Write the aggregated PDF data to the output file
                combinedStream.Position = 0;
                using (FileStream fileStream = new FileStream(outputPdfPath, FileMode.Create, FileAccess.Write))
                {
                    combinedStream.CopyTo(fileStream);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}