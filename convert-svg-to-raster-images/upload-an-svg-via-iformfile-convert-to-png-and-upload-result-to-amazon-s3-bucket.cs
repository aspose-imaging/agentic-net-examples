using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.svg";
        string outputPath = "Output/sample.png";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load SVG from file stream and rasterize to PNG
        using (FileStream inputStream = File.OpenRead(inputPath))
        using (SvgImage svgImage = new SvgImage(inputStream))
        {
            // Set rasterization options
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                PageSize = svgImage.Size,
                BackgroundColor = Color.White
            };

            // Configure PNG save options
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save rasterized PNG
            svgImage.Save(outputPath, pngOptions);
        }

        // Placeholder for uploading the PNG to Amazon S3
        // Implementation omitted due to external library restrictions
        // Example: UploadToS3(outputPath);
    }
}