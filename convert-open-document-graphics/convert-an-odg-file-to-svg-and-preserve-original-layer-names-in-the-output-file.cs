using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\sample.odg";
            string outputPath = @"C:\temp\sample.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to OdgImage to access ODG‑specific features
                OdgImage odgImage = image as OdgImage;
                if (odgImage == null)
                {
                    Console.Error.WriteLine("The input file is not a valid ODG image.");
                    return;
                }

                // Configure SVG export options
                SvgOptions svgOptions = new SvgOptions
                {
                    // Preserve original metadata (including layer names)
                    KeepMetadata = true,
                    // Set rasterization options matching the source size
                    VectorRasterizationOptions = new OdgRasterizationOptions
                    {
                        PageSize = odgImage.Size,
                        BackgroundColor = Color.White
                    }
                };

                // Save the image as SVG while preserving layer information
                odgImage.Save(outputPath, svgOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}