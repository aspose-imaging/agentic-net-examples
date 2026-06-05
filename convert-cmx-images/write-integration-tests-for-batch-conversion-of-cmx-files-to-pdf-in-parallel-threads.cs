using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input and output directories (relative to current directory)
            string inputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Input");
            string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Output");

            // Get all CMX files in the input directory
            string[] files = Directory.GetFiles(inputDirectory, "*.cmx");

            // Process each file in parallel
            System.Threading.Tasks.Parallel.ForEach(files, inputPath =>
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

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the CMX image
                using (Image image = Image.Load(inputPath))
                {
                    // Configure PDF options with vector rasterization settings
                    using (PdfOptions pdfOptions = new PdfOptions())
                    {
                        pdfOptions.VectorRasterizationOptions = new CmxRasterizationOptions
                        {
                            BackgroundColor = Aspose.Imaging.Color.White,
                            TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel,
                            SmoothingMode = Aspose.Imaging.SmoothingMode.None,
                            Positioning = Aspose.Imaging.ImageOptions.PositioningTypes.DefinedByDocument
                        };

                        // Save the image as PDF
                        image.Save(outputPath, pdfOptions);
                    }
                }
            });
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}