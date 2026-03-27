using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded list of OTG files to convert
        string[] inputFiles = new string[]
        {
            @"C:\Images\Sample1.otg",
            @"C:\Images\Sample2.otg",
            @"C:\Images\Sample3.otg"
        };

        // Process each file in parallel
        Parallel.ForEach(inputFiles, inputPath =>
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Determine output PDF path
            string outputPath = Path.ChangeExtension(inputPath, ".pdf");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options for OTG
                OtgRasterizationOptions rasterOptions = new OtgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Set up PDF save options
                PdfOptions pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the image as PDF
                image.Save(outputPath, pdfOptions);
            }

            Console.WriteLine($"Converted '{inputPath}' to PDF at '{outputPath}'.");
        });
    }
}