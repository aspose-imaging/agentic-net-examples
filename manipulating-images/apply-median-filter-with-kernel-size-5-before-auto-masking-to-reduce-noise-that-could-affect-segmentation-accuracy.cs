using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.png";
        string outputDir = @"C:\temp\output";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(outputDir);

        // Load the image
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            // Apply median filter with kernel size 5
            raster.Filter(raster.Bounds, new MedianFilterOptions(5));

            // Set up auto‑masking arguments (default configuration)
            AutoMaskingArgs autoArgs = new AutoMaskingArgs();

            // Configure masking options
            MaskingOptions maskingOptions = new MaskingOptions
            {
                Method = SegmentationMethod.KMeans,   // Choose a segmentation method
                Decompose = true,                     // Decompose into separate segments
                Args = autoArgs,
                BackgroundReplacementColor = Color.Orange,
                ExportOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new StreamSource(new MemoryStream())
                }
            };

            // Create ImageMasking instance
            ImageMasking masking = new ImageMasking(raster);

            // Perform decomposition
            using (MaskingResult maskingResult = masking.Decompose(maskingOptions))
            {
                for (int i = 0; i < maskingResult.Length; i++)
                {
                    string outputPath = Path.Combine(outputDir, $"Segment{i + 1}.png");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Retrieve segment image and save it
                    using (Image segmentImage = maskingResult[i].GetImage())
                    {
                        segmentImage.Save(outputPath);
                    }
                }
            }
        }
    }
}