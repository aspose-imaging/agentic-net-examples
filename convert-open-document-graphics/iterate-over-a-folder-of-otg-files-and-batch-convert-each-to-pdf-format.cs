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
            string inputFolder = @"C:\OtgInput";
            string outputFolder = @"C:\PdfOutput";

            // Ensure the output directory exists (will also handle subfolders)
            Directory.CreateDirectory(outputFolder);

            // Get all .otg files in the input folder
            string[] otgFiles = Directory.GetFiles(inputFolder, "*.otg");

            foreach (string inputPath in otgFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output PDF path
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".pdf";
                string outputPath = Path.Combine(outputFolder, outputFileName);

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the OTG image
                using (Image image = Image.Load(inputPath))
                {
                    // Set up rasterization options for OTG
                    OtgRasterizationOptions otgRasterizationOptions = new OtgRasterizationOptions
                    {
                        PageSize = image.Size
                    };

                    // Configure PDF save options
                    PdfOptions pdfOptions = new PdfOptions
                    {
                        VectorRasterizationOptions = otgRasterizationOptions
                    };

                    // Save as PDF
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