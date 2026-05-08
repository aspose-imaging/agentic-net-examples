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
            // Hardcoded input and output directories
            string inputDirectory = @"\\shared\images";
            string outputDirectory = @"C:\temp\pdfs";

            // Ensure the base output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Process each BMP file in the input directory
            foreach (string inputPath in Directory.GetFiles(inputDirectory, "*.bmp"))
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Determine output PDF path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".pdf");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load BMP image and convert to PDF
                using (Image image = Image.Load(inputPath))
                {
                    var pdfOptions = new PdfOptions();
                    // Additional PDF options can be set here if needed
                    image.Save(outputPath, pdfOptions);
                }

                // Simulate streaming the PDF back to the client
                using (FileStream pdfStream = new FileStream(outputPath, FileMode.Open, FileAccess.Read))
                {
                    // In a real server scenario, the stream would be written to the HTTP response.
                    Console.WriteLine($"Streamed PDF for '{inputPath}'. Size: {pdfStream.Length} bytes.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}