using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.cmx";
        string outputPath = "output.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load CMX image
        using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
        {
            // Set custom background color for transparent regions (e.g., white)
            cmx.BackgroundColor = Aspose.Imaging.Color.White;
            cmx.HasBackgroundColor = true;

            // Prepare JPEG options with bound output source
            Source outputSource = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions
            {
                Source = outputSource,
                Quality = 100
            };

            // Create JPEG canvas with same dimensions as CMX
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, cmx.Width, cmx.Height))
            {
                // Apply the same background color to the canvas
                canvas.BackgroundColor = cmx.BackgroundColor;
                canvas.HasBackgroundColor = true;

                // Rasterize CMX onto the canvas
                // Use VectorRasterizationOptions via the canvas's VectorRasterizationOptions property
                // Set background color in rasterization options
                var rasterOptions = new CmxRasterizationOptions
                {
                    BackgroundColor = cmx.BackgroundColor
                };
                jpegOptions.VectorRasterizationOptions = rasterOptions;

                // Save the bound JPEG image
                canvas.Save();
            }
        }
    }
}