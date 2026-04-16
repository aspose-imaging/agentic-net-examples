using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Define base, input and output directories (relative paths)
        string baseDir = Directory.GetCurrentDirectory();
        string inputDirectory = Path.Combine(baseDir, "Input");
        string outputDirectory = Path.Combine(baseDir, "Output");

        // Ensure input directory exists; if not, create it and exit
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

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // If the image is raster, crop to 16:9 aspect ratio
                if (image is RasterImage rasterImage)
                {
                    if (!rasterImage.IsCached)
                        rasterImage.CacheData();

                    int width = rasterImage.Width;
                    int height = rasterImage.Height;
                    double targetRatio = 16.0 / 9.0;
                    double currentRatio = (double)width / height;

                    Rectangle cropRect;

                    if (currentRatio > targetRatio)
                    {
                        // Image is too wide – reduce width
                        int cropWidth = (int)(height * targetRatio);
                        int x = (width - cropWidth) / 2;
                        cropRect = new Rectangle(x, 0, cropWidth, height);
                    }
                    else
                    {
                        // Image is too tall – reduce height
                        int cropHeight = (int)(width / targetRatio);
                        int y = (height - cropHeight) / 2;
                        cropRect = new Rectangle(0, y, width, cropHeight);
                    }

                    rasterImage.Crop(cropRect);
                }

                // Prepare output SVG path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".svg");

                // Ensure the output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Set up SVG export options with rasterization settings
                var rasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };

                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save the image as SVG
                image.Save(outputPath, svgOptions);
            }
        }
    }
}