using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

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

        // Load the CDR image and convert to JPEG
        using (Image image = Image.Load(inputPath))
        {
            JpegOptions jpegOptions = new JpegOptions();

            // Set rasterization options for vector images
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

            // Save as JPEG
            image.Save(outputPath, jpegOptions);
        }

        // Verify the output file exists and has non‑zero size
        if (File.Exists(outputPath))
        {
            FileInfo info = new FileInfo(outputPath);
            if (info.Length > 0)
            {
                Console.WriteLine($"Conversion succeeded. Output size: {info.Length} bytes.");
            }
            else
            {
                Console.WriteLine("Conversion failed: output file is empty.");
            }
        }
        else
        {
            Console.WriteLine("Conversion failed: output file not found.");
        }
    }
}