using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Temp\input.pdf";
        string outputPath = @"C:\Temp\output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PDF document
        using (Image pdfImage = Image.Load(inputPath))
        {
            // Prepare SVG export options
            SvgOptions exportOptions = new SvgOptions();

            // Export only the first two pages (adjust as needed)
            exportOptions.MultiPageOptions = new MultiPageOptions(new IntRange(0, 2));

            // Configure vector rasterization options
            var vectorOptions = new VectorRasterizationOptions
            {
                BackgroundColor = Color.White,
                TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                SmoothingMode = SmoothingMode.None
            };
            exportOptions.VectorRasterizationOptions = vectorOptions;

            // Save combined layers as a single SVG file
            pdfImage.Save(outputPath, exportOptions);
        }
    }
}