using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDir = "Input";
            string outputDir = "Output";

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Process .tif files
            string[] tifFiles = Directory.GetFiles(inputDir, "*.tif");
            foreach (string tiffPath in tifFiles)
            {
                if (!File.Exists(tiffPath))
                {
                    Console.Error.WriteLine($"File not found: {tiffPath}");
                    continue;
                }

                string baseName = Path.GetFileNameWithoutExtension(tiffPath);
                using (TiffImage tiffImage = (TiffImage)Image.Load(tiffPath))
                {
                    tiffImage.PageExportingAction = delegate (int index, Image page)
                    {
                        string outPath = Path.Combine(outputDir, $"{baseName}_page{index}.webp");
                        Directory.CreateDirectory(Path.GetDirectoryName(outPath));
                        page.Save(outPath, new WebPOptions());
                    };

                    // Trigger sequential processing
                    using (var ms = new MemoryStream())
                    {
                        tiffImage.Save(ms);
                    }
                }
            }

            // Process .tiff files
            string[] tiffFiles = Directory.GetFiles(inputDir, "*.tiff");
            foreach (string tiffPath in tiffFiles)
            {
                if (!File.Exists(tiffPath))
                {
                    Console.Error.WriteLine($"File not found: {tiffPath}");
                    continue;
                }

                string baseName = Path.GetFileNameWithoutExtension(tiffPath);
                using (TiffImage tiffImage = (TiffImage)Image.Load(tiffPath))
                {
                    tiffImage.PageExportingAction = delegate (int index, Image page)
                    {
                        string outPath = Path.Combine(outputDir, $"{baseName}_page{index}.webp");
                        Directory.CreateDirectory(Path.GetDirectoryName(outPath));
                        page.Save(outPath, new WebPOptions());
                    };

                    // Trigger sequential processing
                    using (var ms = new MemoryStream())
                    {
                        tiffImage.Save(ms);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}