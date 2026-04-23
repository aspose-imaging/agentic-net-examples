using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputPath = "input/template.svg";
            string originalRasterPath = "output/original.png";
            string outputPath = "output/blurred.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(originalRasterPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load SVG and rasterize to PNG (original)
            using (Image img = Image.Load(inputPath))
            {
                SvgImage svgImage = (SvgImage)img;

                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size,
                    BackgroundColor = Color.White
                };

                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                svgImage.Save(originalRasterPath, pngOptions);
            }

            // Load rasterized image, apply motion blur, and save
            using (Image img = Image.Load(originalRasterPath))
            {
                RasterImage raster = (RasterImage)img;

                // Motion blur: size 7, brightness 1.0, angle 315
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(7, 1.0, 315.0));

                raster.Save(outputPath);
            }

            // Compare original and blurred images pixel-wise
            using (Image imgOrig = Image.Load(originalRasterPath))
            using (Image imgBlur = Image.Load(outputPath))
            {
                RasterImage orig = (RasterImage)imgOrig;
                RasterImage blur = (RasterImage)imgBlur;

                bool identical = true;

                if (orig.Width != blur.Width || orig.Height != blur.Height)
                {
                    identical = false;
                }
                else
                {
                    int[] origPixels = orig.LoadArgb32Pixels(orig.Bounds);
                    int[] blurPixels = blur.LoadArgb32Pixels(blur.Bounds);

                    for (int i = 0; i < origPixels.Length; i++)
                    {
                        if (origPixels[i] != blurPixels[i])
                        {
                            identical = false;
                            break;
                        }
                    }
                }

                Console.WriteLine(identical ? "Images are identical." : "Images differ after blur.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}