using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded list of OTG files to convert
            string[] inputFiles = new string[]
            {
                @"C:\OTGFiles\Document1.otg",
                @"C:\OTGFiles\Document2.otg",
                @"C:\OTGFiles\Document3.otg"
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

                // Define output PDF path (same folder, .pdf extension)
                string outputPath = inputPath + ".pdf";

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the OTG image
                using (Image image = Image.Load(inputPath))
                {
                    // Configure rasterization options for OTG
                    var otgRasterOptions = new OtgRasterizationOptions
                    {
                        PageSize = image.Size
                    };

                    // Set up PDF save options and attach rasterization options
                    var pdfOptions = new PdfOptions
                    {
                        VectorRasterizationOptions = otgRasterOptions
                    };

                    // Save the image as PDF
                    image.Save(outputPath, pdfOptions);
                }
            });
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}