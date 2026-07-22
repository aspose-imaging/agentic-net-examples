using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.tga";
        string outputPath = "output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the TGA image
            using (Image image = Image.Load(inputPath))
            {
                // Set the desired DPI (300x300)
                if (image is RasterImage rasterImage)
                {
                    rasterImage.HorizontalResolution = 300;
                    rasterImage.VerticalResolution = 300;
                }

                // Prepare TIFF save options
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                // Save as TIFF
                image.Save(outputPath, tiffOptions);
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
 * 1. When a developer needs to convert legacy TGA graphics used in video games to high‑resolution TIFF files for printing, they can change the DPI from 72 to 300 and save as TIFF.
 * 2. When an imaging pipeline requires standardizing image metadata before archiving, the code can adjust the horizontal and vertical resolution of a TGA image and output a TIFF with the correct DPI.
 * 3. When a CAD application exports textures as TGA but the downstream GIS system only accepts TIFF at 300 DPI, this snippet updates the DPI and performs the format conversion.
 * 4. When a batch process must prepare TGA screenshots for a compliance report that mandates 300 DPI TIFF images, the developer can use this code to ensure the resolution meets the specification.
 * 5. When a web service receives user‑uploaded TGA files and needs to generate high‑quality TIFF thumbnails for print‑ready PDFs, the code provides the DPI adjustment and format conversion in C#.
 */