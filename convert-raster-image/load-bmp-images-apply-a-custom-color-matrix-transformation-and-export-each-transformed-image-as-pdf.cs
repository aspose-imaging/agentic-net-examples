using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            // Ensure input and output directories exist
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add BMP files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.bmp");
            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
                {
                    Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;
                    if (!raster.IsCached)
                    {
                        raster.CacheData();
                    }

                    // Apply a simple invert color transformation
                    for (int y = 0; y < raster.Height; y++)
                    {
                        for (int x = 0; x < raster.Width; x++)
                        {
                            Aspose.Imaging.Color pixel = raster.GetPixel(x, y);
                            byte a = pixel.A;
                            byte r = (byte)(255 - pixel.R);
                            byte g = (byte)(255 - pixel.G);
                            byte b = (byte)(255 - pixel.B);
                            raster.SetPixel(x, y, Aspose.Imaging.Color.FromArgb(a, r, g, b));
                        }
                    }

                    string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".pdf";
                    string outputPath = Path.Combine(outputDirectory, outputFileName);

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save as PDF
                    raster.Save(outputPath, new PdfOptions());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}