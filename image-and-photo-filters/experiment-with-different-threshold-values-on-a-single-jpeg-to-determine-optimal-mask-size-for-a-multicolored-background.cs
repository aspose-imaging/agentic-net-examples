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
            string inputPath = "input.jpg";
            string outputDir = "output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            int[] thresholds = new int[] { 10, 20, 30, 40, 50 };

            foreach (int threshold in thresholds)
            {
                // Load the source JPEG as a raster image
                using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
                {
                    // Prepare export options for the mask (PNG with alpha)
                    PngOptions exportOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new StreamSource(new MemoryStream())
                    };

                    // Configure masking options (GraphCut algorithm)
                    MaskingOptions maskingOptions = new MaskingOptions
                    {
                        Method = SegmentationMethod.GraphCut,
                        Decompose = false,
                        Args = new AutoMaskingArgs(),
                        BackgroundReplacementColor = Color.Transparent,
                        ExportOptions = exportOptions
                    };

                    // (Optional) Use the threshold value to influence the process.
                    // Here we simply embed it in the output filename; real threshold logic
                    // would depend on a specific algorithm which is not exposed directly.

                    // Perform masking
                    ImageMasking masking = new ImageMasking(sourceImage);
                    using (MaskingResult maskingResult = masking.Decompose(maskingOptions))
                    {
                        // Obtain the foreground mask
                        using (RasterImage mask = maskingResult[1].GetMask())
                        {
                            string outputPath = Path.Combine(outputDir, $"mask_{threshold}.png");
                            // Ensure the directory exists (already created above)
                            mask.Save(outputPath, exportOptions);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}