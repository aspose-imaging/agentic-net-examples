using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.apng";
        string outputPath = "output_emboss.apng";

        // Load the source APNG image
        using (ApngImage sourceApng = (ApngImage)Image.Load(inputPath))
        {
            // Prepare options for the output APNG
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create a new APNG canvas with the same dimensions as the source
            using (ApngImage resultApng = (ApngImage)Image.Create(
                createOptions,
                sourceApng.Width,
                sourceApng.Height))
            {
                // Ensure the canvas starts without any frames
                resultApng.RemoveAllFrames();

                // Process each frame: apply emboss filter and add to the result
                for (int i = 0; i < sourceApng.PageCount; i++)
                {
                    // Cast the page to RasterImage for filtering
                    using (RasterImage frame = (RasterImage)sourceApng.Pages[i])
                    {
                        // Apply Emboss filter using a predefined convolution kernel
                        frame.Filter(frame.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

                        // Add the filtered frame to the new APNG
                        resultApng.AddFrame(frame);
                    }
                }

                // Save the resulting APNG image
                resultApng.Save();
            }
        }
    }
}