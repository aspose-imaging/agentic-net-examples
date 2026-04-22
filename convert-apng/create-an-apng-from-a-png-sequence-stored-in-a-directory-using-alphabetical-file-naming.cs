using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input directory and output file paths
            string inputDirectory = "InputPngs";
            string outputFilePath = "Output\\animation.apng";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputFilePath));

            // Get PNG files sorted alphabetically
            string[] pngFiles = Directory.GetFiles(inputDirectory, "*.png")
                                         .OrderBy(f => f)
                                         .ToArray();

            if (pngFiles.Length == 0)
            {
                Console.Error.WriteLine("No PNG files found in the input directory.");
                return;
            }

            // Load first image to obtain canvas size
            string firstFile = pngFiles[0];
            if (!File.Exists(firstFile))
            {
                Console.Error.WriteLine($"File not found: {firstFile}");
                return;
            }

            int canvasWidth, canvasHeight;
            using (RasterImage firstImage = (RasterImage)Image.Load(firstFile))
            {
                canvasWidth = firstImage.Width;
                canvasHeight = firstImage.Height;
            }

            // Create APNG canvas bound to the output file
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputFilePath, false),
                ColorType = PngColorType.TruecolorWithAlpha,
                DefaultFrameTime = 100 // default frame duration in ms
            };

            using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, canvasWidth, canvasHeight))
            {
                // Remove the default empty frame
                apngImage.RemoveAllFrames();

                // Add each PNG as a frame
                foreach (string pngPath in pngFiles)
                {
                    if (!File.Exists(pngPath))
                    {
                        Console.Error.WriteLine($"File not found: {pngPath}");
                        continue;
                    }

                    using (RasterImage frame = (RasterImage)Image.Load(pngPath))
                    {
                        // Ensure frame size matches canvas size
                        if (frame.Width != canvasWidth || frame.Height != canvasHeight)
                        {
                            // Resize frame to match canvas dimensions
                            frame.Resize(canvasWidth, canvasHeight, ResizeType.NearestNeighbourResample);
                        }

                        apngImage.AddFrame(frame);
                    }
                }

                // Save the APNG (output path already bound)
                apngImage.Save();
            }

            Console.WriteLine("APNG created successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}