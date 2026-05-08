using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.svg";
            string outputPath = "output/output.jpg";
            string tempPngPath = "output/temp.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));

            // Load the vector image and rasterize it to PNG
            using (Aspose.Imaging.Image vectorImage = Aspose.Imaging.Image.Load(inputPath))
            {
                var pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(tempPngPath, false)
                };

                if (vectorImage is Aspose.Imaging.VectorImage)
                {
                    pngOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        PageWidth = vectorImage.Width,
                        PageHeight = vectorImage.Height,
                        BackgroundColor = Aspose.Imaging.Color.White
                    };
                }

                vectorImage.Save(tempPngPath, pngOptions);
            }

            // Load the rasterized PNG, apply motion blur, and save as high‑quality JPEG
            using (Aspose.Imaging.Image img = Aspose.Imaging.Image.Load(tempPngPath))
            {
                var raster = (Aspose.Imaging.RasterImage)img;

                // Apply motion Wiener filter (motion blur)
                raster.Filter(raster.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(10, 1.0, 90.0));

                var jpegOptions = new JpegOptions
                {
                    Quality = 100,
                    Source = new FileCreateSource(outputPath, false)
                };

                raster.Save(outputPath, jpegOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}