using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input and output directories (relative paths)
        string inputDirectory = "Input";
        string outputDirectory = "Output";

        // Ensure output directory exists
        Directory.CreateDirectory(outputDirectory);

        // Get JPEG files from the input directory
        string[] files = Directory.GetFiles(inputDirectory, "*.jpg");
        string[] jpegFiles = Directory.GetFiles(inputDirectory, "*.jpeg");
        files = files.Concat(jpegFiles).ToArray();

        // List to hold CMYK-converted raster images
        List<RasterImage> cmykImages = new List<RasterImage>();

        foreach (string inputPath in files)
        {
            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                continue;
            }

            // Load original JPEG
            using (JpegImage jpeg = (JpegImage)Image.Load(inputPath))
            {
                // Prepare CMYK JPEG options
                JpegOptions cmOptions = new JpegOptions
                {
                    ColorType = JpegCompressionColorMode.Cmyk,
                    Source = new StreamSource(new MemoryStream(), false)
                };

                // Save to memory stream with CMYK conversion
                using (MemoryStream ms = new MemoryStream())
                {
                    cmOptions.Source = new StreamSource(ms, false);
                    jpeg.Save(ms, cmOptions);
                    ms.Position = 0;

                    // Load the CMYK image back as a raster image
                    RasterImage cmykImg = (RasterImage)Image.Load(ms);
                    cmykImages.Add(cmykImg);
                }
            }
        }

        if (cmykImages.Count == 0)
        {
            Console.WriteLine("No JPEG files were processed.");
            return;
        }

        // Calculate canvas size for vertical merge
        int canvasWidth = cmykImages.Max(img => img.Width);
        int canvasHeight = cmykImages.Sum(img => img.Height);

        // Output file path
        string outputPath = Path.Combine(outputDirectory, "merged.jpg");
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create JPEG canvas with CMYK options
        JpegOptions outOptions = new JpegOptions
        {
            ColorType = JpegCompressionColorMode.Cmyk,
            Quality = 100,
            Source = new FileCreateSource(outputPath, false)
        };

        using (JpegImage canvas = (JpegImage)Image.Create(outOptions, canvasWidth, canvasHeight))
        {
            int offsetY = 0;
            foreach (RasterImage img in cmykImages)
            {
                // Define destination rectangle on the canvas
                Rectangle destRect = new Rectangle(0, offsetY, img.Width, img.Height);
                // Copy pixel data
                canvas.SaveArgb32Pixels(destRect, img.LoadArgb32Pixels(img.Bounds));
                offsetY += img.Height;
            }

            // Save the bound canvas to the output file
            canvas.Save();
        }

        // Dispose all temporary CMYK images
        foreach (RasterImage img in cmykImages)
        {
            img.Dispose();
        }
    }
}