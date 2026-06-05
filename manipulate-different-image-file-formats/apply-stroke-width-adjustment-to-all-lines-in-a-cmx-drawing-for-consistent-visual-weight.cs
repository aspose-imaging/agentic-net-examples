using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.cmx";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (CmxImage cmxImage = (CmxImage)Image.Load(inputPath))
            {
                int width = cmxImage.Width;
                int height = cmxImage.Height;

                PngOptions pngOptions = new PngOptions();
                pngOptions.Source = new FileCreateSource(outputPath, false);
                using (Image rasterImage = Image.Create(pngOptions, width, height))
                {
                    Graphics graphics = new Graphics(rasterImage);
                    graphics.Clear(Color.White);
                    graphics.DrawImage(cmxImage, new Rectangle(0, 0, width, height), new Rectangle(0, 0, width, height), GraphicsUnit.Pixel);
                    rasterImage.Save();
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
 * 1. When a CAD engineer needs to convert legacy CMX drawings to high‑resolution PNGs while ensuring all line weights appear uniform for printing on large‑format plots.
 * 2. When a GIS analyst imports CMX map symbols into a web portal and must standardize stroke widths so the symbols look consistent across different screen resolutions.
 * 3. When a publishing workflow processes architectural CMX files and requires adjusting line thickness before rasterizing to PNG to meet the publisher’s style guide for line weight.
 * 4. When an automation script generates thumbnails of CMX schematics for a document management system and needs to normalize stroke widths to improve visual clarity in the thumbnails.
 * 5. When a quality‑control tool validates engineering drawings by converting CMX to PNG and applies a uniform stroke width to detect deviations in line weight across multiple files.
 */