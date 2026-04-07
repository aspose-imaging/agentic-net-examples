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
        // Hardcoded input directory and output file path
        string inputDirectory = "InputImages";
        string outputPath = "Output\\merged.jpg";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Retrieve JPEG files from the input directory
        string[] files = Directory.GetFiles(inputDirectory, "*.jpg");
        // Include .jpeg extension as well
        files = files.Concat(Directory.GetFiles(inputDirectory, "*.jpeg")).ToArray();

        // Collect sizes of all images
        List<Size> sizes = new List<Size>();
        foreach (string file in files)
        {
            // Validate input file existence
            if (!File.Exists(file))
            {
                Console.Error.WriteLine($"File not found: {file}");
                return;
            }

            using (RasterImage img = (RasterImage)Image.Load(file))
            {
                sizes.Add(img.Size);
            }
        }

        if (sizes.Count == 0)
        {
            Console.WriteLine("No JPEG images found to merge.");
            return;
        }

        // Calculate dimensions for the horizontal canvas
        int newWidth = sizes.Sum(s => s.Width);
        int newHeight = sizes.Max(s => s.Height);

        // Prepare JPEG options with a bound output source
        Source outputSource = new FileCreateSource(outputPath, false);
        JpegOptions jpegOptions = new JpegOptions()
        {
            Source = outputSource,
            Quality = 90 // Adjust quality as needed
        };

        // Create a JPEG canvas bound to the output file
        using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, newWidth, newHeight))
        {
            int offsetX = 0;
            foreach (string file in files)
            {
                using (RasterImage img = (RasterImage)Image.Load(file))
                {
                    // Define the region where the current image will be placed
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    // Copy pixel data onto the canvas
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            // Save the bound canvas (output file is already specified in options)
            canvas.Save();
        }
    }
}