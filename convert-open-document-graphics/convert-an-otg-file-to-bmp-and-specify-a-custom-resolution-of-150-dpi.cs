using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.otg";
            string outputPath = @"C:\Images\sample.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the OTG image
            using (Image otgImage = Image.Load(inputPath))
            {
                // Configure rasterization options for OTG
                OtgRasterizationOptions otgRasterOptions = new OtgRasterizationOptions
                {
                    PageSize = otgImage.Size
                };

                // Set up BMP save options with the rasterization options
                BmpOptions bmpSaveOptions = new BmpOptions
                {
                    VectorRasterizationOptions = otgRasterOptions
                };

                // Save as BMP
                otgImage.Save(outputPath, bmpSaveOptions);
            }

            // Load the saved BMP to adjust resolution
            using (Image bmpImage = Image.Load(outputPath))
            {
                BmpImage bmp = (BmpImage)bmpImage;
                bmp.SetResolution(150.0, 150.0);
                bmp.Save(outputPath);
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
 * 1. When a CAD application exports engineering drawings as OTG files and a developer needs to generate high‑resolution BMP images at 150 DPI for inclusion in printed technical manuals.
 * 2. When a medical imaging system stores vector‑based scans in OTG format and the software must convert them to BMP with a fixed 150 DPI to meet the resolution requirements of legacy diagnostic equipment.
 * 3. When an e‑learning platform receives OTG illustrations from content creators and must rasterize them to BMP at 150 DPI for consistent display on low‑resolution student devices.
 * 4. When a document management workflow archives OTG graphics as BMP files with a standardized 150 DPI setting to ensure uniform printing quality across different office printers.
 * 5. When a game development pipeline imports OTG assets and needs to produce BMP textures at 150 DPI for use in legacy rendering engines that only support raster image formats.
 */