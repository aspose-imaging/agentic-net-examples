using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Define base, input, and output directories
        string baseDir = Directory.GetCurrentDirectory();
        string inputDirectory = Path.Combine(baseDir, "Input");
        string outputDirectory = Path.Combine(baseDir, "Output");

        // Ensure input directory exists; create if missing and exit
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

        // Get all files in the input directory
        string[] files = Directory.GetFiles(inputDirectory, "*.*");

        foreach (string inputPath in files)
        {
            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Derive output file names
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
            string jpegPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".jpg");
            string pngPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".png");

            // Load the vector image
            using (Image image = Image.Load(inputPath))
            {
                // ----- JPEG conversion -----
                using (JpegOptions jpegOptions = new JpegOptions())
                {
                    jpegOptions.Quality = 100; // High-quality JPEG
                    jpegOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height,
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None
                    };

                    // Ensure output directory for JPEG exists
                    Directory.CreateDirectory(Path.GetDirectoryName(jpegPath));
                    image.Save(jpegPath, jpegOptions);
                }

                // ----- PNG conversion -----
                using (PngOptions pngOptions = new PngOptions())
                {
                    pngOptions.ColorType = PngColorType.TruecolorWithAlpha;
                    pngOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height,
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None
                    };

                    // Ensure output directory for PNG exists
                    Directory.CreateDirectory(Path.GetDirectoryName(pngPath));
                    image.Save(pngPath, pngOptions);
                }
            }
        }
    }
}