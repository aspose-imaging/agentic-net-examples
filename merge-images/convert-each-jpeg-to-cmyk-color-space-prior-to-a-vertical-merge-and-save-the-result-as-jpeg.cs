using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

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

            Directory.CreateDirectory(outputDirectory);

            string[] files = Directory.GetFiles(inputDirectory, "*.*")
                                      .Where(f => f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                                                  f.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase))
                                      .ToArray();

            if (files.Length == 0)
            {
                Console.WriteLine("No JPEG files found in the input directory.");
                return;
            }

            List<string> cmykTempPaths = new List<string>();

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string tempFileName = Path.GetFileNameWithoutExtension(inputPath) + "_cmyk.jpg";
                string tempPath = Path.Combine(outputDirectory, tempFileName);
                Directory.CreateDirectory(Path.GetDirectoryName(tempPath));

                using (JpegImage jpeg = (JpegImage)Image.Load(inputPath))
                {
                    JpegOptions options = new JpegOptions
                    {
                        ColorType = JpegCompressionColorMode.Cmyk,
                        Quality = 100,
                        Source = new FileCreateSource(tempPath, false)
                    };
                    jpeg.Save();
                }

                cmykTempPaths.Add(tempPath);
            }

            List<Size> sizes = new List<Size>();
            foreach (string path in cmykTempPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            int canvasWidth = sizes.Max(s => s.Width);
            int canvasHeight = sizes.Sum(s => s.Height);

            string outputPath = Path.Combine(outputDirectory, "merged_cmyk.jpg");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            Source outSource = new FileCreateSource(outputPath, false);
            JpegOptions canvasOptions = new JpegOptions
            {
                ColorType = JpegCompressionColorMode.Cmyk,
                Quality = 100,
                Source = outSource
            };

            using (JpegImage canvas = (JpegImage)Image.Create(canvasOptions, canvasWidth, canvasHeight))
            {
                int offsetY = 0;
                foreach (string path in cmykTempPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        Rectangle bounds = new Rectangle(0, offsetY, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetY += img.Height;
                    }
                }
                canvas.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}