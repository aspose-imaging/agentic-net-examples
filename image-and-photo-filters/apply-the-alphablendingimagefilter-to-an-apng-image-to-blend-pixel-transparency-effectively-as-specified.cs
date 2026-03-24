using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.apng";
        string outputPath = "output.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Temporary solid color image path
        string tempSolidPath = Path.Combine(Path.GetTempPath(), "solid.png");
        Directory.CreateDirectory(Path.GetDirectoryName(tempSolidPath));

        // Load source APNG
        using (Image srcImage = Image.Load(inputPath))
        {
            ApngImage srcApng = (ApngImage)srcImage;

            // Prepare output APNG options
            ApngOptions outOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create output APNG canvas
            using (ApngImage outApng = (ApngImage)Image.Create(outOptions, srcApng.Width, srcApng.Height))
            {
                outApng.RemoveAllFrames();

                // Process each frame
                for (int i = 0; i < srcApng.PageCount; i++)
                {
                    ApngFrame srcFrame = (ApngFrame)srcApng.Pages[i];
                    using (RasterImage frameRaster = (RasterImage)srcFrame)
                    {
                        // Create a solid color raster image (semi‑transparent red)
                        using (RasterImage solid = (RasterImage)Image.Create(
                            new PngOptions
                            {
                                Source = new FileCreateSource(tempSolidPath, false),
                                ColorType = PngColorType.TruecolorWithAlpha
                            },
                            frameRaster.Width,
                            frameRaster.Height))
                        {
                            // Fill solid image with semi‑transparent red
                            Graphics g = new Graphics(solid);
                            g.Clear(Color.FromArgb(128, 255, 0, 0));

                            // Blend solid color onto the frame with 50% opacity
                            frameRaster.Blend(new Point(0, 0), solid, 128);
                        }

                        // Add the blended frame to the output APNG
                        outApng.AddFrame(frameRaster);
                    }
                }

                // Save the resulting APNG
                outApng.Save();
            }
        }

        // Cleanup temporary file
        if (File.Exists(tempSolidPath))
        {
            try { File.Delete(tempSolidPath); } catch { }
        }
    }
}