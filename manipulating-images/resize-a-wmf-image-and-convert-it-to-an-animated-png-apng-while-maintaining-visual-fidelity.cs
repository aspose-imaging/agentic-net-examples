using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input WMF file path
        string inputPath = "input.wmf";
        // Output APNG file path
        string outputPath = "output.apng";
        // Desired dimensions after resizing
        int targetWidth = 800;
        int targetHeight = 600;

        // Load the WMF image
        using (WmfImage wmfImage = (WmfImage)Image.Load(inputPath))
        {
            // Resize the WMF image to the target dimensions
            wmfImage.Resize(targetWidth, targetHeight);

            // Configure APNG options with vector rasterization for WMF
            var apngOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = 500, // 500 ms per frame
                ColorType = PngColorType.TruecolorWithAlpha,
                VectorRasterizationOptions = new WmfRasterizationOptions
                {
                    PageSize = new Size(targetWidth, targetHeight),
                    BackgroundColor = Color.White
                }
            };

            // Save the resized WMF as an animated PNG
            wmfImage.Save(outputPath, apngOptions);
        }
    }
}