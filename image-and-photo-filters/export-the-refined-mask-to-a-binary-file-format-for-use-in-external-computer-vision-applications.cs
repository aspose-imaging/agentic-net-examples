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
            // Hardcoded input and output paths
            string inputPath = "Input\\sample.jpg";
            string outputPath = "Output\\mask.bin";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load source image as RasterImage
            using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
            {
                // Prepare masking export options (required by the API)
                var exportOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new StreamSource(new MemoryStream())
                };

                // Configure masking options (GraphCut segmentation)
                var maskingOptions = new MaskingOptions
                {
                    Method = SegmentationMethod.GraphCut,
                    Decompose = false,
                    Args = new AutoMaskingArgs(),
                    BackgroundReplacementColor = Color.Transparent,
                    ExportOptions = exportOptions
                };

                // Perform masking
                var masking = new ImageMasking(sourceImage);
                using (MaskingResult maskingResult = masking.Decompose(maskingOptions))
                {
                    // Retrieve the binary mask (foreground)
                    using (RasterImage maskImage = maskingResult[1].GetMask())
                    {
                        int width = maskImage.Width;
                        int height = maskImage.Height;
                        int[] argbPixels = new int[width * height];
                        maskImage.SaveArgb32Pixels(new Rectangle(0, 0, width, height), argbPixels);

                        // Write pixel data to binary file
                        using (var fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                        using (var binaryWriter = new BinaryWriter(fileStream))
                        {
                            foreach (int pixel in argbPixels)
                            {
                                binaryWriter.Write(pixel);
                            }
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