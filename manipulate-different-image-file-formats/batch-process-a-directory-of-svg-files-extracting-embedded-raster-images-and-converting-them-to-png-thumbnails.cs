using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Set up input and output directories
        string baseDir = Directory.GetCurrentDirectory();
        string inputDirectory = Path.Combine(baseDir, "Input");
        string outputDirectory = Path.Combine(baseDir, "Output");

        // Ensure directories exist
        if (!Directory.Exists(inputDirectory))
        {
            Directory.CreateDirectory(inputDirectory);
            Console.WriteLine($"Input directory created at: {inputDirectory}. Add SVG files and rerun.");
            return;
        }

        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        // Get all SVG files in the input directory
        string[] files = Directory.GetFiles(inputDirectory, "*.svg");

        foreach (string inputPath in files)
        {
            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (Image image = Image.Load(inputPath))
            {
                VectorImage vectorImage = (VectorImage)image;
                EmbeddedImage[] embeddedImages = vectorImage.GetEmbeddedImages();
                int index = 0;

                foreach (EmbeddedImage embedded in embeddedImages)
                {
                    using (embedded)
                    {
                        // Prepare output file path
                        string baseName = Path.GetFileNameWithoutExtension(inputPath);
                        string outFilePath = Path.Combine(outputDirectory, $"{baseName}_{index}.png");

                        // Ensure the output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outFilePath));

                        // Cast the embedded image to RasterImage for processing
                        using (RasterImage raster = (RasterImage)embedded.Image)
                        {
                            // Create a thumbnail with max dimension 150 while preserving aspect ratio
                            const int maxDim = 150;
                            int thumbWidth = raster.Width;
                            int thumbHeight = raster.Height;

                            if (thumbWidth > thumbHeight)
                            {
                                if (thumbWidth > maxDim)
                                {
                                    thumbHeight = thumbHeight * maxDim / thumbWidth;
                                    thumbWidth = maxDim;
                                }
                            }
                            else
                            {
                                if (thumbHeight > maxDim)
                                {
                                    thumbWidth = thumbWidth * maxDim / thumbHeight;
                                    thumbHeight = maxDim;
                                }
                            }

                            // Resize to thumbnail size
                            raster.Resize(thumbWidth, thumbHeight);

                            // Save as PNG
                            using (PngOptions pngOptions = new PngOptions())
                            {
                                raster.Save(outFilePath, pngOptions);
                            }
                        }
                    }

                    index++;
                }
            }
        }
    }
}