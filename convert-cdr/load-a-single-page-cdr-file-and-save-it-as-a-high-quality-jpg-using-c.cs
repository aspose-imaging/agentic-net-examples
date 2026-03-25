using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
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

        // Load the CDR file
        using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
        {
            // Cache the whole document to avoid further stream reads
            cdrImage.CacheData();

            // Access the first (and only) page
            CdrImagePage page = (CdrImagePage)cdrImage.Pages[0];
            page.CacheData();

            // Configure high‑quality JPEG options
            var jpegOptions = new JpegOptions
            {
                Quality = 100 // maximum quality
            };

            // Save the page as a JPEG image
            page.Save(outputPath, jpegOptions);
        }
    }
}