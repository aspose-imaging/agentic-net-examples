using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output directories (relative paths)
        string inputDirectory = "Input";
        string outputDirectory = "Output";

        // Validate input directory
        if (!Directory.Exists(inputDirectory))
        {
            Directory.CreateDirectory(inputDirectory);
            Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
            return;
        }

        // Ensure output directory exists
        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        // Get all CDR files in the input directory
        string[] files = Directory.GetFiles(inputDirectory, "*.cdr");

        foreach (string inputPath in files)
        {
            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Prepare output path with .bmp extension
            string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".bmp");

            // Ensure the output directory for this file exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR image
            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                // Configure BMP options with 24‑bit color depth
                BmpOptions bmpOptions = new BmpOptions
                {
                    BitsPerPixel = 24,
                    // Set vector rasterization options for proper rendering
                    VectorRasterizationOptions = new CdrRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = cdr.Width,
                        PageHeight = cdr.Height,
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None
                    }
                };

                // Save the image as BMP
                cdr.Save(outputPath, bmpOptions);
            }
        }
    }
}