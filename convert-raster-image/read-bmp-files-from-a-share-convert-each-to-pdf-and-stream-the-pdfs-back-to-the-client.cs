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
            // Hardcoded list of BMP files on a network share
            string[] inputPaths = new string[]
            {
                @"\\fileserver\shared\images\image1.bmp",
                @"\\fileserver\shared\images\image2.bmp",
                @"\\fileserver\shared\images\image3.bmp"
            };

            // Corresponding output PDF paths
            string[] outputPaths = new string[]
            {
                @"C:\temp\pdfs\image1.pdf",
                @"C:\temp\pdfs\image2.pdf",
                @"C:\temp\pdfs\image3.pdf"
            };

            for (int i = 0; i < inputPaths.Length; i++)
            {
                string inputPath = inputPaths[i];
                string outputPath = outputPaths[i];

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load BMP image
                using (Image image = Image.Load(inputPath))
                {
                    // Prepare PDF options
                    PdfOptions pdfOptions = new PdfOptions();

                    // Save as PDF to the specified file
                    image.Save(outputPath, pdfOptions);
                }

                // Optional: stream the generated PDF back to the client (simulated here)
                // In a real server scenario, you would write the stream to the HTTP response.
                using (FileStream pdfStream = new FileStream(outputPath, FileMode.Open, FileAccess.Read))
                {
                    // Example: read the PDF into a memory stream (could be sent over network)
                    using (MemoryStream memory = new MemoryStream())
                    {
                        pdfStream.CopyTo(memory);
                        // For demonstration, output the size of the PDF
                        Console.WriteLine($"Generated PDF '{outputPath}' ({memory.Length} bytes)");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}