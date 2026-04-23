using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input BMP path (relative to the working directory)
        string inputPath = "Input/sample.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the BMP image
        using (Image image = Image.Load(inputPath))
        {
            // Prepare PDF export options
            var pdfOptions = new PdfOptions();

            // In a real web application, replace this stream with HttpResponse.OutputStream
            using (Stream responseStream = Console.OpenStandardOutput())
            {
                // Write the PDF directly to the response stream
                image.Save(responseStream, pdfOptions);
            }
        }
    }
}