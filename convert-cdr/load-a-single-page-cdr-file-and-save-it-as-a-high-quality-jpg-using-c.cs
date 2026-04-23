using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.cdr";
            string outputPath = @"C:\Images\output.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR image
            using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
            {
                // Ensure the document has at least one page
                if (cdrImage.PageCount == 0)
                {
                    Console.Error.WriteLine("CDR document contains no pages.");
                    return;
                }

                // Get the first page (single‑page document)
                var page = (CdrImagePage)cdrImage.Pages[0];

                // Configure high‑quality JPEG options
                var jpegOptions = new JpegOptions
                {
                    Quality = 100 // maximum quality
                };

                // Save the page as a JPG
                page.Save(outputPath, jpegOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}