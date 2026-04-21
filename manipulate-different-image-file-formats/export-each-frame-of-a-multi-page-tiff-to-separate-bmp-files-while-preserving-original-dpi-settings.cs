using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input TIFF path
            string inputPath = "input.tif";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Output directory for extracted BMP frames
            string outputDir = "output_frames";
            Directory.CreateDirectory(outputDir);

            // Load the multi‑page TIFF
            using (TiffImage tiff = (TiffImage)Image.Load(inputPath))
            {
                int pageCount = tiff.PageCount;
                for (int i = 0; i < pageCount; i++)
                {
                    // Build output BMP file path
                    string outputPath = Path.Combine(outputDir, $"frame_{i + 1}.bmp");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Configure BMP options preserving original DPI and exporting a single page
                    BmpOptions bmpOptions = new BmpOptions
                    {
                        ResolutionSettings = new ResolutionSetting(tiff.HorizontalResolution, tiff.VerticalResolution),
                        MultiPageOptions = new MultiPageOptions(new IntRange(i, 1))
                    };

                    // Save the current frame as BMP
                    tiff.Save(outputPath, bmpOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}