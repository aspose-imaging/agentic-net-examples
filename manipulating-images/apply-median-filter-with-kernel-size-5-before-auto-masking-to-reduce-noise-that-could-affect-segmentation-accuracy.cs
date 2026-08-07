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
        string inputPath = "input.jpg";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                var maskingOptions = new AutoMaskingGraphCutOptions
                {
                    CalculateDefaultStrokes = true,
                    FeatheringRadius = (Math.Max(image.Width, image.Height) / 500) + 1,
                    Method = SegmentationMethod.GraphCut,
                    Decompose = false,
                    ExportOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new StreamSource(new MemoryStream())
                    },
                    BackgroundReplacementColor = Color.Transparent
                };

                ImageMasking masking = new ImageMasking(image);
                using (MaskingResult result = masking.Decompose(maskingOptions))
                using (RasterImage foreground = (RasterImage)result[1].GetImage())
                {
                    foreground.Save(outputPath, new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha
                    });
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to automatically remove noisy backgrounds from JPEG photographs and export the isolated foreground as a transparent PNG for web galleries.
 * 2. When an e‑commerce platform must batch‑process product images, applying a 5×5 median filter to smooth grainy photos before using Aspose.Imaging’s graph‑cut auto‑masking to create clean cut‑outs.
 * 3. When a medical imaging application requires preprocessing of scanned slides with a median filter to suppress speckle noise prior to segmentation and exporting the result in PNG with an alpha channel.
 * 4. When a mobile app generates user avatars from uploaded pictures, using C# to load the image, denoise it, perform auto‑masking, and save the trimmed face region as a transparent PNG for overlay.
 * 5. When a document‑automation system needs to extract logos from mixed‑format source files, applying median filtering to improve mask accuracy and then saving the logo with transparency for reuse in PDFs.
 */