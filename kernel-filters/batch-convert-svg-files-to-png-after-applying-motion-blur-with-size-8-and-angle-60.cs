using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.svg");

            foreach (string file in files)
            {
                string inputPath = file;
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(file) + ".png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image svgImage = Image.Load(inputPath))
                {
                    PngOptions pngOptions = new PngOptions();
                    SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions();
                    rasterOptions.PageSize = svgImage.Size;
                    pngOptions.VectorRasterizationOptions = rasterOptions;

                    using (MemoryStream ms = new MemoryStream())
                    {
                        svgImage.Save(ms, pngOptions);
                        ms.Position = 0;
                        using (RasterImage raster = (RasterImage)Image.Load(ms))
                        {
                            raster.Filter(raster.Bounds, new MotionWienerFilterOptions(8, 1.0, 60.0));
                            raster.Save(outputPath);
                        }
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