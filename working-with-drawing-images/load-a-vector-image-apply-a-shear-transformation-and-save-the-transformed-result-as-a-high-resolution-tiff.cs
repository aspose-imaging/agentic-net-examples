using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image vectorImage = Image.Load(inputPath))
            {
                SvgImage svgImage = vectorImage as SvgImage;
                if (svgImage == null)
                {
                    Console.Error.WriteLine("Failed to load SVG image.");
                    return;
                }

                int outWidth = svgImage.Width * 2;
                int outHeight = svgImage.Height * 2;

                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.ResolutionSettings = new ResolutionSetting(300, 300);

                using (Image tiffImage = Image.Create(tiffOptions, outWidth, outHeight))
                {
                    Graphics graphics = new Graphics(tiffImage);

                    // Apply horizontal shear (shear factor 0.5)
                    Matrix shearMatrix = new Matrix(1, 0, 0.5f, 1, 0, 0);
                    graphics.Transform = shearMatrix;

                    graphics.DrawImage(svgImage, new Point(0, 0));

                    tiffImage.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}