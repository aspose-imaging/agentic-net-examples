using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.wmf";
        string outputPath = "output.jpg";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        string outputDir = Path.GetDirectoryName(outputPath);
        if (string.IsNullOrEmpty(outputDir))
            outputDir = ".";
        Directory.CreateDirectory(outputDir);

        // Load WMF image
        using (WmfImage wmfImage = (WmfImage)Image.Load(inputPath))
        {
            // Configure rasterization options
            WmfRasterizationOptions rasterOptions = new WmfRasterizationOptions
            {
                BackgroundColor = Color.White,
                PageSize = new SizeF(wmfImage.Width, wmfImage.Height)
            };

            // Configure JPEG options with 300 DPI
            JpegOptions jpegOptions = new JpegOptions
            {
                ResolutionSettings = new ResolutionSetting(300, 300),
                VectorRasterizationOptions = rasterOptions
            };

            // Save as JPEG
            wmfImage.Save(outputPath, jpegOptions);
        }
    }
}