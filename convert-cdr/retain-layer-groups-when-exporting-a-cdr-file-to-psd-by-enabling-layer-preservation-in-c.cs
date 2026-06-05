using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input and output paths
            string inputPath = "Input/sample.cdr";
            string outputPath = "Output/sample.psd";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load CDR image
            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                // Prepare PSD export options
                var psdOptions = new PsdOptions();

                // Preserve all pages as layers
                psdOptions.MultiPageOptions = new MultiPageOptions(new IntRange(0, cdr.PageCount - 1));

                // Set vector rasterization options
                psdOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = cdr.Width,
                    PageHeight = cdr.Height,
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None
                };

                // Save as PSD with layer groups preserved
                cdr.Save(outputPath, psdOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}