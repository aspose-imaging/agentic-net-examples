using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputDirectory = @"C:\InputBmp";
        string outputDirectory = @"C:\OutputPdf";

        try
        {
            // Get all BMP files in the input directory
            string[] bmpFiles = Directory.GetFiles(inputDirectory, "*.bmp");

            foreach (string inputPath in bmpFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build unique output file name with timestamp prefix
                string timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, $"{timestamp}_{fileNameWithoutExt}.pdf");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load BMP image and save as PDF
                using (Image image = Image.Load(inputPath))
                {
                    var pdfOptions = new PdfOptions();
                    image.Save(outputPath, pdfOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}