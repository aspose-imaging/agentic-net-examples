// HOW-TO: Convert Multi-Page EMF to Separate High-Resolution TIFF Files in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.emf";
            string outputDir = "output";
            int dpiX = 300;
            int dpiY = 300;

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (Image image = Image.Load(inputPath))
            {
                IMultipageImage multipage = image as IMultipageImage;
                int pageCount = multipage != null ? multipage.PageCount : 1;

                for (int i = 0; i < pageCount; i++)
                {
                    string outputPath = Path.Combine(outputDir, $"page_{i + 1}.tif");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    tiffOptions.ResolutionSettings = new ResolutionSetting(dpiX, dpiY);
                    tiffOptions.MultiPageOptions = new MultiPageOptions(new IntRange(i, 1));

                    image.Save(outputPath, tiffOptions);
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
 * 1. When you need to extract each page of a vector EMF report and save them as individual high-resolution TIFF images for printing or archival.
 * 2. When a batch process must convert multi-page EMF diagrams into separate TIFF files with a specific DPI to meet publishing standards.
 * 3. When an application generates EMF charts and you must provide each page as a raster TIFF for compatibility with legacy systems.
 * 4. When you want to automate splitting a multi-page EMF document into per-page TIFFs for use in document management or OCR pipelines.
 * 5. When you require precise control over the output resolution of each TIFF page while converting EMF graphics in a C# workflow.
 */
