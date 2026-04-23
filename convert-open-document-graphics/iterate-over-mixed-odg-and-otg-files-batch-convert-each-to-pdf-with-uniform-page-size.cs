using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded relative input and output directories
        string inputDirectory = "Input";
        string outputDirectory = "Output";

        // Ensure the output directory exists
        Directory.CreateDirectory(outputDirectory);

        // Get all files in the input directory
        string[] files = Directory.GetFiles(inputDirectory);
        foreach (string inputPath in files)
        {
            // Process only ODG and OTG files
            string extension = Path.GetExtension(inputPath).ToLowerInvariant();
            if (extension != ".odg" && extension != ".otg")
                continue;

            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Build the output PDF path
            string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".pdf";
            string outputPath = Path.Combine(outputDirectory, outputFileName);

            // Ensure the output directory for this file exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the vector image (ODG or OTG)
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PDF save options with appropriate rasterization settings
                PdfOptions pdfOptions = new PdfOptions();

                if (extension == ".odg")
                {
                    // ODG specific rasterization options
                    OdgRasterizationOptions rasterOptions = new OdgRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageSize = image.Size // Uniform page size based on source image
                    };
                    pdfOptions.VectorRasterizationOptions = rasterOptions;
                }
                else // .otg
                {
                    // OTG specific rasterization options
                    OtgRasterizationOptions rasterOptions = new OtgRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageSize = image.Size // Uniform page size based on source image
                    };
                    pdfOptions.VectorRasterizationOptions = rasterOptions;
                }

                // Save the image as PDF
                image.Save(outputPath, pdfOptions);
            }
        }
    }
}