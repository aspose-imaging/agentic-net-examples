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
        // Define input SVG and output APNG paths
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

        // Load the SVG vector graphic
        using (Image svgImage = Image.Load(inputPath))
        {
            int width = svgImage.Width;
            int height = svgImage.Height;

            // Configure APNG creation options
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = 200, // frame duration in milliseconds
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create the APNG canvas
            using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, width, height))
            {
                // Set background color for the canvas
                apngImage.BackgroundColor = Color.White;

                // Remove the default single frame
                apngImage.RemoveAllFrames();

                const int frameCount = 5;

                // Add frames by rasterizing the SVG each time
                for (int i = 0; i < frameCount; i++)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        // Render SVG to a raster image (PNG) in memory
                        svgImage.Save(ms, new PngOptions());
                        ms.Position = 0;

                        // Load the rasterized image
                        using (RasterImage raster = (RasterImage)Image.Load(ms))
                        {
                            apngImage.AddFrame(raster);
                        }
                    }
                }

                // Save the APNG (output file is already bound via FileCreateSource)
                apngImage.Save();
            }
        }
    }
}