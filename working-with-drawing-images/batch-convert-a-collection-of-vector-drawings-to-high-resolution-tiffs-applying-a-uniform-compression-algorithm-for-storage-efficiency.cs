using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Directory setup (atomic block as required)
        string baseDir = Directory.GetCurrentDirectory();
        string inputDirectory = Path.Combine(baseDir, "Input");
        string outputDirectory = Path.Combine(baseDir, "Output");

        if (!Directory.Exists(inputDirectory))
        {
            Directory.CreateDirectory(inputDirectory);
            Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
            return;
        }

        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        string[] files = Directory.GetFiles(inputDirectory, "*.*");

        foreach (var inputPath in files)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                continue;
            }

            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".tif");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                // Configure TIFF options with uniform compression (LZW) and high resolution
                using (var tiffOptions = new TiffOptions(TiffExpectedFormat.Default))
                {
                    tiffOptions.Compression = TiffCompressions.Lzw;
                    tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
                    tiffOptions.Photometric = TiffPhotometrics.Rgb;
                    tiffOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;
                    tiffOptions.ResolutionSettings = new ResolutionSetting(300, 300); // 300 DPI

                    // Vector rasterization for vector drawings
                    tiffOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height,
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None
                    };

                    image.Save(outputPath, tiffOptions);
                }
            }
        }
    }
}