using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input CDR files
        string[] inputPaths = new[]
        {
            @"C:\Input\file1.cdr",
            @"C:\Input\file2.cdr"
        };

        // Hardcoded output directory
        string outputDirectory = @"C:\Output";

        foreach (string inputPath in inputPaths)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Prepare output path
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".png");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load CDR image, remove background, rasterize to PNG with compression
            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                // Remove background using default settings
                cdr.RemoveBackground(new RemoveBackgroundSettings());

                // Configure PNG options
                PngOptions pngOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    PngCompressionLevel = PngCompressionLevel.ZipLevel9,
                    VectorRasterizationOptions = new CdrRasterizationOptions
                    {
                        BackgroundColor = Color.Transparent,
                        PageSize = cdr.Size
                    }
                };

                // Save rasterized PNG
                cdr.Save(outputPath, pngOptions);
            }
        }
    }
}