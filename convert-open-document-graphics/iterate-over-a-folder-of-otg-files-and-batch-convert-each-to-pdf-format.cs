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
            string inputFolder = @"C:\OTGFiles";
            string outputFolder = @"C:\OTGFiles\PdfOutput";

            // Ensure the output directory exists
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

                // Determine the output PDF path
                string outputPath = Path.Combine(
                    outputFolder,
                    Path.GetFileNameWithoutExtension(inputPath) + ".pdf");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the OTG image
                using (Image image = Image.Load(inputPath))
                {
                    // Prepare PDF save options with OTG rasterization settings
                    PdfOptions pdfOptions = new PdfOptions();
                    OtgRasterizationOptions otgRasterization = new OtgRasterizationOptions
                    {
                        PageSize = image.Size
                    };
                    pdfOptions.VectorRasterizationOptions = otgRasterization;

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