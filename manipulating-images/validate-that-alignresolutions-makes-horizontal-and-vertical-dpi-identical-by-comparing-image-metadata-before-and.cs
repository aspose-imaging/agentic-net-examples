// HOW-TO: Check and Align Horizontal and Vertical DPI of a TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (TiffImage image = (TiffImage)Image.Load(inputPath))
            {
                if (image.Frames.Count() == 0)
                {
                    Console.Error.WriteLine("No frames found in the image.");
                    return;
                }

                var frame = image.Frames[0];
                double hResBefore = frame.HorizontalResolution;
                double vResBefore = frame.VerticalResolution;

                Console.WriteLine($"Before alignment: Horizontal DPI = {hResBefore}, Vertical DPI = {vResBefore}");

                image.AlignResolutions();

                double hResAfter = frame.HorizontalResolution;
                double vResAfter = frame.VerticalResolution;

                Console.WriteLine($"After alignment: Horizontal DPI = {hResAfter}, Vertical DPI = {vResAfter}");

                image.Save(outputPath);
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
 * 1. When you need to ensure a scanned TIFF has matching horizontal and vertical DPI before printing to avoid distortion.
 * 2. When converting multi‑resolution TIFFs for archival and you must standardize the image resolution metadata.
 * 3. When validating image metadata in a C# application to confirm that DPI values are consistent after processing.
 * 4. When preparing TIFF files for a publishing workflow that requires uniform DPI for accurate layout calculations.
 * 5. When troubleshooting mismatched DPI values in TIFF frames and want to automatically align them using Aspose.Imaging.
 */
