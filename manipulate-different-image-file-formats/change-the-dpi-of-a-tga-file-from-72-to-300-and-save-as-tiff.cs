// HOW-TO: Increase TGA Image DPI to 300 and Convert to TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tga";
            string outputPath = "output/output.tiff";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                image.HorizontalResolution = 300;
                image.VerticalResolution = 300;

                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
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
 * 1. When you need to prepare a low‑resolution TGA asset for high‑quality printing by raising its DPI to 300 and saving it as a TIFF file.
 * 2. When a game development pipeline requires converting legacy TGA textures to TIFF while standardizing the resolution for texture atlases.
 * 3. When a medical imaging application must import TGA scans, adjust their pixel density, and store them in a lossless TIFF format for archival.
 * 4. When an automated batch process must ensure all TGA graphics meet a 300 DPI specification before being used in a publishing workflow.
 * 5. When a desktop utility needs to read a TGA file, modify its horizontal and vertical resolution, and output a TIFF compatible with Photoshop.
 */
