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
        try
        {
            // Define input and output directories
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            // Ensure directories exist
            Directory.CreateDirectory(inputDirectory);
            Directory.CreateDirectory(outputDirectory);

            // Get JPEG files
            string[] files = Directory.GetFiles(inputDirectory, "*.jpg")
                .Concat(Directory.GetFiles(inputDirectory, "*.jpeg"))
                .ToArray();

            if (files.Length == 0)
            {
                Console.WriteLine("No JPEG files found in the input directory.");
                return;
            }

            // Load each image, convert to CMYK, and collect sizes
            List<RasterImage> cmykImages = new List<RasterImage>();
            List<Size> sizes = new List<Size>();

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Load original JPEG
                using (JpegImage original = (JpegImage)Image.Load(inputPath))
                {
                    // Prepare CMYK save options
                    JpegOptions cmykOptions = new JpegOptions
                    {
                        ColorType = JpegCompressionColorMode.Cmyk,
                        Quality = 100
                    };

                    // Save to memory stream with CMYK profile
                    using (MemoryStream ms = new MemoryStream())
                    {
                        original.Save(ms, cmykOptions);
                        ms.Position = 0;

                        // Load the CMYK image back as RasterImage
                        RasterImage cmykImg = (RasterImage)Image.Load(ms);
                        cmykImages.Add(cmykImg);
                        sizes.Add(cmykImg.Size);
                    }
                }
            }

            if (cmykImages.Count == 0)
            {
                Console.WriteLine("No valid images were processed.");
                return;
            }

            // Calculate canvas size for vertical merge
            int canvasWidth = sizes.Max(s => s.Width);
            int canvasHeight = sizes.Sum(s => s.Height);

            // Output path
            string outputPath = Path.Combine(outputDirectory, "merged.jpg");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create JPEG canvas bound to the output file
            JpegOptions canvasOptions = new JpegOptions
            {
                Source = new FileCreateSource(outputPath, false),
                Quality = 100
            };

            using (JpegImage canvas = (JpegImage)Image.Create(canvasOptions, canvasWidth, canvasHeight))
            {
                int offsetY = 0;
                foreach (RasterImage img in cmykImages)
                {
                    Rectangle bounds = new Rectangle(0, offsetY, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetY += img.Height;
                    img.Dispose();
                }

                // Save the bound canvas
                canvas.Save();
            }

            Console.WriteLine($"Merged image saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}