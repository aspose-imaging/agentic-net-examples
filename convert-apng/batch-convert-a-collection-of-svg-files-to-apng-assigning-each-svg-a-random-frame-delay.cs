using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input SVG files and output APNG file
        string[] inputPaths = { "input1.svg", "input2.svg", "input3.svg" };
        string outputPath = "output.apng";

        // Verify each input file exists
        foreach (string inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Determine canvas size from the first SVG
        int canvasWidth;
        int canvasHeight;
        using (Image firstSvg = Image.Load(inputPaths[0]))
        using (MemoryStream msFirst = new MemoryStream())
        {
            firstSvg.Save(msFirst, new PngOptions());
            msFirst.Position = 0;
            using (RasterImage firstRaster = (RasterImage)Image.Load(msFirst))
            {
                canvasWidth = firstRaster.Width;
                canvasHeight = firstRaster.Height;
            }
        }

        // Create APNG image with the determined size
        ApngOptions createOptions = new ApngOptions
        {
            Source = new FileCreateSource(outputPath, false),
            ColorType = PngColorType.TruecolorWithAlpha
        };

        using (ApngImage apng = (ApngImage)Image.Create(createOptions, canvasWidth, canvasHeight))
        {
            apng.RemoveAllFrames();

            Random rnd = new Random();

            // Process each SVG, rasterize, assign random frame delay, and add as a frame
            foreach (string inputPath in inputPaths)
            {
                using (Image svgImage = Image.Load(inputPath))
                using (MemoryStream ms = new MemoryStream())
                {
                    svgImage.Save(ms, new PngOptions());
                    ms.Position = 0;
                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        uint randomDelay = (uint)rnd.Next(50, 500); // delay in milliseconds
                        apng.DefaultFrameTime = randomDelay;
                        apng.AddFrame(raster);
                    }
                }
            }

            // Save the assembled APNG
            apng.Save();
        }
    }
}