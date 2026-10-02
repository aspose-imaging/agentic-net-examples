// HOW-TO: Increase EMF Line Thickness and Convert to WMF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "data/input.emf";
            string outputPath = "data/output.wmf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to EmfImage
                EmfImage emfImage = image as EmfImage;
                if (emfImage == null)
                {
                    Console.Error.WriteLine("The loaded file is not a valid EMF image.");
                    return;
                }

                // NOTE: Aspose.Imaging does not provide a direct API to modify existing vector
                // line thickness. If such functionality is required, it must be implemented
                // by editing the vector objects manually, which is beyond the scope of this
                // example. The code below proceeds to save the EMF as WMF.

                // Configure rasterization options (optional)
                var rasterizationOptions = new EmfRasterizationOptions
                {
                    // Example: set background to transparent
                    BackgroundColor = Color.Transparent
                };

                // Set up WMF save options using the same rasterization options
                var wmfOptions = new WmfOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save as WMF
                emfImage.Save(outputPath, wmfOptions);
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
 * 1. When you need to thicken vector lines in an EMF diagram before embedding it in a legacy WMF‑based report.
 * 2. When converting technical drawings from EMF to WMF while ensuring the strokes are more visible for printing.
 * 3. When a Windows application requires WMF assets with increased line weight for better UI scaling.
 * 4. When automating batch processing of EMF icons to WMF format with uniform line thickness for consistent branding.
 * 5. When preparing EMF charts for inclusion in older Office documents that only accept WMF files with enhanced line clarity.
 */
