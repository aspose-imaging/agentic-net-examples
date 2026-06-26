using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.cmx";
        string outputPath = "Output/output.tif";

        try
        {
            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load CMX vector image
            using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
            {
                // Configure TIFF save options with 8 bits per sample
                using (TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default))
                {
                    tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
                    tiffOptions.Photometric = TiffPhotometrics.Rgb;

                    // Set rasterization options for vector conversion
                    tiffOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = cmx.Width,
                        PageHeight = cmx.Height
                    };

                    // Save as TIFF
                    cmx.Save(outputPath, tiffOptions);
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
 * 1. When a developer needs to archive legacy CorelDRAW CMX vector drawings as compact 8‑bit per channel TIFF files for long‑term storage or compliance.
 * 2. When an application must generate printable TIFF images from CMX artwork while preserving RGB colors with 8‑bit depth for downstream publishing workflows.
 * 3. When a batch conversion tool is required to transform CMX files into TIFF format to feed into image analysis or OCR engines that only accept 8‑bit TIFF inputs.
 * 4. When integrating a C# service that receives CMX uploads and needs to rasterize them to 8‑bit TIFF for display in web browsers or mobile apps that support only raster images.
 * 5. When a developer wants to convert CMX vector graphics to TIFF with custom rasterization settings (page size, background color) and enforce an 8‑bit per sample color depth for consistent rendering across different platforms.
 */