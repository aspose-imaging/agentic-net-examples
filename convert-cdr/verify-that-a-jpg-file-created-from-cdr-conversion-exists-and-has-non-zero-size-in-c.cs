using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
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

            // Load CDR image and convert to JPEG
            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                JpegOptions jpegOptions = new JpegOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    // Configure rasterization for vector image
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = cdr.Width,
                        PageHeight = cdr.Height,
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None
                    }
                };

                cdr.Save(outputPath, jpegOptions);
            }

            // Verify the JPEG file exists and has non‑zero size
            if (File.Exists(outputPath))
            {
                long fileSize = new FileInfo(outputPath).Length;
                if (fileSize > 0)
                {
                    Console.WriteLine($"JPG file created successfully. Size: {fileSize} bytes.");
                }
                else
                {
                    Console.WriteLine("JPG file was created but is empty.");
                }
            }
            else
            {
                Console.WriteLine("JPG file was not created.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}