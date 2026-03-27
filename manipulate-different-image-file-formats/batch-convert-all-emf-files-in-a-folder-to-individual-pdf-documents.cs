using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output directories relative to the current directory
        string baseDir = Directory.GetCurrentDirectory();
        string inputDirectory = Path.Combine(baseDir, "Input");
        string outputDirectory = Path.Combine(baseDir, "Output");

        // Ensure the input directory exists; if not, create it and exit
        if (!Directory.Exists(inputDirectory))
        {
            Directory.CreateDirectory(inputDirectory);
            Console.WriteLine($"Input directory created at: {inputDirectory}. Add EMF files and rerun.");
            return;
        }

        // Ensure the output directory exists
        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        // Get all EMF files in the input directory
        string[] files = Directory.GetFiles(inputDirectory, "*.emf");

        foreach (var inputPath in files)
        {
            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Build the output PDF path
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".pdf");

            // Ensure the output directory for this file exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PDF options with vector rasterization settings
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    pdfOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height,
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None
                    };

                    // Save as PDF
                    image.Save(outputPath, pdfOptions);
                }
            }
        }
    }
}