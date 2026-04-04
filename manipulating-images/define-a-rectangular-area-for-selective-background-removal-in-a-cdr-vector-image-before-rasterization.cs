using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;

class Program
{
    static void Main(string[] args)
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\Images\sample.cdr";
        string tempRasterPath = Path.Combine(Path.GetTempPath(), "tempRaster.png");
        string outputPath = @"C:\Images\result.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
        Directory.CreateDirectory(Path.GetDirectoryName(tempRasterPath));

        // Load the CDR vector image and rasterize to a temporary PNG
        using (Image vectorImg = Image.Load(inputPath))
        {
            var vectorImage = vectorImg as VectorImage;
            if (vectorImage == null)
            {
                Console.Error.WriteLine("The input file is not a supported vector image.");
                return;
            }

            var rasterOptions = new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha,
                Source = new FileCreateSource(tempRasterPath, false),
                VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.Transparent,
                    PageSize = vectorImage.Size
                }
            };
            vectorImage.Save(tempRasterPath, rasterOptions);
        }

        // Load the rasterized image for masking
        using (RasterImage rasterImage = (RasterImage)Image.Load(tempRasterPath))
        {
            var maskingOptions = new MaskingOptions
            {
                Method = Masking.Options.SegmentationMethod.Manual,
                Decompose = false,
                BackgroundReplacementColor = Color.Transparent,
                ExportOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new StreamSource(new MemoryStream())
                }
            };

            // Perform masking
            using (MaskingResult maskingResult = new ImageMasking(rasterImage).Decompose(maskingOptions))
            {
                using (Image resultImage = maskingResult[1].GetImage())
                {
                    resultImage.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                }
            }
        }

        // Clean up temporary raster file
        if (File.Exists(tempRasterPath))
        {
            File.Delete(tempRasterPath);
        }
    }
}