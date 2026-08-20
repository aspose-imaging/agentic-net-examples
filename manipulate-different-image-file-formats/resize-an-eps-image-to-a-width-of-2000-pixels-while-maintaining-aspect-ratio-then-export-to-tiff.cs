// HOW-TO: Resize EPS to 2000px Width and Save as TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.eps";
            string outputPath = "output.tiff";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                int targetWidth = 2000;
                int newHeight = (int)Math.Round((double)image.Height * targetWidth / image.Width);
                image.Resize(targetWidth, newHeight, ResizeType.NearestNeighbourResample);

                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
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
 * 1. When a designer provides vector EPS artwork that must be rasterized to a fixed 2000‑pixel width for high‑resolution printing, a developer can use this code to resize and output a TIFF file.
 * 2. When an automated publishing pipeline needs to convert incoming EPS logos to TIFF images with consistent width while preserving the original proportions, this snippet handles the transformation.
 * 3. When a legacy system requires TIFF files for archival but receives EPS files from suppliers, the code resizes the EPS to a standard width and saves it as a TIFF for compliance.
 * 4. When a web service generates preview thumbnails of EPS drawings and must maintain aspect ratio, developers can adapt this example to produce 2000‑pixel‑wide TIFF previews.
 * 5. When a batch job processes a folder of EPS files, resizing each to a uniform width before converting to TIFF for downstream image analysis, this approach provides the necessary resizing and format conversion.
 */
