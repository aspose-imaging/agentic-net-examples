using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.wmf";
        string outputPath = @"C:\Images\output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the WMF image
        using (Image image = Image.Load(inputPath))
        {
            WmfImage wmfImage = (WmfImage)image;

            // Replace black strokes with blue.
            // The actual record types may vary; this loop shows where the color
            // substitution would be performed.
            foreach (var record in wmfImage.Records)
            {
                // Example placeholder:
                // if (record is Aspose.Imaging.FileFormats.Wmf.WmfPenRecord penRecord &&
                //     penRecord.Color == Aspose.Imaging.Color.Black)
                // {
                //     penRecord.Color = Aspose.Imaging.Color.Blue;
                // }
            }

            // Set up SVG save options
            SvgOptions svgOptions = new SvgOptions
            {
                TextAsShapes = true
            };

            // Configure rasterization options for the WMF source
            WmfRasterizationOptions rasterOptions = new WmfRasterizationOptions
            {
                BackgroundColor = Aspose.Imaging.Color.White,
                PageSize = wmfImage.Size,
                RenderMode = Aspose.Imaging.FileFormats.Wmf.WmfRenderMode.Auto
            };

            svgOptions.VectorRasterizationOptions = rasterOptions;

            // Save as SVG
            wmfImage.Save(outputPath, svgOptions);
        }
    }
}