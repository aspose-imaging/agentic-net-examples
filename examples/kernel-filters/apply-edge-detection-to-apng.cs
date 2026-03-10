using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input APNG file path
        string inputPath = "input.apng";
        // Output APNG file path
        string outputPath = "output_edge.apng";

        // Load the source APNG image
        using (ApngImage sourceApng = (ApngImage)Image.Load(inputPath))
        {
            // Prepare options for creating the output APNG
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                // Preserve default frame time from source (optional)
                DefaultFrameTime = sourceApng.DefaultFrameTime,
                // Use truecolor with alpha for full color support
                ColorType = Aspose.Imaging.FileFormats.Png.PngColorType.TruecolorWithAlpha
            };

            // Create a new APNG image with the same dimensions as the source
            using (ApngImage outputApng = (ApngImage)Image.Create(
                createOptions,
                sourceApng.Width,
                sourceApng.Height))
            {
                // Clear any default frame that exists
                outputApng.RemoveAllFrames();

                // Sobel kernel for edge detection
                double[,] sobelKernel = new double[,]
                {
                    { -1, 0, 1 },
                    { -2, 0, 2 },
                    { -1, 0, 1 }
                };

                // Process each frame of the source APNG
                for (int i = 0; i < sourceApng.PageCount; i++)
                {
                    // Get the current frame as a raster image
                    using (RasterImage frame = (RasterImage)sourceApng.Pages[i])
                    {
                        // Apply convolution filter (edge detection) to the entire frame
                        frame.Filter(
                            frame.Bounds,
                            new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(sobelKernel));

                        // Add the filtered frame to the output APNG
                        outputApng.AddFrame(frame);
                    }
                }

                // Save the resulting APNG
                outputApng.Save();
            }
        }
    }
}