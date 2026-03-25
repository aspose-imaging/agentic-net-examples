using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Psd; 

class Program
{
    static void Main(string[] args)
    {
        // Input and output directories (relative paths)
        string inputDirectory = "Input";
        string outputDirectory = "Output";

        // Ensure output directory exists
        Directory.CreateDirectory(outputDirectory);

        // Get all CDR files in the input directory
        string[] cdrFiles = Directory.GetFiles(inputDirectory, "*.cdr");

        foreach (string inputPath in cdrFiles)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                continue;
            }

            // Prepare output path
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".psd");

            // Ensure output directory for this file exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR image
            using (Image image = Image.Load(inputPath))
            {
                CdrImage cdr = (CdrImage)image;

                // Configure PSD save options
                PsdOptions psdOptions = new PsdOptions
                {
                    CompressionMethod = CompressionMethod.RLE,
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = cdr.Width,
                        PageHeight = cdr.Height,
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None
                    }
                };

                // Export all pages as separate layers in the PSD
                if (cdr.PageCount > 1)
                {
                    psdOptions.MultiPageOptions = new MultiPageOptions(new IntRange(0, cdr.PageCount));
                }

                // Save as PSD
                cdr.Save(outputPath, psdOptions);
            }
        }
    }
}