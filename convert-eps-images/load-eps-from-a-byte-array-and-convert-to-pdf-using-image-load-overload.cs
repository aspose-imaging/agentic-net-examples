using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input EPS file path (used to obtain the byte array)
            string inputPath = "Input/sample.eps";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Output PDF file path
            string outputPath = "Output/result.pdf";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EPS data into a byte array
            byte[] epsData = File.ReadAllBytes(inputPath);

            // Create a memory stream from the byte array
            using (var memoryStream = new MemoryStream(epsData))
            {
                // Load the EPS image from the stream using EpsLoadOptions
                using (var image = Image.Load(memoryStream, new Aspose.Imaging.FileFormats.Eps.EpsLoadOptions()))
                {
                    // Prepare PDF save options
                    var pdfOptions = new PdfOptions();

                    // Save the image as PDF
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