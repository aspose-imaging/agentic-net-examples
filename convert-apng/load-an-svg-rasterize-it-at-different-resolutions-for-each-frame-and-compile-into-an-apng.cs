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
        // Hardcoded input SVG and output APNG paths
        string inputSvgPath = "input.svg";
        string outputApngPath = "output.apng";

        // Verify input file exists
        if (!File.Exists(inputSvgPath))
        {
            Console.Error.WriteLine($"File not found: {inputSvgPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputApngPath));

        // Define rasterization sizes for each frame
        int[] widths = { 200, 400, 600 };
        int[] heights = { 200, 400, 600 };

        // Determine canvas size (maximum dimensions)
        int maxWidth = 0;
        int maxHeight = 0;
        foreach (int w in widths) if (w > maxWidth) maxWidth = w;
        foreach (int h in heights) if (h > maxHeight) maxHeight = h;

        // Load the SVG image once
        using (Image svgImage = Image.Load(inputSvgPath))
        {
            // Prepare APNG creation options
            ApngOptions apngCreateOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputApngPath, false),
                DefaultFrameTime = 200, // milliseconds per frame
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create the APNG canvas bound to the output file
            using (ApngImage apngImage = (ApngImage)Image.Create(apngCreateOptions, maxWidth, maxHeight))
            {
                // Remove the default initial frame
                apngImage.RemoveAllFrames();

                // Generate each frame at the specified resolution
                for (int i = 0; i < widths.Length; i++)
                {
                    int frameWidth = widths[i];
                    int frameHeight = heights[i];

                    // Configure rasterization options for the current size
                    var rasterOptions = new SvgRasterizationOptions
                    {
                        PageWidth = frameWidth,
                        PageHeight = frameHeight,
                        BackgroundColor = Color.White
                    };

                    // Configure PNG save options with the rasterization settings
                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterOptions
                    };

                    // Rasterize SVG to a memory stream
                    using (var ms = new MemoryStream())
                    {
                        svgImage.Save(ms, pngOptions);
                        ms.Position = 0;

                        // Load the rasterized frame as a RasterImage
                        using (RasterImage frame = (RasterImage)Image.Load(ms))
                        {
                            // Add the frame to the APNG
                            apngImage.AddFrame(frame);
                        }
                    }
                }

                // Save the APNG (output is already bound via FileCreateSource)
                apngImage.Save();
            }
        }
    }
}