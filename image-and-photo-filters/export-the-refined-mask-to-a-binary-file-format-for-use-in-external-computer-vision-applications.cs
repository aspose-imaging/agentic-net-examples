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
            string inputPath = "Input\\sample.png";
            string outputPath = "Output\\mask.bin";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                var maskingOptions = new MaskingOptions
                {
                    Method = SegmentationMethod.GraphCut,
                    Decompose = false,
                    Args = new AutoMaskingArgs(),
                    BackgroundReplacementColor = Color.Transparent,
                    ExportOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new StreamSource(new MemoryStream())
                    }
                };

                using (MaskingResult maskingResult = new ImageMasking(image).Decompose(maskingOptions))
                {
                    using (RasterImage mask = maskingResult[1].GetMask())
                    {
                        int[] argbPixels = mask.LoadArgb32Pixels(new Rectangle(0, 0, mask.Width, mask.Height));

                        using (var fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                        using (var writer = new BinaryWriter(fileStream))
                        {
                            foreach (int pixel in argbPixels)
                            {
                                writer.Write(pixel);
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

/*
 * Real-World Use Cases:
 * 1. When a developer needs to generate a binary ARGB mask from a PNG image using Aspose.Imaging in C# and store it as a .bin file for consumption by a machine‑learning model that requires raw pixel data.
 * 2. When integrating background removal via GraphCut segmentation into a .NET application and exporting the resulting mask to a binary format for downstream processing with OpenCV or other computer‑vision libraries.
 * 3. When building a cloud‑based image analysis service that receives user‑uploaded PNGs, creates refined masks with AutoMaskingArgs, and saves the masks as compact binary files for fast retrieval by external vision APIs.
 * 4. When running a batch job that converts a library of PNG assets into binary mask files to be loaded by a robotics vision system that reads .bin files directly for object detection.
 * 5. When developing a custom annotation tool that lets users edit image masks and then persists the mask layer as a binary file to minimize storage size and enable rapid loading in real‑time video processing pipelines.
 */