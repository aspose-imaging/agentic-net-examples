using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.cdr";
        string outputPath = "Output/sample.jpg";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load CDR file into a memory stream
        byte[] fileBytes = File.ReadAllBytes(inputPath);
        using (MemoryStream memoryStream = new MemoryStream(fileBytes))
        {
            // Load the CDR image from the memory stream
            using (CdrImage cdrImage = (CdrImage)Image.Load(memoryStream))
            {
                // Prepare JPEG export options with rasterization settings
                JpegOptions jpegOptions = new JpegOptions
                {
                    VectorRasterizationOptions = new CdrRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = cdrImage.Width,
                        PageHeight = cdrImage.Height,
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None
                    }
                };

                // Save directly to JPEG without intermediate files
                cdrImage.Save(outputPath, jpegOptions);
            }
        }
    }
}