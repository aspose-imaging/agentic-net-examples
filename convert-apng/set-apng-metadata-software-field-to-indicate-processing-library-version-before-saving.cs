using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.apng";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load source raster image
            using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
            {
                // Configure APNG options
                ApngOptions options = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    DefaultFrameTime = 100, // default frame duration in ms
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                // Create APNG image bound to the output file
                using (ApngImage apngImage = (ApngImage)Image.Create(options, sourceImage.Width, sourceImage.Height))
                {
                    // Remove default frame
                    apngImage.RemoveAllFrames();

                    // Add the source image as a single frame
                    apngImage.AddFrame(sourceImage);

                    // Save the APNG (output path already bound)
                    apngImage.Save();
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
 * 1. When generating animated PNGs for a web application, a developer may embed the Aspose.Imaging for .NET version in the “Software” metadata field to trace which library produced the file.
 * 2. When automating a batch conversion pipeline that creates APNG assets for a mobile game, setting the “Software” tag to the library version helps QA teams verify that the correct processing tool was used.
 * 3. When complying with digital asset management policies that require provenance information, developers can record the Aspose.Imaging version in the APNG “Software” metadata before saving the file.
 * 4. When troubleshooting rendering issues across different browsers, adding the library version to the APNG “Software” field allows support engineers to correlate problems with specific Aspose.Imaging releases.
 * 5. When delivering client‑side graphics where the client requests a report of the generation tool, embedding the Aspose.Imaging for .NET version in the APNG “Software” metadata provides a transparent audit trail.
 */