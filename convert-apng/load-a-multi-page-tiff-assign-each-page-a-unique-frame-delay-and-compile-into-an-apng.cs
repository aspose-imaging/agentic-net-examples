using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input\\multi_page.tif";
            string outputPath = "Output\\animation.apng";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the multi‑page TIFF
            using (Image tiffImage = Image.Load(inputPath))
            {
                if (tiffImage is IMultipageImage multipage)
                {
                    // Prepare APNG creation options
                    ApngOptions apngOptions = new ApngOptions
                    {
                        Source = new FileCreateSource(outputPath, false)
                    };

                    // Use dimensions of the first page for the APNG canvas
                    int width = multipage.Pages[0].Width;
                    int height = multipage.Pages[0].Height;

                    // Create the APNG image
                    using (ApngImage apngImage = (ApngImage)Image.Create(apngOptions, width, height))
                    {
                        // Remove the default frame that exists upon creation
                        apngImage.RemoveAllFrames();

                        // Add each TIFF page as a frame with a unique delay
                        for (int i = 0; i < multipage.PageCount; i++)
                        {
                            RasterImage page = (RasterImage)multipage.Pages[i];
                            uint frameDelay = (uint)((i + 1) * 100); // Example: 100 ms, 200 ms, ...

                            // Add the frame with the specified delay
                            apngImage.AddFrame(page, frameDelay);
                        }

                        // Save the resulting APNG
                        apngImage.Save();
                    }
                }
                else
                {
                    Console.Error.WriteLine("Loaded image is not a multipage image.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}