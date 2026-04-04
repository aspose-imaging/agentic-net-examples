using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input\\sample.jpg";
        string outputPath = "Output\\mask.bin";

        // Verify input file exists
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
            // Configure masking options
            var exportOptions = new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha,
                Source = new StreamSource(new MemoryStream())
            };

            var maskingOptions = new MaskingOptions
            {
                Method = SegmentationMethod.GraphCut,
                Decompose = false,
                Args = new AutoMaskingArgs(),
                BackgroundReplacementColor = Color.Transparent,
                ExportOptions = exportOptions
            };

            // Perform masking to obtain the foreground mask
            var masking = new ImageMasking(sourceImage);
            using (MaskingResult maskingResult = masking.Decompose(maskingOptions))
            using (RasterImage maskImage = (RasterImage)maskingResult[1].GetMask())
            {
                // Extract raw ARGB pixel data
                int width = maskImage.Width;
                int height = maskImage.Height;
                int[] pixels = new int[width * height];
                maskImage.SaveArgb32Pixels(new Aspose.Imaging.Rectangle(0, 0, width, height), pixels);

                // Write pixel data to binary file
                using (FileStream fs = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    foreach (int pixel in pixels)
                    {
                        bw.Write(pixel);
                    }
                }
            }
        }
    }
}