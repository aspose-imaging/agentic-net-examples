using System;
using System.IO;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Define relative input and output directories
        string inputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Input");
        string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Output");

        // Get all CDR files in the input directory
        string[] cdrFiles = Directory.GetFiles(inputDirectory, "*.cdr");

        foreach (string inputPath in cdrFiles)
        {
            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Prepare output PSD path
            string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".psd");

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR file
            using (CdrImage cdrImage = (CdrImage)Aspose.Imaging.Image.Load(inputPath))
            {
                // Configure PSD export options
                PsdOptions psdOptions = new PsdOptions();

                // Set vector rasterization options to retain layers
                var rasterOptions = new CdrRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.White,
                    PageWidth = cdrImage.Width,
                    PageHeight = cdrImage.Height,
                    TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = Aspose.Imaging.SmoothingMode.None
                };
                psdOptions.VectorRasterizationOptions = rasterOptions;

                // Save as PSD; all pages become layers
                cdrImage.Save(outputPath, psdOptions);
            }
        }
    }
}