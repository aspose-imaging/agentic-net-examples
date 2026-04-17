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
        // Define relative input and output directories
        string inputDirectory = "Input";
        string outputDirectory = "Output";

        // Ensure input directory exists
        if (!Directory.Exists(inputDirectory))
        {
            Directory.CreateDirectory(inputDirectory);
            Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
            return;
        }

        // Ensure output directory exists
        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        // Get all CDR files in the input directory
        string[] files = Directory.GetFiles(inputDirectory, "*.cdr");

        foreach (string inputPath in files)
        {
            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Build output file name with timestamp
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            string outputPath = Path.Combine(outputDirectory, $"{fileNameWithoutExt}_{timestamp}.jpg");

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR image and convert to JPEG
            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                JpegOptions jpegOptions = new JpegOptions
                {
                    VectorRasterizationOptions = new CdrRasterizationOptions
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
        }
    }
}