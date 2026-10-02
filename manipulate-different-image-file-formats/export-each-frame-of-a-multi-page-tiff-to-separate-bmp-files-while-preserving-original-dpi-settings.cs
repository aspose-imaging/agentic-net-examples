// HOW-TO: Export each frame of a multi-page TIFF to BMP with original DPI in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputDirectory = "output_frames";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            using (TiffImage tiff = (TiffImage)Image.Load(inputPath))
            {
                double dpiX = tiff.HorizontalResolution;
                double dpiY = tiff.VerticalResolution;

                for (int i = 0; i < tiff.Frames.Count(); i++)
                {
                    var frame = tiff.Frames[i];
                    string outputPath = Path.Combine(outputDirectory, $"frame_{i + 1}.bmp");

                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    BmpOptions bmpOptions = new BmpOptions();
                    bmpOptions.BitsPerPixel = 24;
                    bmpOptions.ResolutionSettings = new ResolutionSetting(dpiX, dpiY);

                    frame.Save(outputPath, bmpOptions);
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
 * 1. When a developer needs to split a multi‑page scanned TIFF into individual BMP files for a legacy application that only accepts BMP images while keeping the original print resolution.
 * 2. When an imaging pipeline must extract each page of a multi‑page TIFF for separate processing, such as OCR or analysis, and the DPI information must be retained for accurate measurements.
 * 3. When a document management system stores high‑resolution TIFF archives and requires conversion of each page to BMP for thumbnail generation without losing the original DPI settings.
 * 4. When a medical imaging workflow needs to export each frame of a multi‑frame TIFF (e.g., radiology scans) to BMP files for compatibility with older diagnostic software that relies on DPI metadata.
 * 5. When a game‑development toolchain extracts sprite sheets saved as multi‑page TIFFs and converts each frame to BMP while preserving DPI to maintain correct scaling in the engine.
 */
