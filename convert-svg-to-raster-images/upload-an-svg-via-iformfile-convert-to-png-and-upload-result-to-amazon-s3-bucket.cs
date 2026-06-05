using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.svg";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputPath = "Output/sample.png";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (FileStream inputStream = File.OpenRead(inputPath))
            using (SvgImage svgImage = new SvgImage(inputStream))
            {
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = svgImage.Size
                    }
                };

                svgImage.Save(outputPath, pngOptions);
            }

            // Placeholder for S3 upload - not implemented due to library restrictions
            using (FileStream pngStream = File.OpenRead(outputPath))
            {
                throw new NotSupportedException("Amazon S3 upload is not implemented in this example.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}