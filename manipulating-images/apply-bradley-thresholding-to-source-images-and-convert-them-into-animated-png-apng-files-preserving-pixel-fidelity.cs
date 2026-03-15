using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input folder containing source images
        string inputFolder = "input_images";
        // Output APNG file path
        string outputPath = "output_animation.apng";

        // Collect supported image files from the input folder
        string[] supportedExtensions = new[] { ".png", ".jpg", ".jpeg", ".bmp", ".tif", ".tiff" };
        List<string> imageFiles = Directory.GetFiles(inputFolder)
            .Where(f => supportedExtensions.Contains(Path.GetExtension(f), StringComparer.OrdinalIgnoreCase))
            .ToList();

        if (imageFiles.Count == 0)
        {
            Console.WriteLine("No supported images found in the input folder.");
            return;
        }

        // Load the first image to determine canvas size
        using (RasterImage firstImage = (RasterImage)Image.Load(imageFiles[0]))
        {
            // Apply Bradley thresholding to preserve pixel fidelity
            firstImage.BinarizeBradley(0.15, 8);

            int canvasWidth = firstImage.Width;
            int canvasHeight = firstImage.Height;

            // Configure APNG creation options
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = 100U, // 100 ms per frame
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create the APNG image canvas
            using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, canvasWidth, canvasHeight))
            {
                // Ensure the image starts with an empty frame collection
                apngImage.RemoveAllFrames();

                // Add the processed first frame
                apngImage.AddFrame(firstImage);

                // Process and add remaining frames
                for (int i = 1; i < imageFiles.Count; i++)
                {
                    using (RasterImage frame = (RasterImage)Image.Load(imageFiles[i]))
                    {
                        // Apply the same Bradley thresholding
                        frame.BinarizeBradley(0.15, 8);
                        // Add the frame to the animation
                        apngImage.AddFrame(frame);
                    }
                }

                // Save the animated PNG
                apngImage.Save();
            }
        }

        Console.WriteLine($"Animated PNG saved to: {outputPath}");
    }
}