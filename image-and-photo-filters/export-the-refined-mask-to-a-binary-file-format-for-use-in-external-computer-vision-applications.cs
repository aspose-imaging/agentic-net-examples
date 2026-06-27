using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\sourceImage.png";
            string outputPath = @"C:\temp\mask.bin";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load source image
            using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
            {
                // Prepare masking options (no export needed for mask extraction)
                var maskingOptions = new MaskingOptions
                {
                    Method = SegmentationMethod.KMeans, // any method; using KMeans as example
                    Decompose = true,
                    Args = new AutoMaskingArgs { NumberOfObjects = 2 },
                    BackgroundReplacementColor = Color.Transparent,
                    ExportOptions = new PngOptions() // placeholder; not used for mask extraction
                };

                // Perform masking
                var masking = new ImageMasking(sourceImage);
                using (MaskingResult maskingResult = masking.Decompose(maskingOptions))
                {
                    // Obtain the mask of the first foreground object (index 1)
                    using (RasterImage maskImage = maskingResult[1].GetMask())
                    {
                        // Save mask to a memory stream in BMP format (raw binary representation)
                        using (var ms = new MemoryStream())
                        {
                            var bmpOptions = new BmpOptions();
                            maskImage.Save(ms, bmpOptions);
                            byte[] maskBytes = ms.ToArray();

                            // Write binary data to the output file
                            File.WriteAllBytes(outputPath, maskBytes);
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
 * 1. When a developer needs to feed a binary mask into a machine‑learning model that expects raw pixel data for object segmentation, they can use this code to generate a .bin file from a PNG source.
 * 2. When integrating a .NET imaging pipeline with a third‑party vision SDK that only accepts binary mask files for defect detection on manufactured parts, the code exports the mask in BMP binary format for seamless import.
 * 3. When building an augmented‑reality app that overlays virtual objects only on foreground regions, the binary mask saved by this code can be transmitted to the AR engine that reads raw mask bytes.
 * 4. When performing batch processing of satellite imagery where a GIS system requires binary masks to delineate land‑cover classes, developers can automate mask extraction and save each mask as a .bin file.
 * 5. When creating a custom OCR pre‑processing step that isolates text regions and supplies the mask to a separate C++ OCR library that reads binary mask files, this code provides the necessary .bin output.
 */