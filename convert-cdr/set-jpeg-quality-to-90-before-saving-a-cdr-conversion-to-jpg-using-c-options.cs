using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.cdr";
        string outputPath = "Output/sample.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CDR vector image
        using (Image image = Image.Load(inputPath))
        {
            // Configure JPEG save options with quality 90
            using (JpegOptions jpegOptions = new JpegOptions())
            {
                jpegOptions.Quality = 90;

                // Set vector rasterization options for vector images
                if (image is VectorImage)
                {
                    jpegOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height,
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None
                    };
                }

                // Save the converted JPEG image
                image.Save(outputPath, jpegOptions);
            }
        }
    }
}