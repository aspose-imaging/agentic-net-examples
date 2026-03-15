using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Input image path (can be any supported format)
        string inputPath = "input.jpg";

        // Desired output path with extension indicating target format
        string outputPath = "output.png";

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Determine the appropriate save options based on the output file extension
            string ext = Path.GetExtension(outputPath).ToLowerInvariant();

            // Select and configure the correct ImageOptions instance
            switch (ext)
            {
                case ".jpg":
                case ".jpeg":
                    using (var options = new JpegOptions())
                    {
                        image.Save(outputPath, options);
                    }
                    break;

                case ".png":
                    using (var options = new PngOptions())
                    {
                        image.Save(outputPath, options);
                    }
                    break;

                case ".bmp":
                    using (var options = new BmpOptions())
                    {
                        image.Save(outputPath, options);
                    }
                    break;

                case ".gif":
                    using (var options = new GifOptions())
                    {
                        image.Save(outputPath, options);
                    }
                    break;

                case ".tif":
                case ".tiff":
                    using (var options = new TiffOptions(TiffExpectedFormat.Default))
                    {
                        image.Save(outputPath, options);
                    }
                    break;

                case ".webp":
                    using (var options = new WebPOptions())
                    {
                        image.Save(outputPath, options);
                    }
                    break;

                case ".apng":
                    using (var options = new ApngOptions())
                    {
                        image.Save(outputPath, options);
                    }
                    break;

                case ".pdf":
                    using (var options = new PdfOptions())
                    {
                        image.Save(outputPath, options);
                    }
                    break;

                case ".svg":
                    using (var options = new SvgOptions())
                    {
                        image.Save(outputPath, options);
                    }
                    break;

                default:
                    throw new NotSupportedException($"The file extension '{ext}' is not supported for automatic saving.");
            }
        }
    }
}