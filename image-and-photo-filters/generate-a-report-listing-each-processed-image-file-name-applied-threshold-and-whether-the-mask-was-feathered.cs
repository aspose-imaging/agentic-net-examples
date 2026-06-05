using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            string[] files = Directory.GetFiles(inputDirectory);
            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Placeholder threshold value for reporting
                int threshold = 128;
                // Placeholder feathering flag for reporting
                bool feathered = false;

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, $"{fileName}_masked.png");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load image as RasterImage
                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    // Export options for PNG with transparent background
                    PngOptions exportOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new StreamSource(new MemoryStream())
                    };

                    // Masking options (GraphCut without feathering)
                    MaskingOptions maskingOptions = new MaskingOptions
                    {
                        Method = SegmentationMethod.GraphCut,
                        Decompose = false,
                        Args = new AutoMaskingArgs(),
                        BackgroundReplacementColor = Color.Transparent,
                        ExportOptions = exportOptions
                    };

                    // Perform masking
                    using (MaskingResult maskingResult = new ImageMasking(image).Decompose(maskingOptions))
                    {
                        using (RasterImage foreground = (RasterImage)maskingResult[1].GetImage())
                        {
                            foreground.Save(outputPath, exportOptions);
                        }
                    }
                }

                // Report
                Console.WriteLine($"{Path.GetFileName(inputPath)}\tThreshold: {threshold}\tFeathered: {feathered}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}