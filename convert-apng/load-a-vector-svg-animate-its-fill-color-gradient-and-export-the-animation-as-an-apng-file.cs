using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\Images\input.svg";
        string outputPath = @"C:\Images\output.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load SVG source as text – it must contain a placeholder {fillColor}
        string svgTemplate = File.ReadAllText(inputPath);

        // Animation parameters
        const int frameCount = 20;          // number of frames
        const int frameDuration = 100;      // duration per frame in ms
        const int imageWidth = 400;         // desired raster width
        const int imageHeight = 400;        // desired raster height

        // Prepare APNG creation options
        ApngOptions createOptions = new ApngOptions
        {
            Source = new FileCreateSource(outputPath, false),
            DefaultFrameTime = (uint)frameDuration,
            ColorType = PngColorType.TruecolorWithAlpha
        };

        // Create an empty APNG image with the required dimensions
        using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, imageWidth, imageHeight))
        {
            // Remove the default single frame
            apngImage.RemoveAllFrames();

            // Generate frames with a smooth red‑to‑blue gradient
            for (int i = 0; i < frameCount; i++)
            {
                // Compute gradient color
                float t = (float)i / (frameCount - 1);
                int red = (int)(255 * (1 - t));
                int blue = (int)(255 * t);
                string fillColor = $"rgb({red},0,{blue})";

                // Insert the computed color into the SVG template
                string svgContent = svgTemplate.Replace("{fillColor}", fillColor);

                // Load the modified SVG from a memory stream
                using (MemoryStream svgStream = new MemoryStream())
                {
                    using (StreamWriter writer = new StreamWriter(svgStream))
                    {
                        writer.Write(svgContent);
                        writer.Flush();
                        svgStream.Position = 0;
                    }

                    using (SvgImage svgImage = new SvgImage(svgStream))
                    {
                        // Set rasterization options matching the target size
                        SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                        {
                            PageSize = new Size(imageWidth, imageHeight)
                        };

                        // Prepare PNG save options that use the rasterization settings
                        PngOptions pngOptions = new PngOptions
                        {
                            VectorRasterizationOptions = rasterOptions
                        };

                        // Rasterize SVG to PNG in a memory stream
                        using (MemoryStream pngStream = new MemoryStream())
                        {
                            svgImage.Save(pngStream, pngOptions);
                            pngStream.Position = 0;

                            // Load the rasterized PNG as a frame
                            using (RasterImage frame = (RasterImage)Image.Load(pngStream))
                            {
                                apngImage.AddFrame(frame);
                            }
                        }
                    }
                }
            }

            // Save the assembled APNG file
            apngImage.Save();
        }
    }
}