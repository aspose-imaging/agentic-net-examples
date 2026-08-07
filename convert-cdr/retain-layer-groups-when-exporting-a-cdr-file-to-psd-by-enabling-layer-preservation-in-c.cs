using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = Path.Combine("Input", "sample.cdr");
            string outputPath = Path.Combine("Output", "sample.psd");

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR file
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PSD export options with layer preservation
                PsdOptions psdOptions = new PsdOptions();

                // Set vector rasterization options for proper size and rendering
                psdOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = image.Width,
                    PageHeight = image.Height,
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None
                };

                // Enable layer groups by using separate layers composition mode
                psdOptions.VectorizationOptions = new PsdVectorizationOptions
                {
                    VectorDataCompositionMode = VectorDataCompositionMode.SeparateLayers
                };

                // Save as PSD preserving layers
                image.Save(outputPath, psdOptions);
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
 * 1. When a developer must convert CorelDRAW .cdr files to Photoshop .psd format in a C# application while preserving the original layer groups for post‑conversion editing.
 * 2. When an automated workflow needs to export vector‑rich CDR artwork to PSD with separate layers so designers can adjust colors and effects in Adobe Photoshop without losing structure.
 * 3. When a SaaS platform offers users the ability to upload .cdr designs and download editable .psd files, requiring Aspose.Imaging to retain vector layers and groups during the conversion.
 * 4. When a batch processing script processes multiple CorelDRAW files and must maintain each object's hierarchy in the resulting PSD to support downstream image processing pipelines.
 * 5. When integrating a .NET service that generates printable assets, and the service must export CDR graphics to PSD while keeping vector data as separate layers for precise rasterization control.
 */