// HOW-TO: Convert PSD EMF Text to Vector Shapes and Export as TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.psd";
        string intermediateSvgPath = @"C:\Images\temp_output.svg";
        string outputPath = @"C:\Images\output.tif";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(intermediateSvgPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PSD image
            using (Image psdImage = Image.Load(inputPath))
            {
                // Prepare SVG save options with text rendered as shapes
                var svgOptions = new SvgOptions
                {
                    TextAsShapes = true,
                    VectorRasterizationOptions = new EmfRasterizationOptions
                    {
                        BackgroundColor = Aspose.Imaging.Color.White,
                        PageSize = psdImage.Size,
                        RenderMode = EmfRenderMode.Auto
                    }
                };

                // Save PSD as SVG (text becomes vector shapes)
                psdImage.Save(intermediateSvgPath, svgOptions);
            }

            // Load the generated SVG
            using (Image svgImage = Image.Load(intermediateSvgPath))
            {
                // Prepare TIFF save options
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                // Save the SVG as TIFF
                svgImage.Save(outputPath, tiffOptions);
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
 * 1. When you need to preserve editable vector text from a Photoshop PSD that contains EMF objects while generating a high‑resolution TIFF for printing.
 * 2. When a workflow requires converting embedded EMF annotations in a PSD into true vector shapes so they remain sharp after rasterizing to TIFF.
 * 3. When automating batch processing of design assets, you can turn PSD files with EMF text into TIFFs without losing vector quality using C#.
 * 4. When a client requests a TIFF delivery but the source PSD includes EMF text that must be converted to paths for compatibility with downstream GIS or CAD tools.
 * 5. When building a .NET service that extracts vector information from PSD layers and outputs a TIFF for archival or compliance purposes.
 */
