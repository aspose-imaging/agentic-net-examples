using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Define base, input and output directories
        string baseDir = Directory.GetCurrentDirectory();
        string inputDirectory = Path.Combine(baseDir, "Input");
        string outputDirectory = Path.Combine(baseDir, "Output");

        // Ensure input directory exists; create if missing
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
            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
            string jpegOutputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".jpg");
            string pngOutputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".png");

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(jpegOutputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(pngOutputPath));

            // Load the vector image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare JPEG options
                var jpegOptions = new JpegOptions
                {
                    Quality = 100,
                    Source = new FileCreateSource(jpegOutputPath, false),
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    }
                };

                // Save as high‑resolution JPEG
                image.Save(jpegOutputPath, jpegOptions);

                // Prepare PNG options (lossless)
                var pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(pngOutputPath, false),
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    }
                };

                // Save as lossless PNG
                image.Save(pngOutputPath, pngOptions);
            }
        }
    }
}