using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input vector file (SVG) and output APNG file paths
        string inputVectorPath = "input.svg";
        string outputApngPath = "output.apng";

        // Load the vector image
        using (Image vectorImage = Image.Load(inputVectorPath))
        {
            // Original dimensions of the vector image
            int originalWidth = vectorImage.Width;
            int originalHeight = vectorImage.Height;

            // Define a scaling factor for the second frame
            double scaleFactor = 2.0;
            int scaledWidth = (int)(originalWidth * scaleFactor);
            int scaledHeight = (int)(originalHeight * scaleFactor);

            // Determine canvas size (largest frame)
            int canvasWidth = Math.Max(originalWidth, scaledWidth);
            int canvasHeight = Math.Max(originalHeight, scaledHeight);

            // Set up APNG creation options
            ApngOptions apngOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputApngPath, false),
                DefaultFrameTime = 500, // 500 ms per frame
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create the APNG image with the calculated canvas size
            using (ApngImage apngImage = (ApngImage)Image.Create(apngOptions, canvasWidth, canvasHeight))
            {
                // Ensure the APNG starts without any default frame
                apngImage.RemoveAllFrames();

                // Helper local function to rasterize the vector image at a given size and add as a frame
                void AddRasterizedFrame(int frameWidth, int frameHeight)
                {
                    // Configure rasterization options for the desired size
                    PngOptions rasterOptions = new PngOptions
                    {
                        VectorRasterizationOptions = new SvgRasterizationOptions
                        {
                            PageWidth = frameWidth,
                            PageHeight = frameHeight
                        }
                    };

                    // Rasterize the vector image into a memory stream
                    using (MemoryStream ms = new MemoryStream())
                    {
                        vectorImage.Save(ms, rasterOptions);
                        ms.Position = 0;

                        // Load the rasterized image and add it as a frame
                        using (RasterImage rasterFrame = (RasterImage)Image.Load(ms))
                        {
                            apngImage.AddFrame(rasterFrame);
                        }
                    }
                }

                // Add first frame at original size
                AddRasterizedFrame(originalWidth, originalHeight);

                // Add second frame at scaled size
                AddRasterizedFrame(scaledWidth, scaledHeight);

                // Save the APNG (output is already bound to the source)
                apngImage.Save();
            }
        }
    }
}