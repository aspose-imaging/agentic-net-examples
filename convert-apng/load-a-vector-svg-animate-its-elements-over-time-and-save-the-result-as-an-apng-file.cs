using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.svg";
            string outputPath = "output.apng";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (Image img = Image.Load(inputPath))
            {
                SvgImage svgImage = (SvgImage)img;
                int width = svgImage.Width;
                int height = svgImage.Height;

                // Set up APNG creation options
                ApngOptions apngOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    DefaultFrameTime = 100, // 100 ms per frame
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                // Create the APNG canvas
                using (ApngImage apng = (ApngImage)Image.Create(apngOptions, width, height))
                {
                    apng.RemoveAllFrames();

                    int frameCount = 10;
                    int step = width / frameCount; // horizontal shift per frame

                    for (int i = 0; i < frameCount; i++)
                    {
                        // Create a raster frame
                        using (RasterImage frame = (RasterImage)Image.Create(
                            new PngOptions { Source = new FileCreateSource(Path.GetTempFileName(), false) },
                            width,
                            height))
                        {
                            // Draw the SVG at a varying offset
                            Graphics graphics = new Graphics(frame);
                            graphics.Clear(Color.Transparent);
                            int offsetX = i * step;
                            graphics.DrawImage(svgImage, new Point(offsetX, 0));

                            // Add the frame to the APNG
                            apng.AddFrame(frame);
                        }
                    }

                    // Save the animated PNG
                    apng.Save();
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}